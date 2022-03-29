using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Newtonsoft.Json;

namespace Configuracoes
{
    public class Configuracoes
    {
        public void CriaConfiguracoesPadraoSeNecessario()
        {
            if (!Shared.Helpers.VerificaArquivoExistente("configuracoes.json"))
            {
                RootConfiguracoes rootConfiguracoes = new RootConfiguracoes();
                Geral geralConfiguracoes = new Geral();
                AplicativoPreBackupConfiguracoes aplicativoPreBackupConfiguracoes = new AplicativoPreBackupConfiguracoes();
                AplicativoPosBackupConfiguracoes aplicativoPosBackupConfiguracoes = new AplicativoPosBackupConfiguracoes();
                ExcluirBackupsAntigosLocalConfiguracoes excluirBackupsAntigosLocalConfiguracoes = new ExcluirBackupsAntigosLocalConfiguracoes();
                BackupsConfiguracoes backupsConfiguracoes = new BackupsConfiguracoes();

                geralConfiguracoes.BuscaAtualizacaoIniApp = true;
                geralConfiguracoes.IniciarComOWindows = false;

                aplicativoPreBackupConfiguracoes.Aplicativo = "";
                aplicativoPreBackupConfiguracoes.Argumentos = "";

                aplicativoPosBackupConfiguracoes.Aplicativo = "";
                aplicativoPosBackupConfiguracoes.Argumentos = "";

                excluirBackupsAntigosLocalConfiguracoes.Ativo = false;
                excluirBackupsAntigosLocalConfiguracoes.Dias = "0";

                backupsConfiguracoes.DiretorioBackups = Application.StartupPath;

                List<string> flagsBackup = new List<string>();
                flagsBackup.Add("NoGarbageCollect");
                flagsBackup.Add("IgnoreLimbo");
                flagsBackup.Add("IgnoreChecksums");

                rootConfiguracoes.Geral = geralConfiguracoes;
                backupsConfiguracoes.AplicativoPreBackup = aplicativoPreBackupConfiguracoes;
                backupsConfiguracoes.AplicativoPosBackup = aplicativoPosBackupConfiguracoes;
                backupsConfiguracoes.ExcluirBackupsAntigosLocal = excluirBackupsAntigosLocalConfiguracoes;
                backupsConfiguracoes.FlagsBackup = flagsBackup;
                rootConfiguracoes.Backups = backupsConfiguracoes;

                this.CriaAtualizaConfiguracoes(rootConfiguracoes);

            }
        }

        public RootConfiguracoes ObtemConfiguracoes()
        {
            RootConfiguracoes configuracoes = JsonConvert.DeserializeObject<RootConfiguracoes>(Shared.Helpers.LeArquivo("configuracoes.json"));

            return configuracoes;
        }
        public void CriaAtualizaConfiguracoes(RootConfiguracoes rootConfiguracoes)
        {
            Shared.Helpers.CriaArquivo("configuracoes.json", JsonConvert.SerializeObject(rootConfiguracoes));
        }
    }
}
