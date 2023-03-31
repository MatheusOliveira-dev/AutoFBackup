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
        private string _diretorioBackups = string.Empty;
        private string _uidRotinaBackup = string.Empty;
        private string _conclusaoBackup = string.Empty;
        private bool _compactado;
        private bool _isTesteEnvio;

        public Notificacao(string accessTokenBot, string chatIdDestino, string identificador, string diretorioBackups,
            string uidRotinaBackup, string conclusaoBackup, bool compactado, bool isTesteEnvio = false)
        {
            _accessTokenBot = accessTokenBot;
            _chatIdDestino = chatIdDestino;
            _identificador = identificador;
            _diretorioBackups = diretorioBackups;
            _uidRotinaBackup = uidRotinaBackup;
            _conclusaoBackup = conclusaoBackup;
            _compactado = compactado;
            _isTesteEnvio = isTesteEnvio;
        }
        public async Task EnviaMensagemSucesso()
        {
            string compactadoSimNao = _compactado ? "Sim" : "Não";

            var bot = new TelegramBotClient(_accessTokenBot);
            var chatId = _chatIdDestino;
            var mensagem = _isTesteEnvio ? "[✅] *Teste de Envio de Mensagem bem sucedido.*" : string.Format("[ℹ] *{0}*\n\n" +
                "[✅] *Backup Realizado com Sucesso*\n\n" +
                "*Uid da Rotina*: {4}\n\n" +
                "*Local*: {1}\n\n" +
                "*Nome do Backup*: {2}\n\n" +
                "*Compactado*: {5}\n\n" +
                "*Conclusão do Backup*: {3}\n\n" +
                "_Se habilitado previamente, você receberá a seguir o Log do Backup, aguarde. 🕓_",
                _identificador, _diretorioBackups, _uidRotinaBackup, _conclusaoBackup, _uidRotinaBackup, compactadoSimNao);


            await bot.SendTextMessageAsync(chatId, mensagem, ParseMode.Markdown);
        }


        public async Task EnviaMensagemErro()
        {
            try
            {
                var bot = new TelegramBotClient(_accessTokenBot);
                var chatId = _chatIdDestino;

                var mensagem = string.Format("[ℹ] - *{0}*\n\n" +
               "[❌] *Erro ao Realizar o Backup*.\n\n" +
               "*Uid da Rotina*: {1}\n\n" +
               "*Consulte o Log de Erro no Diretório de Backup da Rotina para mais Informações*\n\n" +
                "_Você receberá a seguir o Log de Erro ao Criar o Backup, aguarde 🕓_\n\n",
               _identificador, _uidRotinaBackup);

                await bot.SendTextMessageAsync(chatId, mensagem, ParseMode.Markdown);

            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
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
                var arquivoLog = string.Format(@"{0}\{1}-{2}.txt", _diretorioBackups, tipoLog, _uidRotinaBackup);

                using (FileStream fileStream = new FileStream(arquivoLog, FileMode.Open, FileAccess.Read))
                {
                    var inputFile = new InputOnlineFile(fileStream, Path.GetFileName(string.Format(@"{0}\{1}-{2}.txt", _diretorioBackups, tipoLog, _uidRotinaBackup)));
                    await bot.SendDocumentAsync(chatId, inputFile);
                    fileStream.Dispose();
                }
                
            }
            catch (Exception ex)
            {

                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
                    string.Format("Erro ao Enviar o Arquivo de Log {0} para o Telegram.\n\nException: {1}\n\nInnerException: {2}", 
                    tipoLog, ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty));
            }

        }
    }
}
