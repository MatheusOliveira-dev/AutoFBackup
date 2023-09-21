using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace FTP
{
    public class Upload
    {

        string _host = string.Empty;
        string _porta = string.Empty;
        string _usuario = string.Empty;
        string _senha = string.Empty;
        string _diretorioUploadRemoto = string.Empty;
        string _uidRotina = string.Empty;
        bool _compactado = false;
        string _extensaoBackup = string.Empty;
        string _diretorioBackup = string.Empty;
        bool _isRotinaBackup = false;
        string _diretorioLogErrosReplicacaoDeDados = string.Empty;
        bool _isTesteUpload = false;
        string _arquivoTesteUpload = string.Empty;

        public Upload(string host, string porta, string usuario, string senha, string diretorioUploadRemoto, string uidRotina, bool compactado, 
            string extensaoBackup, string diretorioBackup, bool isRotinaBackup, string diretorioLogErrosReplicacaoDeDados,
            bool isTesteUpload = false, string arquivoTesteUpload = "")
        {
            _host = host;
            _porta = porta;
            _usuario = usuario;
            _senha = senha;
            _diretorioUploadRemoto = diretorioUploadRemoto;
            _uidRotina = uidRotina;
            _compactado = compactado;
            _extensaoBackup = extensaoBackup;
            _diretorioBackup = diretorioBackup;
            _isRotinaBackup = isRotinaBackup;
            _diretorioLogErrosReplicacaoDeDados = diretorioLogErrosReplicacaoDeDados;
            _isTesteUpload = isTesteUpload;
            _arquivoTesteUpload = arquivoTesteUpload;
        }

        public void ExecutaUpload(string arquivoReplicacaoDeDados = "")
        {
            int portaFTP = Shared.Helpers.ConverteStringParaNumero(_porta);

            if (portaFTP == 0)
            {
                portaFTP = 21;

                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", 
                    _isRotinaBackup 
                    ? _diretorioBackup
                    : _diretorioLogErrosReplicacaoDeDados, _uidRotina),
                "[!] Porta 0 detectada para o FTP. O AutoFBackup tentará utilizar a porta padrão (21)");
            }



            string arquivoParaUpload = string.Empty;
            string nomeArquivoNoUpload = string.Empty;


            if (_isRotinaBackup)
            {
                arquivoParaUpload = string.Format(@"{0}\{1}{2}", _diretorioBackup, _uidRotina, 
                    _compactado 
                    ? ".zip" 
                    : _extensaoBackup);

                nomeArquivoNoUpload = _compactado 
                    ? _uidRotina + ".zip" 
                    : _uidRotina + _extensaoBackup;
            }
            else
            {
                arquivoParaUpload = arquivoReplicacaoDeDados;
                nomeArquivoNoUpload = Path.GetFileName(arquivoReplicacaoDeDados);
            }
                      


            FtpClient client = new FtpClient(_host, portaFTP, 
                new NetworkCredential(_usuario, _senha));

            client.EncryptionMode = FtpEncryptionMode.Explicit;

            client.ValidateCertificate += Client_ValidateCertificate;

            try
            {

                client.AutoConnect();

                if (!_isTesteUpload)
                    client.UploadFile(arquivoParaUpload, string.Format("{0}/{1}", _diretorioUploadRemoto, nomeArquivoNoUpload));
                else
                    client.UploadFile(_arquivoTesteUpload, string.Format("{0}/{1}", _diretorioUploadRemoto, _arquivoTesteUpload.Split('\\')[2].ToString()));

            }
            catch (Exception ex)
            {

                if (!_isTesteUpload && _isRotinaBackup)
                {
                    Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", 
                        _isRotinaBackup 
                        ? _diretorioBackup
                        : _diretorioLogErrosReplicacaoDeDados, 
                        _uidRotina),
                    string.Format("Erro ao Realizar o Upload para o FTP.\n\nException: {0}\n\nInnerException: {1}",
                    ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                client.Disconnect();
            }
        }

        private void Client_ValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
        {
            e.Accept = true;
        }
    }
}
