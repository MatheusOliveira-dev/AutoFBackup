using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Telegram
{
    public class Notificacao
    {

        private string _accessTokenBot = string.Empty;
        private string _chatIdDestino = string.Empty;
        private string _identificador = string.Empty;
        private string _uidRotina = string.Empty;
        private string _conclusaoRotina = string.Empty;
        private bool _isTesteEnvio;
        private string _diretorioBackup = string.Empty;
        private bool _isRotinaBackup;
        private string _diretorioLogsErroReplicacaoDeDados = string.Empty;

        public Notificacao(string accessTokenBot, string chatIdDestino, string identificador, string uidRotina,
            string conclusaoRotina, bool isRotinaBackup, string diretorioBackup, string diretorioLogsErroReplicacaoDeDados,
            bool isTesteEnvio = false)
        {
            _accessTokenBot = accessTokenBot;
            _chatIdDestino = chatIdDestino;
            _identificador = identificador;
            _uidRotina = uidRotina;
            _conclusaoRotina = conclusaoRotina;
            _isTesteEnvio = isTesteEnvio;
            _diretorioBackup = diretorioBackup;
            _diretorioLogsErroReplicacaoDeDados = diretorioLogsErroReplicacaoDeDados;
            _isRotinaBackup = isRotinaBackup;
        }
        public async Task EnviaMensagemSucesso(bool compactado, int arquivosPendentes, int arquivosEnviados)
        {
            string compactadoSimNao = compactado ? "Sim" : "Não";

            var bot = new TelegramBotClient(_accessTokenBot);
            var chatId = _chatIdDestino;

            var mensagem = string.Empty;
            

            if (_isTesteEnvio)
            {
                mensagem = "[✅] *Teste de Envio de Mensagem bem sucedido.*";
            }
            else
            {

                if (!_isRotinaBackup)
                {
                    mensagem = string.Format("[ℹ] - *{0}*\n\n" +
                        "[✅] *Rotina de Replicação de Dados Concluída com Sucesso*\n\n" +
                        "*Uid da Rotina*: {1}\n\n" +
                        "*Arquivos Pendentes*: {2}\n\n" +
                        "*Arquivos Enviados*: {3}*\n\n" +
                        "*Conclusão da Rotina*: {4}\n\n" +
                        "*_Você receberá a seguir o Log de Resumo da Rotina, aguarde 🕓_\n\n",
                        _identificador, _uidRotina, arquivosPendentes, arquivosEnviados, _conclusaoRotina);
                }
                else
                {
                    mensagem = string.Format("[ℹ] *{0}*\n\n" +
                        "[✅] *Backup Realizado com Sucesso*\n\n" +
                        "*Uid da Rotina*: {4}\n\n" +
                        "*Local*: {1}\n\n" +
                        "*Nome do Backup*: {2}\n\n" +
                        "*Compactado*: {5}\n\n" +
                        "*Conclusão do Backup*: {3}\n\n" +
                        "_Se habilitado previamente, você receberá a seguir o Log do Backup, aguarde. 🕓_",
                        _identificador, _diretorioBackup, _uidRotina, _conclusaoRotina, _uidRotina, compactadoSimNao);
                }
            }


            await bot.SendTextMessageAsync(chatId, mensagem, ParseMode.Markdown);
        }


        public async Task EnviaMensagemErro(int arquivosPendentes, int arquivosEnviados)
        {
            try
            {
                var bot = new TelegramBotClient(_accessTokenBot);
                var chatId = _chatIdDestino;

                var mensagem = string.Empty;

                if (!_isRotinaBackup)
                {
                    mensagem = string.Format("[ℹ] - *{0}*\n\n" +
                        "[❌] *Erro na Rotina de Replicação de Dados*\n\n" +
                        "*Uid da Rotina*: {1}\n\n" +
                        "*Arquivos Pendentes*: {2}\n\n" +
                        "*Arquivos Enviados*: {3}*\n\n" +
                        "*_Você receberá a seguir o Log de Erro da Rotina, aguarde 🕓_\n\n",
                        _identificador, _uidRotina, arquivosPendentes, arquivosEnviados);
                }
                else
                {
                    mensagem = string.Format("[ℹ] - *{0}*\n\n" +
                        "[❌] *Erro ao Realizar o Backup*.\n\n" +
                        "*Uid da Rotina*: {1}\n\n" +
                        "*Consulte o Log de Erro no Diretório de Backup da Rotina para mais Informações*\n\n" +
                        "_Você receberá a seguir o Log de Erro ao Criar o Backup, aguarde 🕓_\n\n",
                        _identificador, _uidRotina);
                }

                await bot.SendTextMessageAsync(chatId, mensagem, ParseMode.Markdown);

            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _isRotinaBackup ? _diretorioBackup : _diretorioLogsErroReplicacaoDeDados, _uidRotina),
                    string.Format("Erro ao Enviar a Mensagem de Notificação (Erro) para o Telegram.\n\nException: {0}\n\nInnerException: {1}",
                    ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty));  
            }
        }

        public async Task EnviaLogTxtAsync(string tipoLog)
        {
            try
            {

                var bot = new TelegramBotClient(_accessTokenBot);
                var chatId = _chatIdDestino;
                var arquivoLog = string.Format(@"{0}\{1}-{2}.txt", _diretorioBackup, tipoLog, _uidRotina);

                using (FileStream fileStream = new FileStream(arquivoLog, FileMode.Open, FileAccess.Read))
                {
                    var inputFile = new InputOnlineFile(fileStream, Path.GetFileName(string.Format(@"{0}\{1}-{2}.txt", _diretorioBackup, tipoLog, _uidRotina)));
                    await bot.SendDocumentAsync(chatId, inputFile);
                    fileStream.Dispose();
                }
                
            }
            catch (Exception ex)
            {

                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _isRotinaBackup ? _diretorioBackup : _diretorioLogsErroReplicacaoDeDados, _uidRotina),
                    string.Format("Erro ao Enviar o Arquivo de Log {0} para o Telegram.\n\nException: {1}\n\nInnerException: {2}", 
                    tipoLog, ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty));
            }

        }
    }
}
