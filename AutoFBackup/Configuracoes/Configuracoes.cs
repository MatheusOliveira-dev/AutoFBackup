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
                ExecutaGfixConfiguracoes executaGfixConfiguracoes = new ExecutaGfixConfiguracoes();
                BackupsConfiguracoes backupsConfiguracoes = new BackupsConfiguracoes();

                geralConfiguracoes.BuscaAtualizacaoIniApp = true;
                geralConfiguracoes.IniciarComOWindows = false;
                geralConfiguracoes.BloquearMultiplasInstancias = false;
                geralConfiguracoes.ExibirConteudoRecomendado = false;
                geralConfiguracoes.ExigirSenhaAcessoBotoes = false;
                geralConfiguracoes.SenhaAcessoBotoes = string.Empty;
                geralConfiguracoes.ExigirSenhaFecharApp = false;
                geralConfiguracoes.SenhaFecharApp = string.Empty;

                aplicativoPreBackupConfiguracoes.Aplicativo = "";
                aplicativoPreBackupConfiguracoes.Argumentos = "";

                aplicativoPosBackupConfiguracoes.Aplicativo = "";
                aplicativoPosBackupConfiguracoes.Argumentos = "";

                excluirBackupsAntigosLocalConfiguracoes.Ativo = false;
                excluirBackupsAntigosLocalConfiguracoes.Dias = "0";

                executaGfixConfiguracoes.Ativo = false;
                executaGfixConfiguracoes.CaminhoGfix = "";
                executaGfixConfiguracoes.ArgumentosGfix = "-mend -full -ignore";

                backupsConfiguracoes.DiretorioBackups = $"{Application.StartupPath}\\Backups";

                List<string> flagsBackup = new List<string>
                {
                    "NoGarbageCollect",
                    "IgnoreLimbo",
                    "IgnoreChecksums"
                };

                rootConfiguracoes.Geral = geralConfiguracoes;
                backupsConfiguracoes.AplicativoPreBackup = aplicativoPreBackupConfiguracoes;
                backupsConfiguracoes.AplicativoPosBackup = aplicativoPosBackupConfiguracoes;
                backupsConfiguracoes.ExcluirBackupsAntigosLocal = excluirBackupsAntigosLocalConfiguracoes;
                backupsConfiguracoes.ExecutaGfix = executaGfixConfiguracoes;
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
