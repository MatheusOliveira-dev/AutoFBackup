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
            chbxAguardarConclusaoAplicativoPreBackup.Checked = configuracoesJson.Backups.AplicativoPreBackup.AguardaConclusao;

            tbAplicativoPosBackup.Text = configuracoesJson.Backups.AplicativoPosBackup.Aplicativo;
            tbArgumentosPosBackup.Text = configuracoesJson.Backups.AplicativoPosBackup.Argumentos;

            chbxExcluirBackupsAntigos.Checked = configuracoesJson.Backups.ExcluirBackupsAntigosLocal.Ativo;
            nmUpDownDiasExcluirBackupsAntigos.Value = Shared.Helpers.ConverteStringParaNumero(configuracoesJson.Backups.ExcluirBackupsAntigosLocal.Dias);
        
            if (configuracoesJson.Backups.ExecutaGfix != null)
            {
                chbxExecutaGFIX.Checked = configuracoesJson.Backups.ExecutaGfix.Ativo;
                tbDiretorioGFIX.Text = configuracoesJson.Backups.ExecutaGfix.CaminhoGfix;
                tbArgumentosGFIX.Text = configuracoesJson.Backups.ExecutaGfix.ArgumentosGfix;
            }
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
            ExecutaGfixConfiguracoes executaGfixConfiguracoes = new ExecutaGfixConfiguracoes();
            BackupsConfiguracoes backupsConfiguracoes = new BackupsConfiguracoes();

            geralConfiguracoes.BuscaAtualizacaoIniApp = chbxBuscaAtualizacoesIni.Checked;
            geralConfiguracoes.IniciarComOWindows = chbxIniciarComOWindows.Checked;

            aplicativoPreBackupConfiguracoes.Aplicativo = tbAplicativoPreBackup.Text;
            aplicativoPreBackupConfiguracoes.Argumentos = tbArgumentosPreBackup.Text;
            aplicativoPreBackupConfiguracoes.AguardaConclusao = chbxAguardarConclusaoAplicativoPreBackup.Checked;

            aplicativoPosBackupConfiguracoes.Aplicativo = tbAplicativoPosBackup.Text;
            aplicativoPosBackupConfiguracoes.Argumentos = tbArgumentosPosBackup.Text;

            excluirBackupsAntigosLocalConfiguracoes.Ativo = chbxExcluirBackupsAntigos.Checked;
            excluirBackupsAntigosLocalConfiguracoes.Dias = nmUpDownDiasExcluirBackupsAntigos.Value.ToString();


            executaGfixConfiguracoes.Ativo = chbxExecutaGFIX.Checked;
            executaGfixConfiguracoes.CaminhoGfix = tbDiretorioGFIX.Text;
            executaGfixConfiguracoes.ArgumentosGfix = tbArgumentosGFIX.Text;

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
            backupsConfiguracoes.ExecutaGfix = executaGfixConfiguracoes;
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

        private void btnDiretorioGFIX_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                fbd.Filter = "GFIX.exe (.exe)|*.exe|All Files (*.*)|*.*";

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    tbDiretorioGFIX.Text = fbd.FileName;
                }
            }
        }

        private void chbxExecutaGFIX_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxExecutaGFIX.Checked)
            {
                gpbxGFIX.Enabled = true;
            }
            else
            {
                gpbxGFIX.Enabled = false;
            }
        }

        private void lblAvisoArgumentosGfix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Informe os argumentos no formato:\n-argumento1 -argumento2 -argumento3.\n\nPor exemplo: -mend -full -ignore\n\n-----\nAtenção: Não é preciso especificar os argumentos 'User', 'Password' e o caminho para o Banco de Dados", "Argumentos do GFIX", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            MessageBox.Show("-activate: activate shadow file for database usage\n" +
                "-attach: shutdown new database attachments\n" +
                "-buffers: set page buffers < n >\n" +
                "-commit: commit transaction < tr / all >\n" +
                "-cache: shutdown cache manager\n" +
                "-full: validate record fragments (-v)\n" +
                "-force: force database shutdown\n" +
                "-fetch_password: fetch_password from file\n" +
                "-housekeeping: set sweep interval < n >\n" +
                "-ignore: ignore checksum errors\n" +
                "-kill: kill all unavailable shadow files\n" +
                "-mend: prepare corrupt database for backup\n" +
                "-mode: read_only or read_write\n" +
                "-no_update: read - only validation(-v)\n" +
                "-online: database online < single / multi / normal >\n" +
                "-rollback: rollback transaction < tr / all >" +
                "-sql_dialect: set database dialect n\n" +
                "-sweep: force garbage collection\n" +
                "-shut: shutdown < full / single / multi >\n" +
                "-two_phase: perform automated two - phase recovery\n" +
                "-tran: shutdown transaction startup\n" +
                "-use: use full or reserve space for versions\n" +
                "-validate: validate database structure\n" +
                "-write: write synchronously or asynchronously\n\n\nFonte: https://www.firebirdsql.org/pdfmanual/html/gfix-cmdline.html", "Argumentos do GFIX", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void lblAvisoGfix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Há suporte para essa opção apenas se o AutoFBackup estiver sendo executado no mesmo computador onde o Banco de Dados está localizado.", "GFIX", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
    }
}
