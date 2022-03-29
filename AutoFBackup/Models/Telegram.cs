using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CredenciaisTelegram
    {
        public string AccessTokenBot { get; set; }
    }

    public class OpcoesTelegram
    {
        public bool ReceberLogTxt { get; set; }
        public bool ReceberNotificacaoErros { get; set; }
    }

    public class EnvioTelegram
    {
        public string ChatIDDestino { get; set; }
        public OpcoesTelegram Opcoes { get; set; }
    }

    public class RootTelegram
    {
        public CredenciaisTelegram Credenciais { get; set; }
        public EnvioTelegram Envio { get; set; }
    }
}
