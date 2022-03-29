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
            string diretorioBackups, string uidRotinaBackup, bool compactado)
        {

            string backupParaUpload = string.Format(@"{0}\{1}", diretorioBackups, uidRotinaBackup);

            if (compactado)
            {
                backupParaUpload += ".zip";
            }
            else
            {
                backupParaUpload += ".fbk";
            }

            MegaApiClient client = new MegaApiClient();

            try
            {
                client.Login(email, senha);

                IEnumerable<INode> nodes = client.GetNodes();

                List<INode> megaFolders = nodes.Where(n => n.Type == NodeType.Directory).ToList();

                INode myFolderOnMega = megaFolders.Where(folder => folder.Name == pasta).FirstOrDefault();

                INode root = nodes.Single(x => x.Type == NodeType.Root);

                INode myFile = client.UploadFile(backupParaUpload, myFolderOnMega);
            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackups, uidRotinaBackup),
                    string.Format("Erro ao Realizar o Upload do Backup para o Mega.nz -> {0}", ex.Message));
            }
            finally
            {
                client.Logout();
            }
        }
    }
}
