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

            FtpClient client = new FtpClient(host, Shared.Helpers.ConverteStringParaNumero(porta),
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
                    string.Format("Erro ao Exclusão de Backups antigos no FTP -> {0}", ex.Message));
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
