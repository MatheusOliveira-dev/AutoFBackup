using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
namespace FBackup
{
    public partial class UCConfiguracoes : UserControl
    {
        public UCConfiguracoes()
        {
            InitializeComponent();
            tbControl.SelectedIndex = 0;
        }

        private void CarregaConfiguracoes()
        {
            Configuracoes.Configuracoes configuracoes = new Configuracoes.Configuracoes();

            RootConfiguracoes configuracoesJson = configuracoes.ObtemConfiguracoes();

            chbxBuscaAtualizacoesIni.Checked = configuracoesJson.Geral.BuscaAtualizacaoIniApp;
            chbxIniciarComOWindows.Checked = configuracoesJson.Geral.IniciarComOWindows;

            tbDiretorioBackups.Text = configuracoesJson.Backups.DiretorioBackups;


            List<string> flagsBackup = configuracoesJson.Backups.FlagsBackup;

            foreach (var flag in flagsBackup)
            {
                for (int i = 0; i < lstBoxFlagsBackup.Items.Count; i++)
                {
                  
                    if (lstBoxFlagsBackup.Items[i].ToString().Equals(flag))
                    {
                        lstBoxFlagsBackup.SetItemChecked(i, true);
                    }
                }
            }

            tbAplicativoPreBackup.Text = configuracoesJson.Backups.AplicativoPreBackup.Aplicativo;
            tbArgumentosPreBackup.Text = configuracoesJson.Backups.AplicativoPreBackup.Argumentos;

            tbAplicativoPosBackup.Text = configuracoesJson.Backups.AplicativoPosBackup.Aplicativo;
            tbArgumentosPosBackup.Text = configuracoesJson.Backups.AplicativoPosBackup.Argumentos;

            chbxExcluirBackupsAntigos.Checked = configuracoesJson.Backups.ExcluirBackupsAntigosLocal.Ativo;
            nmUpDownDiasExcluirBackupsAntigos.Value = Shared.Helpers.ConverteStringParaNumero(configuracoesJson.Backups.ExcluirBackupsAntigosLocal.Dias);
        }
        private void UCConfiguracoes_Load(object sender, EventArgs e)
        {
           
            CarregaConfiguracoes();
        }

        private void SalvaConfiguracoes()
        {
            Configuracoes.Configuracoes configuracoes = new Configuracoes.Configuracoes();

            RootConfiguracoes rootConfiguracoes = new RootConfiguracoes();
            Geral geralConfiguracoes = new Geral();
            AplicativoPreBackupConfiguracoes aplicativoPreBackupConfiguracoes = new AplicativoPreBackupConfiguracoes();
            AplicativoPosBackupConfiguracoes aplicativoPosBackupConfiguracoes = new AplicativoPosBackupConfiguracoes();
            ExcluirBackupsAntigosLocalConfiguracoes excluirBackupsAntigosLocalConfiguracoes = new ExcluirBackupsAntigosLocalConfiguracoes();
            BackupsConfiguracoes backupsConfiguracoes = new BackupsConfiguracoes();

            geralConfiguracoes.BuscaAtualizacaoIniApp = chbxBuscaAtualizacoesIni.Checked;
            geralConfiguracoes.IniciarComOWindows = chbxIniciarComOWindows.Checked;

            aplicativoPreBackupConfiguracoes.Aplicativo = tbAplicativoPreBackup.Text;
            aplicativoPreBackupConfiguracoes.Argumentos = tbArgumentosPreBackup.Text;

            aplicativoPosBackupConfiguracoes.Aplicativo = tbAplicativoPosBackup.Text;
            aplicativoPosBackupConfiguracoes.Argumentos = tbArgumentosPosBackup.Text;

            excluirBackupsAntigosLocalConfiguracoes.Ativo = chbxExcluirBackupsAntigos.Checked;
            excluirBackupsAntigosLocalConfiguracoes.Dias = nmUpDownDiasExcluirBackupsAntigos.Value.ToString();

            backupsConfiguracoes.DiretorioBackups = tbDiretorioBackups.Text;

            List<string> flagsBackup = new List<string>();

            foreach (var flag in lstBoxFlagsBackup.CheckedItems)
            {
                flagsBackup.Add(flag.ToString().ToString().Trim());
            }

            rootConfiguracoes.Geral = geralConfiguracoes;
            backupsConfiguracoes.AplicativoPreBackup = aplicativoPreBackupConfiguracoes;
            backupsConfiguracoes.AplicativoPosBackup = aplicativoPosBackupConfiguracoes;
            backupsConfiguracoes.ExcluirBackupsAntigosLocal = excluirBackupsAntigosLocalConfiguracoes;
            backupsConfiguracoes.FlagsBackup = flagsBackup;
            rootConfiguracoes.Backups = backupsConfiguracoes;

            configuracoes.CriaAtualizaConfiguracoes(rootConfiguracoes);

            Shared.Helpers.HabilitaDesabilitaInicializacaoComWindows(rootConfiguracoes.Geral.IniciarComOWindows);
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvaConfiguracoes();
        }

        private void btnDiretorioBackups_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbDiretorioBackups.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnDiretorioAppPreBackup_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    tbAplicativoPreBackup.Text = fbd.FileName;
                }
            }
        }

        private void btnDiretorioAppPosBackup_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    tbAplicativoPosBackup.Text = fbd.FileName;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CarregaConfiguracoes();
        }

        private void lblExplicacaoFlags_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("- IgnoreLimbo: Ignora Transações no Limbo.\n\n" +
                "- IgnoreChecksums: Ignora Checksums Malformados.\n\n" +
                "- MetaDataOnly: Gera um Backup da parte de metadados. As tabelas estarão vazias.\n\n" +
                "- NoDatabaseTriggers: Inibe a execução das triggers.\n\n" +
                "- NoGarbageCollect: Inibe o \"Gargabe Collect\" durante o processo. (Padrão).\n\n" +
                "- NonTransportable: Gera o Backup no formato não transportável.\n\n" +
                "- OldDescriptions: Salva a descrição antiga dos metadados.\n\n" +
                "- Compactar: Gera um arquivo ZIP após o Backup ser Concluído.", "Opções do Backup", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
