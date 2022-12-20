using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace FTP
{
    public class Delete
    {
       

        public void ExcluiBackupsAntigos(string host, string porta, string usuario,
            string senha, string diretorioBackupsRemoto, string diasExcluir, 
            string uidRotinaBackup, string diretorioBackupsLocal)
        {

            int portaFTP = Shared.Helpers.ConverteStringParaNumero(porta);

            if (portaFTP == 0)
            {
                portaFTP = 21;

                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackupsLocal, uidRotinaBackup),
                "[!] Porta 0 detectada para o FTP (Upload do Arquivo de Backup para o FTP). O AutoFBackup tentará utilizar a porta padrão (21)");
            }


            FtpClient client = new FtpClient(host, portaFTP,
                new NetworkCredential(usuario, senha));

            client.EncryptionMode = FtpEncryptionMode.Explicit;

            client.ValidateCertificate += Client_ValidateCertificate;

            int _diasExcluir = Shared.Helpers.ConverteStringParaNumero(diasExcluir);

            try
            {
                if (_diasExcluir > 0)
                {
                    foreach (FtpListItem item in client.GetListing(diretorioBackupsRemoto))
                    {

                        if (item.Type == FtpFileSystemObjectType.File)
                        {
                            if ((client.GetModifiedTime(item.FullName) < DateTime.Now.AddDays(-_diasExcluir)) &&
                                (item.FullName.ToLower().EndsWith("zip") ||
                                item.FullName.ToLower().EndsWith("fbk")))
                            {
                                client.DeleteFile(item.FullName);
                            }
                        }
                    }
                }
                else
                {
                    Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackupsLocal, uidRotinaBackup),
                    string.Format("Exclusão de Backups antigos no FTP abortado -> {0}", "Regra de Exclusão igual a 0"));
                }

                
            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackupsLocal, uidRotinaBackup),
                    string.Format("Erro na Exclusão de Backups antigos no FTP -> {0}", ex.Message));
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
