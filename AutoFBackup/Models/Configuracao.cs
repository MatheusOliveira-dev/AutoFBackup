using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Geral
    {
        public bool BuscaAtualizacaoIniApp { get; set; }
        public bool IniciarComOWindows { get; set; }
    }

    public class AplicativoPreBackupConfiguracoes
    {
        public string Aplicativo { get; set; }
        public string Argumentos { get; set; }
    }

    public class AplicativoPosBackupConfiguracoes
    {
        public string Aplicativo { get; set; }
        public string Argumentos { get; set; }
    }

    public class ExcluirBackupsAntigosLocalConfiguracoes
    {
        public bool Ativo { get; set; }
        public string Dias { get; set; }
    }

    public class BackupsConfiguracoes
    {
        public string DiretorioBackups { get; set; }
        public List<string> FlagsBackup { get; set; }
        public AplicativoPreBackupConfiguracoes AplicativoPreBackup { get; set; }
        public AplicativoPosBackupConfiguracoes AplicativoPosBackup { get; set; }
        public ExcluirBackupsAntigosLocalConfiguracoes ExcluirBackupsAntigosLocal { get; set; }
    }

    public class RootConfiguracoes
    {
        public Geral Geral { get; set; }
        public BackupsConfiguracoes Backups { get; set; }
    }
}
