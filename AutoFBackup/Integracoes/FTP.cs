using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft;
using Newtonsoft.Json;

namespace Integracoes
{
    public class FTP
    {
        public RootFTP ObtemIntegracaoFTP()
        {
            RootFTP ftp = null;

            if (Shared.Helpers.VerificaArquivoExistente(@"Integracoes\ftp.json"))
            {
                ftp = JsonConvert.DeserializeObject<RootFTP>(Shared.Helpers.LeArquivo(@"Integracoes\ftp.json"));
            }

            return ftp;
        }
        public void CriaAtualizaIntegracaoFTP(RootFTP rootFTP)
        {
            Shared.Helpers.CriaArquivo(@"Integracoes\ftp.json", JsonConvert.SerializeObject(rootFTP));
        }

        public void ExcluiIntegracaoFTP()
        {
            Shared.Helpers.ExcluiArquivo(@"Integracoes\ftp.json");
        }
    }
}
