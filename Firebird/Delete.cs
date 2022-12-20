using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebird
{
    public class Delete
    {
        public void ExcluiBackupsAntigos(string diretorioBackups, string diasExcluir, string uidRotinaBackup)
        {

            try
            {
                List<string> listArquivosBackup = Shared.Helpers.ObtemArquivosDiretorio(diretorioBackups, "*.zip, *.fbk");

                int _diasExcluir = Shared.Helpers.ConverteStringParaNumero(diasExcluir);

                if (_diasExcluir > 0)
                {
                    foreach (string arquivoBackup in listArquivosBackup)
                    {
                        FileInfo fileInfo = new FileInfo(arquivoBackup);

                        if (fileInfo.LastWriteTime < DateTime.Now.AddDays(-_diasExcluir))
                        {
                            fileInfo.Delete();
                        }
                    }
                }
                else
                {
                    Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackups, uidRotinaBackup),
                    string.Format("Exclusão de Backups antigos no diretório local abortado -> {0}", "Regra de Exclusão igual a 0"));
                }
            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackups, uidRotinaBackup),
                    string.Format("Erro na Exclusão de Backups antigos no diretório local -> {0}", ex.Message));
            }

        }
    }
}
