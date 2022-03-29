using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void InicializaApp()
        {
            lblVersaoAutoFBackup.Text = Shared.Helpers.ObtemVersaoAutoFBackup();

            Shared.Helpers.CriaDiretorio("Integracoes");
            Shared.Helpers.CriaDiretorio("Rotinas");

            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();
            Configuracoes.CriaConfiguracoesPadraoSeNecessario();

            Backup.Backup backup = new Backup.Backup();
            JobManager.Initialize(new RegistroTarefasAgendadas(backup.ObtemRotinasBackups()));

            
        }


        private void CarregaConfiguracoes()
        {
            Configuracoes.Configuracoes configuracoes = new Configuracoes.Configuracoes();
            RootConfiguracoes rootConfiguracoes = configuracoes.ObtemConfiguracoes();

            Shared.Helpers.HabilitaDesabilitaInicializacaoComWindows(rootConfiguracoes.Geral.IniciarComOWindows);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InicializaApp();

            UCDashboard uCDashboard = new UCDashboard();
            pnlControls.Controls.Add(uCDashboard);

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlControls.Controls.Clear();

            UCDashboard uCDashboard = new UCDashboard();
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
            frmNovoBackup frmNovoBackup = new frmNovoBackup();
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
    }
}
