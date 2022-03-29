using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    public class Notificacao
    {
        private string _host;
        private string _porta;
        private string _usuario;
        private string _senha;
        private bool _ssl;
        private string _destinatarios;
        private bool _envialogTxt;
        private string _assunto;
        private string _identificador = string.Empty;
        private string _diretorioBackups = string.Empty;
        private string _uidRotinaBackup = string.Empty;
        private string _conclusaoBackup = string.Empty;
        private bool _compactado;
        public Notificacao(string host, string porta, string usuario,
            string senha, bool ssl, string destinatarios, bool envialogTxt, string assunto,
            string identificador, string diretorioBackups,
            string uidRotinaBackup, string conclusaoBackup, bool compactado)

        {
            this._host = host;
            this._porta = porta;
            this._usuario = usuario;
            this._senha = senha;
            this._ssl = ssl;
            this._destinatarios = destinatarios;
            this._envialogTxt = envialogTxt;
            this._assunto = assunto;
            this._identificador = identificador;
            this._diretorioBackups = diretorioBackups;
            this._uidRotinaBackup = uidRotinaBackup;
            this._conclusaoBackup = conclusaoBackup;
            this._compactado = compactado;
        }

        public void EnviaNotificacao()
        {
            SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = this._host;
            client.Port = Shared.Helpers.ConverteStringParaNumero(this._porta);
            client.EnableSsl = this._ssl;
            client.Credentials = new System.Net.NetworkCredential(this._usuario, this._senha);

            MailMessage mail = new MailMessage();

            mail.Sender = new System.Net.Mail.MailAddress(this._usuario, "AutoFBackup");
            mail.From = new MailAddress(this._usuario, "AutoFBackup");


            mail.To.Add(new MailAddress(this._destinatarios.ToString().Trim(), this._destinatarios.ToString().Trim()));

            mail.Subject = this._assunto;

            mail.Priority = MailPriority.High;


            string compactadoSimNao = _compactado ? "Sim" : "Não";

            mail.Body = string.Format("ℹ {0}\n\n" +
             "✅ Backup Realizado com Sucesso.\n\n" +
             "Uid da Rotina: {5}\n" +
             "Local: {1}\n" +
             "Nome do Backup: {2}\n" +
             "Compactado: {4}\n" +
             "Conclusão do Backup: {3}",
             _identificador, _diretorioBackups, _uidRotinaBackup, _conclusaoBackup, compactadoSimNao, _uidRotinaBackup);

            if (this._envialogTxt)
            {
                mail.Body += "\n\nEm anexo o Log do Backup criado.";
                Attachment anexoLog = new Attachment(string.Format(@"{0}\LogBackup-{1}.txt", _diretorioBackups, _uidRotinaBackup), MediaTypeNames.Application.Octet);
                mail.Attachments.Add(anexoLog);
            }

         

            mail.IsBodyHtml = false;


            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
                    string.Format("Erro no Envio de Notificação (Sucesso) por E-mail -> {0}", ex.Message));
            }


        }

        public void EnviaNotificacaoErro()
        {
            SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = this._host;
            client.Port = Shared.Helpers.ConverteStringParaNumero(this._porta);
            client.EnableSsl = this._ssl;
            client.Credentials = new System.Net.NetworkCredential(this._usuario, this._senha);

            MailMessage mail = new MailMessage();

            mail.Sender = new System.Net.Mail.MailAddress(this._usuario, "AutoFBackup");
            mail.From = new MailAddress(this._usuario, "AutoFBackup");

            mail.To.Add(new MailAddress(this._destinatarios.ToString().Trim(), this._destinatarios.ToString().Trim()));

            mail.Subject = string.Format("[ERRO - {0}] {1}", this._identificador, this._assunto);

            mail.Priority = MailPriority.High;

            Attachment anexoLog = new Attachment(string.Format(@"{0}\LogErro-{1}.txt", _diretorioBackups, _uidRotinaBackup), MediaTypeNames.Application.Octet);
            mail.Attachments.Add(anexoLog);

            mail.Body = string.Format("ℹ {0}\n\n" +
            "❌ Erro ao Realizar o Backup.\n\n" +
            "Uid da Rotina: {1}\n" +
            "Consulte o Log de Erro no Diretório de Backup da Rotina para mais Informações.\n" +
            "Em anexo o Log de Erro ao Criar o Backup.",
            _identificador, _uidRotinaBackup);

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
                    string.Format("Erro no Envio de Notificação (Erro) por E-mail -> {0}", ex.Message));
            }

        }
    }
}
