using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebird
{
    public class Gfix
    {
        private string _usuarioBancoDeDados = string.Empty;
        private string _senhaBancoDeDados = string.Empty;
        private string _servidorBancoDeDados = string.Empty;
        private string _caminhoBancoDeDados = string.Empty;
        private string _caminhoGfix;
        private string _argumentosGfix;
        private string _uidRotinaBackup;
        private string _diretorioBackups;

        public Gfix(string usuarioBancoDeDados, string senhaBancoDeDados,
                string servidorBancoDeDados, string caminhoBancoDeDados, string caminhoGfix, string argumentosGfix,
            string uidRotinaBackup, string diretorioBackups)
        {
            _usuarioBancoDeDados = usuarioBancoDeDados;
            _senhaBancoDeDados = senhaBancoDeDados;
            _servidorBancoDeDados = servidorBancoDeDados;
            _caminhoBancoDeDados = caminhoBancoDeDados;
            _caminhoGfix = caminhoGfix;
            _argumentosGfix = argumentosGfix;
            _uidRotinaBackup = uidRotinaBackup;
            _diretorioBackups = diretorioBackups;
        }

        public void ExecutaGfix()
        {
            if (!File.Exists(_caminhoGfix))
            {

                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
                string.Format("Execução do Gfix abortado -> {0}", "O Caminho do Gfix não foi Informado."));
                return;
            }

            if (string.IsNullOrWhiteSpace(_argumentosGfix))
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
               string.Format("Execução do Gfix abortado -> {0}", "Nenhum Argumento Informado para o GFIX."));
                return;
            }

            try
            {
                Process aplicativoProcesso = new Process();

                aplicativoProcesso.StartInfo.CreateNoWindow = false;
                aplicativoProcesso.StartInfo.UseShellExecute = false;
                aplicativoProcesso.StartInfo.FileName = _caminhoGfix;
                aplicativoProcesso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                aplicativoProcesso.StartInfo.Arguments = _argumentosGfix;

                aplicativoProcesso.StartInfo.Arguments += string.Format(" {0} -user {1} -password {2}", _caminhoBancoDeDados, _usuarioBancoDeDados, _senhaBancoDeDados);

                aplicativoProcesso.Start();

                aplicativoProcesso.WaitForExit();

            }
            catch (Exception ex)
            {
                Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
                    string.Format("Erro na Execução do Gfix -> {0}", ex.Message));
            }
        }
    }
}
