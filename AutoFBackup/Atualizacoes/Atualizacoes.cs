using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBackup.Atualizacoes
{
    public class Atualizacoes
    {
        public Atualizacoes()
        {
            
        }
        public void AtualizaAplicacao()
        {
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Mandatory = true;
            AutoUpdater.Start("https://raw.githubusercontent.com/MatheusOliveira-dev/AutoFBackupUpdater/main/Update.xml");

            AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent;
        }

        private void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    DialogResult dialogResult;
                    if (args.Mandatory.Value)
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"Há uma nova versão ({args.CurrentVersion}) disponível. Clique em Ok para iniciar o processo de Download e Instalação .", @"Versão Disponível",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"Há uma nova versão ({args.CurrentVersion}) disponível. Deseja iniciar o processo de Download e Instalação agora?", @"Versão Disponível",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);
                    }



                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {

                        if (MessageBox.Show(
                                "Você deseja visualizar os recursos corrigidos/implementados/alterados nessa Versão?", @"Changelog",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            AutoUpdater.ShowUpdateForm(args);
                        };

                        try
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"Nenhuma nova Versão disponível. Você já está executando a Última Versão do AutoFBackup.", @"Última Versão já instalada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (args.Error is WebException)
                {
                    MessageBox.Show(
                        @"Erro ao Obter a Última Versão disponível. Por favor, verifique sua conexão à internet e tente novamente.",
                        @"Erro ao Obter a Última Versão disponível", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(args.Error.Message,
                        args.Error.GetType().ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
