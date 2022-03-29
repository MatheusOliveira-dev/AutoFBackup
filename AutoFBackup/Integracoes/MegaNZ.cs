using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracoes
{
    public class MegaNZ
    {
        public RootMegaNZ ObtemIntegracaoMegaNZ()
        {
            RootMegaNZ meganz = null;

            if (Shared.Helpers.VerificaArquivoExistente(@"Integracoes\meganz.json"))
            {
                meganz = JsonConvert.DeserializeObject<RootMegaNZ>(Shared.Helpers.LeArquivo(@"Integracoes\meganz.json"));
            }

            return meganz;
        }
        public void CriaAtualizaIntegracaoMegaNZ(RootMegaNZ rootMegaNZ)
        {
            Shared.Helpers.CriaArquivo(@"Integracoes\meganz.json", JsonConvert.SerializeObject(rootMegaNZ));
        }

        public void ExcluiIntegracaoMegaNZ()
        {
            Shared.Helpers.ExcluiArquivo(@"Integracoes\meganz.json");
        }
    }
}
