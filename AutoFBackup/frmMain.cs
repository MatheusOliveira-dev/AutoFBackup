using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            {
                this.WindowState = FormWindowState.Minimized;
            }
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

                    btnDashboard.PerformClick();
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

            Re_InicializaRotinas = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlControls.Controls.Clear();

            UCDashboard uCDashboard = new UCDashboard(this);
            pnlControls.Controls.Add(uCDashboard);
        }

        private void btnIntegracoes_Click(object sender, EventArgs e)
        {
            pnlControls.Controls.Clear();

            UCIntegracoes uCIntegracoes = new UCIntegracoes();
            pnlControls.Controls.Add(uCIntegracoes);
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            pnlControls.Controls.Clear();

            UCConfiguracoes uCConfiguracoes = new UCConfiguracoes();

            pnlControls.Controls.Add(uCConfiguracoes);
        }

        private void btnNovoBackup_Click(object sender, EventArgs e)
        {
            frmNovoBackup frmNovoBackup = new frmNovoBackup(this);
            frmNovoBackup.ShowDialog();
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja Fechar o AutoFBackup? As Rotinas Agendadas não Serão Executadas.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
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
    }
}
