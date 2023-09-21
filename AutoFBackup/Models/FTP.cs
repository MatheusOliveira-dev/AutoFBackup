using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CredenciaisFTP
    {
        public string Host { get; set; }
        public string Porta { get; set; }
        public bool Passivo { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }

    public class ExcluirBackupsAntigosFTP
    {
        public bool HabilitarExclusaoExtensoesDifFbk { get; set; }
        public bool Ativo { get; set; }
        public string Dias { get; set; }
    }

    public class OpcoesFTP
    {
        public ExcluirBackupsAntigosFTP ExcluirBackupsAntigos { get; set; }
    }

    public class EnvioFTP
    {
        public string Diretorio { get; set; }
        public OpcoesFTP Opcoes { get; set; }
    }

    public class RootFTP
    {
        public CredenciaisFTP Credenciais { get; set; }
        public EnvioFTP Envio { get; set; }
    }


}
