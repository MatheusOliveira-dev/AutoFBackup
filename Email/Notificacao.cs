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
        private string _identificadorRotina = string.Empty;
        private string _diretorioBackup = string.Empty;
        private string _uidRotina = string.Empty;
        private string _conclusaoRotina = string.Empty;
        private bool _compactado;
        private string _diretorioLogsErroReplicacaoDeDados = string.Empty;
        private string _diretorioLogsSucessoReplicacaoDeDados = string.Empty;
        private bool _isRotinaBackup;
        private bool _isTesteEnvio;
        public Notificacao(string host, string porta, string usuario,
            string senha, bool ssl, string destinatarios, bool envialogTxt, string assunto,
            string identificadorRotina, string diretorioBackup,
            string uidRotina, string conclusaoRotina, bool compactado, bool isRotinaBackup, 
            string diretorioLogsErroReplicacaoDeDados, string diretorioLogsSucessoReplicacaoDeDados,
            bool isTesteEnvio = false)

        {
            this._host = host;
            this._porta = porta;
            this._usuario = usuario;
            this._senha = senha;
            this._ssl = ssl;
            this._destinatarios = destinatarios;
            this._envialogTxt = envialogTxt;
            this._assunto = assunto;
            this._identificadorRotina = identificadorRotina;
            this._diretorioBackup = diretorioBackup;
            this._uidRotina = uidRotina;
            this._conclusaoRotina = conclusaoRotina;
            this._compactado = compactado;
            this._isRotinaBackup = isRotinaBackup;
            this._diretorioLogsErroReplicacaoDeDados = diretorioLogsErroReplicacaoDeDados;
            this._diretorioLogsSucessoReplicacaoDeDados = diretorioLogsSucessoReplicacaoDeDados;
            this._isTesteEnvio = isTesteEnvio;
        }

        public void EnviaNotificacao(int arquivosPendentes, int arquivosEnviados)
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

            string mailBody = string.Empty;

            if (_isTesteEnvio)
            {
                mailBody = "✅ Teste de Envio de E-mail bem sucedido.";
            }
            else
            {
                if (_isRotinaBackup)
                {
                    mailBody = string.Format("ℹ {0}\n\n" +
                        "✅ Backup Realizado com Sucesso.\n\n" +
                        "Uid da Rotina: {5}\n" +
                        "Local: {1}\n" +
                        "Nome do Backup: {2}\n" +
                        "Compactado: {4}\n" +
                        "Conclusão do Backup: {3}",
                        _identificadorRotina, _diretorioBackup, _uidRotina, _conclusaoRotina, compactadoSimNao, _uidRotina);
                }
                else
                {
                    mailBody = string.Format("[ℹ] {0}\n\n" +
                        "[✅] Rotina de Replicação de Dados Realizada com Sucesso\n\n" +
                        "Uid da Rotina: {1}\n\n" +
                        "Arquivos Pendentes: {2}\n\n" +
                        "Arquivos Enviados: {3}\n\n" +
                        "Conclusão da Rotina: {4}",
                        _identificadorRotina, _uidRotina, arquivosPendentes, arquivosEnviados, _conclusaoRotina);
                }
            }

            mail.Body = mailBody;

            if (this._envialogTxt && _isRotinaBackup)
            {
                mail.Body += "\n\nEm anexo o Log do Backup criado.";
                Attachment anexoLog = new Attachment(string.Format(@"{0}\LogBackup-{1}.txt", _diretorioBackup, _uidRotina), MediaTypeNames.Application.Octet);
                mail.Attachments.Add(anexoLog);
            }
            else if (this._envialogTxt && !_isRotinaBackup)
            {
                mail.Body += "\n\nEm anexo o Log da Rotina.";
                Attachment anexoLog = new Attachment(string.Format(@"{0}\LogReplicacaoDeDados-{1}.txt", _diretorioLogsSucessoReplicacaoDeDados, _uidRotina), MediaTypeNames.Application.Octet);
                mail.Attachments.Add(anexoLog);
            }



            mail.IsBodyHtml = false;


            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                if (!_isTesteEnvio)
                {
                    Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _isRotinaBackup ? _diretorioBackup : _diretorioLogsErroReplicacaoDeDados, _uidRotina),
                    string.Format("Erro no Envio de Notificação (Sucesso) por E-mail.\n\nException: {0}\n\nInnerException: {1}",
                     ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                }
                else
                {
                    throw ex;
                }
                   
            }


        }

        public void EnviaNotificacaoErro(int arquivosPendentes, int arquivosEnviados)
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

            mail.Subject = string.Format("[ERRO - {0}] {1}", this._identificadorRotina, this._assunto);

            mail.Priority = MailPriority.High;

            Attachment anexoLog = null;
            
            if (_isRotinaBackup)
            {
                anexoLog = new Attachment(string.Format(@"{0}\LogErro-{1}.txt", _diretorioBackup, _uidRotina), MediaTypeNames.Application.Octet);
            }
            else
            {
                anexoLog = new Attachment(string.Format(@"{0}\LogErroReplicacaoDeDados-{1}.txt", _diretorioLogsErroReplicacaoDeDados, _uidRotina), MediaTypeNames.Application.Octet);

            }


            mail.Attachments.Add(anexoLog);

            string mailBody = string.Empty;

            if (_isRotinaBackup)
            {
                mailBody = string.Format("ℹ {0}\n\n" +
                    "❌ Erro ao Realizar o Backup.\n\n" +
                    "Uid da Rotina: {1}\n" +
                    "Consulte o Log de Erro no Diretório de Backup da Rotina para mais Informações.\n" +
                    "Em anexo o Log de Erro ao Criar o Backup.",
                    _identificadorRotina, _uidRotina);
            }
            else
            {
                mailBody = string.Format("[ℹ] {0}\n\n" +
                        "❌ Erro na Rotina de Replicação de Dados\n\n" +
                        "Uid da Rotina: {1}\n\n" +
                        "Arquivos Pendentes: {2}\n\n" +
                        "Arquivos Enviados: {3}\n\n" +
                        "Em anexo o Log de Erro da Rotina.",
                        _identificadorRotina, _uidRotina, arquivosPendentes, arquivosEnviados);
            }

            mail.Body = mailBody;

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _isRotinaBackup ? _diretorioBackup : _diretorioLogsErroReplicacaoDeDados, _uidRotina),
                  string.Format("Erro no Envio de Notificação (Erro) por E-mail.\n\nException: {0}\n\nInnerException: {1}",
                   ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty));
            }

        }
    }
}
