using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP
{
    public class Upload
    {
        public void ExecutaUpload(string host, string porta, string usuario,
            string senha, string diretorioUploadRemoto, string uidRotinaBackup, string diretorioBackups, 
            bool compactado, bool isTesteUpload = false, string arquivoTesteUpload = "")
        {
            string backupParaUpload = string.Format(@"{0}\{1}{2}", diretorioBackups, uidRotinaBackup, compactado ? ".zip" : ".fbk");
            string nomeBackupUpload = compactado ? uidRotinaBackup + ".zip" : uidRotinaBackup + ".fbk";

            int portaFTP = Shared.Helpers.ConverteStringParaNumero(porta);

            if (portaFTP == 0)
            {
                portaFTP = 21;

                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackups, uidRotinaBackup),
                "[!] Porta 0 detectada para o FTP (Exclusão de Arquivos de Backup antigos no FTP). O AutoFBackup tentará utilizar a porta padrão (21)");
            }


            FtpClient client = new FtpClient(host, portaFTP, 
                new NetworkCredential(usuario, senha));

            client.EncryptionMode = FtpEncryptionMode.Explicit;

            client.ValidateCertificate += Client_ValidateCertificate;

            try
            {

                client.AutoConnect();

                if (!isTesteUpload)
                    client.UploadFile(backupParaUpload, string.Format("{0}/{1}", diretorioUploadRemoto, nomeBackupUpload));
                else
                    client.UploadFile(arquivoTesteUpload, string.Format("{0}/{1}", diretorioUploadRemoto, arquivoTesteUpload.Split('\\')[2].ToString()));

            }
            catch (Exception ex)
            {

                if (!isTesteUpload)
                {
                    Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackups, uidRotinaBackup),
                    string.Format("Erro ao Realizar o Upload do Backup para o FTP.\n\nException: {0}\n\nInnerException: {1}",
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
