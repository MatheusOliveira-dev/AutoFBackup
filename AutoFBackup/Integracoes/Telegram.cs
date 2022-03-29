using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracoes
{
    public class Telegram
    {
        public RootTelegram ObtemIntegracaoTelegram()
        {
            RootTelegram telegram = null;

            if (Shared.Helpers.VerificaArquivoExistente(@"Integracoes\telegram.json"))
            {
                telegram = JsonConvert.DeserializeObject<RootTelegram>(Shared.Helpers.LeArquivo(@"Integracoes\telegram.json"));
            }

            return telegram;
        }
        public void CriaAtualizaIntegracaoTelegram(RootTelegram rootTelegram)
        {
            Shared.Helpers.CriaArquivo(@"Integracoes\telegram.json", JsonConvert.SerializeObject(rootTelegram));
        }

        public void ExcluiIntegracaoTelegram()
        {
            Shared.Helpers.ExcluiArquivo(@"Integracoes\telegram.json");
        }
    }
}
