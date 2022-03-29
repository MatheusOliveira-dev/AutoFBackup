using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CredenciaisMegaNZ
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class EnvioMegaNZ
    {
        public string Pasta { get; set; }
    }

    public class RootMegaNZ
    {
        public CredenciaisMegaNZ Credenciais { get; set; }
        public EnvioMegaNZ Envio { get; set; }
    }
}
