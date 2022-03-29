using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Email
    {
        public class CredenciaisEmail
        {
            public string Host { get; set; }
            public string Porta { get; set; }
            public bool SSL { get; set; }
            public string Usuario { get; set; }
            public string Senha { get; set; }
        }

        public class OpcoesEmail
        {
            public bool ReceberLogTxt { get; set; }
            public bool ReceberEmailErros { get; set; }
        }

        public class EnvioEmail
        {
            public string Assunto { get; set; }
            public string Destinatarios { get; set; }
            public OpcoesEmail Opcoes { get; set; }
        }

        public class RootEmail
        {
            public CredenciaisEmail Credenciais { get; set; }
            public EnvioEmail Envio { get; set; }
        }

    }
}
