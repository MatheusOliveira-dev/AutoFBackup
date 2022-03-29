using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public Notificacao(string accessTokenBot, string chatIdDestino, string identificador, string diretorioBackups,
            string uidRotinaBackup, string conclusaoBackup, bool compactado)
        {
            _accessTokenBot = accessTokenBot;
            _chatIdDestino = chatIdDestino;
            _identificador = identificador;
            _diretorioBackups = diretorioBackups;
            _uidRotinaBackup = uidRotinaBackup;
            _conclusaoBackup = conclusaoBackup;
            _compactado = compactado;
        }
        public void EnviaMensagemSucesso()
        {
            string compactadoSimNao = _compactado ? "Sim" : "Não";

            string mensagem = string.Format("[ℹ] *{0}*\n\n" +
                "[✅] *Backup Realizado com Sucesso*\n\n" +
                "*Uid da Rotina*: {4}\n\n" +
                "*Local*: {1}\n\n" +
                "*Nome do Backup*: {2}\n\n" +
                "*Compactado*: {5}\n\n" +
                "*Conclusão do Backup*: {3}\n\n" +
                "_Se habilitado previamente, você receberá a seguir o Log do Backup, aguarde. 🕓_",
                _identificador, _diretorioBackups, _uidRotinaBackup, _conclusaoBackup, _uidRotinaBackup, compactadoSimNao);


            var client = new RestClient(string.Format("{0}{1}/", BaseAPI.HostApi, _accessTokenBot));
            var request = new RestRequest("sendMessage")
            .AddQueryParameter("chat_id", _chatIdDestino)
            .AddQueryParameter("parse_mode", "MarkdownV2")
            .AddQueryParameter("text", Shared.Helpers.FormataMensagemParaEnvioTelegram(mensagem), encode: true);


            try
            {
                var response = client.GetAsync(request).Result;
            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
                    string.Format("Erro ao Enviar a Mensagem de Notificação (Sucesso) para o Telegram -> {0}", ex.Message));
            }

        }


        public void EnviaMensagemErro()
        {
            try
            {
                string mensagem = string.Format("[ℹ] - *{0}*\n\n" +
               "[❌] *Erro ao Realizar o Backup*.\n\n" +
               "*Uid da Rotina*: {1}\n\n" +
               "*Consulte o Log de Erro no Diretório de Backup da Rotina para mais Informações*\n\n" +
                "_Você receberá a seguir o Log de Erro ao Criar o Backup, aguarde 🕓_\n\n",
               _identificador, _uidRotinaBackup);

                var client = new RestClient(string.Format("{0}{1}/", BaseAPI.HostApi, _accessTokenBot));
                var request = new RestRequest("sendMessage")
                .AddQueryParameter("chat_id", _chatIdDestino)
                .AddQueryParameter("parse_mode", "MarkdownV2")
                .AddQueryParameter("text", Shared.Helpers.FormataMensagemParaEnvioTelegram(mensagem), encode: true);

                var response = client.GetAsync(request).Result;
            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
                    string.Format("Erro ao Enviar a Mensagem de Notificação (Erro) para o Telegram -> {0}", ex.Message));
            }
        }

        public async Task EnviaLogTxtAsync(string tipoLog)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), string.Format(string.Format("{0}{1}/sendDocument", BaseAPI.HostApi, _accessTokenBot))))
                    {
                        var multipartContent = new MultipartFormDataContent();
                        multipartContent.Add(new StringContent(_chatIdDestino), "chat_id");
                        multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(string.Format(@"{0}\{1}-{2}.txt", _diretorioBackups, tipoLog, _uidRotinaBackup))),
                            "document", Path.GetFileName(string.Format(@"{0}\{1}-{2}.txt", _diretorioBackups, tipoLog, _uidRotinaBackup)));
                        request.Content = multipartContent;

                        var response = await httpClient.SendAsync(request);
                    }
                }
            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
                    string.Format("Erro ao Enviar o Arquivo de Log: {0} para o Telegram -> {1}", tipoLog, ex.Message));
            }

        }
    }
}
