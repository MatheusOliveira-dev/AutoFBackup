using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using static Models.Email;

namespace Integracoes
{
    public class Email
    {
        public RootEmail ObtemIntegracaoEmail()
        {
            RootEmail email = null;

            if (Shared.Helpers.VerificaArquivoExistente(@"Integracoes\email.json"))
            {
                email = JsonConvert.DeserializeObject<RootEmail>(Shared.Helpers.LeArquivo(@"Integracoes\email.json"));
            }

            return email;
        }
        public void CriaAtualizaIntegracaoEmail(RootEmail rootEmail)
        {
            Shared.Helpers.CriaArquivo(@"Integracoes\email.json", JsonConvert.SerializeObject(rootEmail));
        }

        public void ExcluiIntegracaoEmail()
        {
            Shared.Helpers.ExcluiArquivo(@"Integracoes\email.json");
        }

    }
}
