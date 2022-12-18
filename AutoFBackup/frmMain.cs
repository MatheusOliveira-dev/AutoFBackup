using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using FBackup.Enums;
using FluentScheduler;
using Models;
using static Backup.Backup;
using static Models.Backup;

namespace FBackup
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            InicializaApp();

            this.AplicaArgumentos();
        }

        private void AplicaArgumentos()
        {
            if (Program.iniciarMinimizado)
                this.WindowState = FormWindowState.Minimized;
            
        }

        public bool Re_InicializaRotinas 
        {
            set
            {
                if (value)
                {

                    JobManager.RemoveAllJobs();

                    Backup.Backup backup = new Backup.Backup();
                    JobManager.Initialize(new RegistroTarefasAgendadas(backup.ObtemRotinasBackups()));


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
            lblVersaoAutoFBackup.Text = Shared.Helpers.ObtemVersaoAutoFBackup();

            Shared.Helpers.CriaDiretorio("Integracoes");
            Shared.Helpers.CriaDiretorio("Rotinas");

            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();
            Configuracoes.CriaConfiguracoesPadraoSeNecessario();

            Shared.Helpers.HabilitaDesabilitaInicializacaoComWindows(Configuracoes.ObtemConfiguracoes().Geral.IniciarComOWindows);

            if (Configuracoes.ObtemConfiguracoes() != null && Configuracoes.ObtemConfiguracoes().Geral.BuscaAtualizacaoIniApp)
            {
                Atualizacoes.Atualizacoes atualizacoes = new Atualizacoes.Atualizacoes();
                atualizacoes.AtualizaAplicacao();
            }

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
                    DialogResult dr = frmSenhaAcesso.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        frmNovoBackup frmNovoBackup = new frmNovoBackup(this);
                        frmNovoBackup.ShowDialog();
                    }
                }
            }
            else
            {
                frmNovoBackup frmNovoBackup = new frmNovoBackup(this);
                frmNovoBackup.ShowDialog();
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

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon.Visible = true;

                notifyIcon.Icon = SystemIcons.Shield;
                notifyIcon.BalloonTipText = "O AutoFBackup Continuará Sendo Executado em Segundo Plano.";
                notifyIcon.ShowBalloonTip(1000);
                this.Hide();
            }
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
            frmAtualizaApp frmAtualizaApp = new frmAtualizaApp();
            frmAtualizaApp.Show();
        }
    }
}
