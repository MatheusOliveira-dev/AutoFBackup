using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Web.MegaApiClient;

namespace MegaNZ
{
    public class Upload
    {
        public void ExecutaUpload(string email, string senha, string pasta, 
            string diretorioBackups, string uidRotinaBackup, bool compactado, string extensaoBackup,
            bool isTesteUpload = false, string arquivoTesteUpload = "")
        {

            string backupParaUpload = string.Format(@"{0}\{1}", diretorioBackups, uidRotinaBackup);

            if (compactado)
            {
                backupParaUpload += ".zip";
            }
            else
            {
                backupParaUpload += extensaoBackup;
            }

            MegaApiClient client = new MegaApiClient();

            try
            {
                client.Login(email, senha);

                IEnumerable<INode> nodes = client.GetNodes().ToList();
                INode myFolder = nodes.Where(x => x.Type == NodeType.Directory && x.Name.Trim().ToLower() == pasta.Trim().ToLower()).FirstOrDefault();
                INode myFile = client.UploadFile( isTesteUpload ? arquivoTesteUpload : backupParaUpload, myFolder);

            }
            catch (Exception ex)
            {
                if (!isTesteUpload)
                {
                    Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackups, uidRotinaBackup),
                    string.Format("Erro ao Realizar o Upload do Backup para o Mega.nz.\n\nException: {0}\n\nInnerException: {1}",
                    ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                }
                else
                {
                    throw ex;
                }

            }
            finally
            {
                if (client.IsLoggedIn)
                    client.Logout();
            }
        }
    }
}
