using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using FBackup.Enums;
using FluentScheduler;
using Models;
using Newtonsoft.Json;
using static Models.Backup;

namespace FBackup
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            this.AplicaArgumentos();

            InicializaApp();
        }

        private void AplicaArgumentos()
        {
            if (Program.iniciarMinimizado)
            {
                this.WindowState = FormWindowState.Minimized;
                AplicaConfiguracoesMinimizaApp();
            }
              
            
            if (!string.IsNullOrWhiteSpace(Program.arquivoJSONRotinaBackup))
            {
                if (!File.Exists(Program.arquivoJSONRotinaBackup))
                    Environment.Exit(1);

                this.Opacity = 0;
                this.ShowInTaskbar = false;
                this.ShowIcon = false;

                Root_Backup root_Backup = JsonConvert.DeserializeObject<Root_Backup>(Shared.Helpers.LeArquivo(Program.arquivoJSONRotinaBackup));

                Rotinas.Rotinas.ExecutaJobRotina executaJobBackup = new Rotinas.Rotinas.ExecutaJobRotina(root_Backup, true);

                Task task = Task.Run(() => executaJobBackup.Execute());

                task.Wait();

                Environment.Exit(0);

            }
            
        }

        public bool Re_InicializaRotinas 
        {
            set
            {
                if (value)
                {
                    JobManager.RemoveAllJobs();

                    Rotinas.Rotinas rotinas = new Rotinas.Rotinas();
                    JobManager.Initialize(new Rotinas.Rotinas.RegistroTarefasAgendadas(rotinas.ObtemArquivosRotinas()));

                    Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

                    if (!Configuracoes.ObtemConfiguracoes().Geral.ExigirSenhaAcessoBotoes || string.IsNullOrWhiteSpace(Configuracoes.ObtemConfiguracoes().Geral.SenhaAcessoBotoes))
                    {
                        btnDashboard.PerformClick();
                    }   
                }
            }
        }

        private void InicializaApp()
        {

            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();
            Configuracoes.CriaConfiguracoesPadraoSeNecessario();

            if (Configuracoes.ObtemConfiguracoes() != null && Configuracoes.ObtemConfiguracoes().Geral.BloquearMultiplasInstancias && !Program.emModoCLI)
            {
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    MessageBox.Show("Já existe uma Instância do Aplicativo em Execução.\n\nFechando...", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (Application.MessageLoop)
                        Application.Exit();
                    else
                        Environment.Exit(1);
                }
            }

            lblVersaoAutoFBackup.Text = Shared.Helpers.ObtemVersaoAutoFBackup();

            Shared.Helpers.CriaDiretorio("Integracoes");
            Shared.Helpers.CriaDiretorio("Rotinas");
            Shared.Helpers.CriaDiretorio("Backups");
            Shared.Helpers.CriaDiretorio(@"TestesIntegracoes\MegaNZ");
            Shared.Helpers.CriaDiretorio(@"TestesIntegracoes\FTP");


            Shared.Helpers.HabilitaDesabilitaInicializacaoComWindows(Configuracoes.ObtemConfiguracoes().Geral.IniciarComOWindows);

            if (Configuracoes.ObtemConfiguracoes() != null && Configuracoes.ObtemConfiguracoes().Geral.BuscaAtualizacaoIniApp && !Program.emModoCLI)
            {
                Atualizacoes.Atualizacoes atualizacoes = new Atualizacoes.Atualizacoes();
                atualizacoes.AtualizaAplicacao();
            }

            if (!Program.emModoCLI)
                Re_InicializaRotinas = true;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();
            pnlConteudoRecomendado.Visible = Configuracoes.ObtemConfiguracoes().Geral.ExibirConteudoRecomendado;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

            if (Configuracoes.ObtemConfiguracoes().Geral.ExigirSenhaAcessoBotoes && !string.IsNullOrWhiteSpace(Configuracoes.ObtemConfiguracoes().Geral.SenhaAcessoBotoes))
            {


                using (frmSenhaAcesso frmSenhaAcesso = new frmSenhaAcesso(TipoAcessos.Botao))
                {
                    DialogResult dr = frmSenhaAcesso.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        pnlControls.Controls.Clear();

                        UCDashboard uCDashboard = new UCDashboard(this);
                        pnlControls.Controls.Add(uCDashboard);
                    }
                }
            }
            else
            {
                pnlControls.Controls.Clear();

                UCDashboard uCDashboard = new UCDashboard(this);
                pnlControls.Controls.Add(uCDashboard);
            }
           
        }

        private void btnIntegracoes_Click(object sender, EventArgs e)
        {
            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

            if (Configuracoes.ObtemConfiguracoes().Geral.ExigirSenhaAcessoBotoes && !string.IsNullOrWhiteSpace(Configuracoes.ObtemConfiguracoes().Geral.SenhaAcessoBotoes))
            {
                using (frmSenhaAcesso frmSenhaAcesso = new frmSenhaAcesso(TipoAcessos.Botao))
                {
                    DialogResult dr = frmSenhaAcesso.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        pnlControls.Controls.Clear();

                        UCIntegracoes uCIntegracoes = new UCIntegracoes();
                        pnlControls.Controls.Add(uCIntegracoes);
                    }
                }
            }
            else
            {
                pnlControls.Controls.Clear();

                UCIntegracoes uCIntegracoes = new UCIntegracoes();
                pnlControls.Controls.Add(uCIntegracoes);
            }

        
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

            if (Configuracoes.ObtemConfiguracoes().Geral.ExigirSenhaAcessoBotoes && !string.IsNullOrWhiteSpace(Configuracoes.ObtemConfiguracoes().Geral.SenhaAcessoBotoes))
            {
                using (frmSenhaAcesso frmSenhaAcesso = new frmSenhaAcesso(TipoAcessos.Botao))
                {
                    DialogResult dr = frmSenhaAcesso.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        pnlControls.Controls.Clear();

                        UCConfiguracoes uCConfiguracoes = new UCConfiguracoes();

                        pnlControls.Controls.Add(uCConfiguracoes);
                    }
                }
            }
            else
            {
                pnlControls.Controls.Clear();

                UCConfiguracoes uCConfiguracoes = new UCConfiguracoes();

                pnlControls.Controls.Add(uCConfiguracoes);
            }

           
        }

        private void btnNovoBackup_Click(object sender, EventArgs e)
        {
            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

            if (Configuracoes.ObtemConfiguracoes().Geral.ExigirSenhaAcessoBotoes && !string.IsNullOrWhiteSpace(Configuracoes.ObtemConfiguracoes().Geral.SenhaAcessoBotoes))
            {
                using (frmSenhaAcesso frmSenhaAcesso = new frmSenhaAcesso(TipoAcessos.Botao))
                {
                    DialogResult drSenhaAcesso = frmSenhaAcesso.ShowDialog();

                    if (drSenhaAcesso == DialogResult.OK)
                    {
                        frmEscolhaTipoRotina frmEscolhaTipoRotina = new frmEscolhaTipoRotina(this);
                        frmEscolhaTipoRotina.ShowDialog();
                    }
                }
            }
            else
            {
                frmEscolhaTipoRotina frmEscolhaTipoRotina = new frmEscolhaTipoRotina(this);
                frmEscolhaTipoRotina.ShowDialog();
            }
        }

        private void lblSair_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Tem certeza que deseja Fechar o AutoFBackup? As Rotinas Agendadas não Serão Executadas.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

                if (Configuracoes.ObtemConfiguracoes().Geral.ExigirSenhaFecharApp && !string.IsNullOrWhiteSpace(Configuracoes.ObtemConfiguracoes().Geral.SenhaFecharApp))
                {
                    using (frmSenhaAcesso frmSenhaAcesso = new frmSenhaAcesso(TipoAcessos.Fechar))
                    {
                        DialogResult dr = frmSenhaAcesso.ShowDialog();

                        if (dr == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    Application.Exit();
                }

            }
        }

        private void lblMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon.Visible = false;
        }

        private void AplicaConfiguracoesMinimizaApp()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon.Visible = true;

                notifyIcon.Icon = SystemIcons.Application;
                notifyIcon.BalloonTipText = "O AutoFBackup Continuará Sendo Executado em Segundo Plano.";
                notifyIcon.ShowBalloonTip(1000);
                this.Hide();

                Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

                if (Configuracoes.ObtemConfiguracoes().Geral.ExigirSenhaAcessoBotoes && !string.IsNullOrWhiteSpace(Configuracoes.ObtemConfiguracoes().Geral.SenhaAcessoBotoes))
                    this.pnlControls.Controls.Clear();
            }
        }
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            AplicaConfiguracoesMinimizaApp();
        }

        private void lblEdsonGregorio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/egmqfs/");
        }

        private void lblMQFSFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/groups/mqFirebirdSQL/");
        }

        private void lblMQFSYoutube_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/c/MeuqueridoFirebirdSQL");
        }

        private void lblAutoFBackupWiki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/MatheusOliveira-dev/AutoFBackup/wiki/1.-In%C3%ADcio");
        }

        private void lblAutoFBackupVersoes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/MatheusOliveira-dev/AutoFBackup/releases");
        }

        private void btnAtualizarApp_Click(object sender, EventArgs e)
        {
            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

            if (Configuracoes.ObtemConfiguracoes().Geral.ExigirSenhaAcessoBotoes 
                && !string.IsNullOrWhiteSpace(Configuracoes.ObtemConfiguracoes().Geral.SenhaAcessoBotoes))
            {
                using (frmSenhaAcesso frmSenhaAcesso = new frmSenhaAcesso(TipoAcessos.Botao))
                {
                    DialogResult dr = frmSenhaAcesso.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        frmAtualizaApp frmAtualizaApp = new frmAtualizaApp();
                        frmAtualizaApp.Show();
                    }
                }
            }
            else
            {
                frmAtualizaApp frmAtualizaApp = new frmAtualizaApp();
                frmAtualizaApp.Show();
            }

          
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                if (Configuracoes.ObtemConfiguracoes().Geral.ExigirSenhaFecharApp && !string.IsNullOrWhiteSpace(Configuracoes.ObtemConfiguracoes().Geral.SenhaFecharApp))
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
