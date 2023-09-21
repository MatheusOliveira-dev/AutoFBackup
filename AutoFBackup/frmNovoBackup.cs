using Bunifu.UI.WinForms;
using Models;
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
using static Models.Backup;
using static Models.Email;

namespace FBackup
{
    public partial class frmNovoBackup : Form
    {
        frmMain frmMain = null;
        public frmNovoBackup(frmMain frmMain)
        {
            InitializeComponent();
            this.Icon = frmMain.Icon;
            dpDownFrequenciaBackups.selectedIndex = 0;
            dpDownExtensaoArquivoBackup.selectedIndex = 0;
            tbControl.SelectedIndex = 0;
            this.frmMain = frmMain;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidaServidor()
        {
            if (string.IsNullOrWhiteSpace(tbServidor_Servidor.Text) ||
                   string.IsNullOrWhiteSpace(nmUpDownPorta_Servidor.Value.ToString()) ||
                   string.IsNullOrWhiteSpace(tbUsuario_Servidor.Text) ||
                   string.IsNullOrWhiteSpace(tbSenha_Servidor.Text) ||
                   string.IsNullOrWhiteSpace(tbDiretorioBancoDeDados_Servidor.Text) ||
                   string.IsNullOrWhiteSpace(tbIdentificador_Servidor.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidaFrequenciaBackups()
        {
            if (dpDownFrequenciaBackups.selectedIndex == 0 && 
                string.IsNullOrEmpty(nmUpDownHorasFreqPorHora.Value.ToString()))
            {
                MessageBox.Show("Hora inválida para a Frequência de Backup por Hora.", "Frequência de Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if ((dpDownFrequenciaBackups.selectedIndex == 1) && 
                (string.IsNullOrEmpty(nmUpDownHorasFreqDiaria.Value.ToString()) ||
                string.IsNullOrEmpty(nmUpDownMinutosFreqDiaria.Value.ToString())))
            {
                MessageBox.Show("Hora/Minutos inválidos para a Frequência de Backup Diária.", "Frequência de Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if ((dpDownFrequenciaBackups.selectedIndex == 2) && (lstBoxDiasSemanaFreqSemanal.SelectedItems.Count <= 0 ||
                string.IsNullOrEmpty(nmUpDownHorasFreqSemanal.Value.ToString()) ||
                string.IsNullOrEmpty(nmUpDownMinutosFreqSemanal.Value.ToString())))
            {
               
                MessageBox.Show("Hora/Minutos/nenhum dia selecionado para a Frequência de Backup Semanal.", "Frequência de Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }

            return true;
        }

        private bool ValidaOpcoesBackup()
        {
            if (string.IsNullOrEmpty(tbDiretorioBackups.Text))
            {
                MessageBox.Show("É obrigatório informar o Local onde os Backups serão salvos.", "Opções do Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (lstBoxFlagsBackup.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Ao menos uma Flag do Arquivo de Backup deve ser selecionada.", "Opções do Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }

            return true;
        }

        private bool ValidaTelegram()
        {
            if (chbxTelegram.Checked)
            {
                if (string.IsNullOrEmpty(tbChatIDDestino_Telegram.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool ValidaEmail()
        {
            if (chbxEmail.Checked)
            {
                if (string.IsNullOrEmpty(tbAssunto_Email.Text) ||
                    string.IsNullOrEmpty(tbDestinatarios_Email.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool ValidaMegaNZ()
        {
            if (chbxMega.Checked)
            {
                if (string.IsNullOrEmpty(tbPasta_MegaNZ.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool ValidaFTP()
        {
            if (chbxFTP.Checked)
            {
                if (string.IsNullOrEmpty(tbDiretorio_FTP.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }


        private bool ValidaGFIX()
        {
            if (chbxExecutaGFIX.Checked)
            {
                if (string.IsNullOrEmpty(tbDiretorioGFIX.Text))
                {
                    MessageBox.Show("É obrigatório informar o Diretório do GFIX.", "Opções do Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return false;
                }
                else if (lstBoxFlagsBackup.CheckedItems.Count <= 0)
                {
                    MessageBox.Show("Ao menos um argumento do GFIX deve ser selecionado.", "Opções do Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidaServidor())
            {
                MessageBox.Show("Antes de Prosseguir, todas as informações necessárias do Banco de Dados devem ser informadas.", "Principal", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!ValidaFrequenciaBackups())
            {
                return;
            }

            if (!ValidaOpcoesBackup())
            { 
                return;
            }

            if (!ValidaTelegram())
            {
                MessageBox.Show("Para ativar a Integração com o Telegram, todas as informações necessárias devem estar preenchidas.", "Integração com Telegram", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!ValidaEmail())
            {
                MessageBox.Show("Para ativar a Integração com o E-mail, todas as informações necessárias devem estar preenchidas.", "Integração com E-mail", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
         
            if (!ValidaMegaNZ())
            {
                MessageBox.Show("Para ativar a Integração com o Mega.nz, todas as informações necessárias devem estar preenchidas.", "Integração com Mega.nz", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
         
            if (!ValidaFTP())
            {
                MessageBox.Show("Para ativar a Integração com o seu FTP, todas as informações necessárias devem estar preenchidas.", "Integração com FTP", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!ValidaGFIX())
            {
                return;
            }

            CriaRotinaBackup();

        }

        private void CriaRotinaBackup()
        {
            Rotinas.Rotinas rotinas = new Rotinas.Rotinas();

            Root_Backup rootBackup = new Root_Backup();


            BancoDeDados_Backup bancoDeDados_Backup = new BancoDeDados_Backup();
            CriacaoBackup_Backup criacaoBackup_Backup = new CriacaoBackup_Backup();
            Opcoes_CriacaoBackup_Backup opcoes_CriacaoBackup_Backup = new Opcoes_CriacaoBackup_Backup();
            Frequencia_Backup frequencia_Backup = new Frequencia_Backup();
            AplicativoPreBackup_Backup aplicativoPreBackup_Backup = new AplicativoPreBackup_Backup();
            AplicativoPosBackup_Backup aplicativoPosBackup_Backup = new AplicativoPosBackup_Backup();
            ExcluirBackupsAntigosLocal_Backup backupsAntigosLocal_Backup = new ExcluirBackupsAntigosLocal_Backup();
            ExecutaGfix_Backup executaGfix_Backup = new ExecutaGfix_Backup();

            bancoDeDados_Backup.Identificador = tbIdentificador_Servidor.Text;
            bancoDeDados_Backup.Servidor = tbServidor_Servidor.Text;
            bancoDeDados_Backup.Porta = nmUpDownPorta_Servidor.Value.ToString();
            bancoDeDados_Backup.Usuario = tbUsuario_Servidor.Text;
            bancoDeDados_Backup.Senha = tbSenha_Servidor.Text;
            bancoDeDados_Backup.Caminho = tbDiretorioBancoDeDados_Servidor.Text;


            criacaoBackup_Backup.Diretorio_Backup = tbDiretorioBackups.Text;
            

            Tuple<string, string, string, List<string>> frequenciaBackups = ObtemDadosFrequenciaSelecionada();

            frequencia_Backup.Tipo = frequenciaBackups.Item1;
            frequencia_Backup.Hora = frequenciaBackups.Item2;
            frequencia_Backup.Minuto = frequenciaBackups.Item3;
            frequencia_Backup.DiasSemana = frequenciaBackups.Item4;
            frequencia_Backup.ExecutaNaInicializacaoApp = chbxExecutaRotinaIniAppFreqHoraMinuto.Checked;

            aplicativoPreBackup_Backup.AguardaConclusao = chbxAguardarConclusaoAplicativoPreBackup.Checked;
            aplicativoPreBackup_Backup.Aplicativo = tbAplicativoPreBackup.Text;
            aplicativoPreBackup_Backup.Argumentos = tbArgumentosPreBackup.Text;

            aplicativoPosBackup_Backup.Aplicativo = tbAplicativoPosBackup.Text;
            aplicativoPosBackup_Backup.Argumentos = tbArgumentosPosBackup.Text;

            backupsAntigosLocal_Backup.Ativo = chbxExcluirBackupsAntigos.Checked;
            backupsAntigosLocal_Backup.Dias = nmUpDownDiasExcluirBackupsAntigos.Value.ToString();
            backupsAntigosLocal_Backup.HabilitarExclusaoExtensoesDifBkp = chbxHabilitarExclusaoExtensoesDifFbkLocal.Checked;

            executaGfix_Backup.Ativo = chbxExecutaGFIX.Checked;
            executaGfix_Backup.CaminhoGfix = tbDiretorioGFIX.Text;
            executaGfix_Backup.ArgumentosGfix = tbArgumentosGFIX.Text;

            List<string> flagsBackup = new List<string>();

            foreach (var flag in lstBoxFlagsBackup.CheckedItems)
            {
                flagsBackup.Add(flag.ToString().ToString().Trim());
            }

            opcoes_CriacaoBackup_Backup.FlagsBackup = flagsBackup;
            opcoes_CriacaoBackup_Backup.AplicativoPreBackup = aplicativoPreBackup_Backup;
            opcoes_CriacaoBackup_Backup.AplicativoPosBackup = aplicativoPosBackup_Backup;
            opcoes_CriacaoBackup_Backup.ExcluirBackupsAntigosLocal = backupsAntigosLocal_Backup;
            opcoes_CriacaoBackup_Backup.ExecutaGfix = executaGfix_Backup;
            opcoes_CriacaoBackup_Backup.ExtensaoBackup = dpDownExtensaoArquivoBackup.selectedValue.ToString();

            criacaoBackup_Backup.Opcoes = opcoes_CriacaoBackup_Backup;

            criacaoBackup_Backup.Frequencia = frequencia_Backup;

            rootBackup.BancoDeDados = bancoDeDados_Backup;
            rootBackup.CriacaoBackup = criacaoBackup_Backup;

            Integracoes_Backup integracoes_Backup = new Integracoes_Backup();
            
            Notificacoes_Backup notificacoes_Backup = new Notificacoes_Backup();
            
            Telegram_Backup telegram_Backup = new Telegram_Backup();
            Envio_Telegram_Backup envio_Telegram_Backup = new Envio_Telegram_Backup();
            Opcoes_Telegram_Backup opcoes_Telegram_Backup = new Opcoes_Telegram_Backup();

            telegram_Backup.Ativo = chbxTelegram.Checked;
            envio_Telegram_Backup.ChatIDDestino = tbChatIDDestino_Telegram.Text;

            opcoes_Telegram_Backup.ReceberLogTxt = chbxLogBackup_Telegram.Checked;
            opcoes_Telegram_Backup.ReceberNotificacoesErros = chbxNotificacaoErro_Telegram.Checked;

            envio_Telegram_Backup.Opcoes = opcoes_Telegram_Backup;

            telegram_Backup.Envio = envio_Telegram_Backup;

            notificacoes_Backup.Telegram = telegram_Backup;

            Email_Backup email_Backup = new Email_Backup();
            Envio_Email_Backup envio_Email_Backup = new Envio_Email_Backup();
            Opcoes_Email_Backup opcoes_Email_Backup = new Opcoes_Email_Backup();

            email_Backup.Ativo = chbxEmail.Checked;

            envio_Email_Backup.Assunto = tbAssunto_Email.Text;
            envio_Email_Backup.Destinatarios = tbDestinatarios_Email.Text;

            opcoes_Email_Backup.ReceberEmailErros = chbxNotificacaoErro_Email.Checked;
            opcoes_Email_Backup.ReceberLogTxt = chbxLogBackup_Email.Checked;

            envio_Email_Backup.Opcoes = opcoes_Email_Backup;
            email_Backup.Envio = envio_Email_Backup;

            notificacoes_Backup.Email = email_Backup;

            integracoes_Backup.Notificacoes = notificacoes_Backup;

           

            Uploads_Backup uploads_Backup = new Uploads_Backup();

            MegaNZ_Backup megaNZ_Backup = new MegaNZ_Backup();
            Envio_MegaNZ_Backup envio_MegaNZ_Backup = new Envio_MegaNZ_Backup();

            megaNZ_Backup.Ativo = chbxMega.Checked;

            envio_MegaNZ_Backup.Pasta = tbPasta_MegaNZ.Text;

            megaNZ_Backup.Envio = envio_MegaNZ_Backup;

            uploads_Backup.MegaNZ = megaNZ_Backup;

            FTP_Backup ftp_Backup = new FTP_Backup();
            Envio_FTP_Backup envio_FTP_Backup = new Envio_FTP_Backup();
            Opcoes_FTP_Backup opcoes_FTP_Backup = new Opcoes_FTP_Backup();
            ExcluirBackupsAntigos_FTP_Backup excluirBackupsAntigos_FTP_Backup = new ExcluirBackupsAntigos_FTP_Backup();

            ftp_Backup.Ativo = chbxFTP.Checked;

            envio_FTP_Backup.Diretorio = tbDiretorio_FTP.Text;

            excluirBackupsAntigos_FTP_Backup.Ativo = chbxExcluiBackupsAntigos_FTP.Checked;
            excluirBackupsAntigos_FTP_Backup.Dias = DiasExcluirBackupsAntigos_FTP.Value.ToString();
            excluirBackupsAntigos_FTP_Backup.HabilitarExclusaoExtensoesDifBkp = chbxHabilitarExclusaoExtensoesDifFbkFTP.Checked;

            opcoes_FTP_Backup.ExcluirBackupsAntigos = excluirBackupsAntigos_FTP_Backup;

            envio_FTP_Backup.Opcoes = opcoes_FTP_Backup;

            ftp_Backup.Envio = envio_FTP_Backup;

            uploads_Backup.FTP = ftp_Backup;

            integracoes_Backup.Uploads = uploads_Backup;

            rootBackup.Integracoes = integracoes_Backup;

            rotinas.CriaArquivoRotina(rootBackup, true);

            this.frmMain.Re_InicializaRotinas = true;


            MessageBox.Show("Rotina de Backup Criada com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            this.Close();
        }

        private Tuple<string, string, string, List<string>> ObtemDadosFrequenciaSelecionada()
        {
            List<string> diasSemana = new List<string>();
            
            if (dpDownFrequenciaBackups.selectedIndex == 0)
            {

                if (dpDownFrequenciaBackupHoraMinuto.selectedIndex == 0)
                    return Tuple.Create("HoraMinuto", nmUpDownHorasFreqPorHora.Value.ToString(), string.Empty, diasSemana);
                else
                    return Tuple.Create("HoraMinuto", string.Empty, nmUpDownHorasFreqPorHora.Value.ToString(), diasSemana);
            }
            else if (dpDownFrequenciaBackups.selectedIndex == 1)
            {
                return Tuple.Create("Diaria", nmUpDownHorasFreqDiaria.Value.ToString(), nmUpDownMinutosFreqDiaria.Value.ToString(), diasSemana);
            }
            else
            {
                foreach (var diaSemanaSelecionado in lstBoxDiasSemanaFreqSemanal.CheckedItems)
                {
                    diasSemana.Add(diaSemanaSelecionado.ToString());
                }

                return Tuple.Create("Semanal", nmUpDownHorasFreqSemanal.Value.ToString(), nmUpDownMinutosFreqSemanal.Value.ToString(), diasSemana);
            }
        }

        

        private void CarregaConfiguracoes()
        {
            Configuracoes.Configuracoes configuracoes = new Configuracoes.Configuracoes();

            RootConfiguracoes configuracoesJson = configuracoes.ObtemConfiguracoes();

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
            chbxHabilitarExclusaoExtensoesDifFbkLocal.Checked = configuracoesJson.Backups.ExcluirBackupsAntigosLocal.HabilitarExclusaoExtensoesDifFbk;

            if (configuracoesJson.Backups.ExecutaGfix != null)
            {
                chbxExecutaGFIX.Checked = configuracoesJson.Backups.ExecutaGfix.Ativo;
                tbDiretorioGFIX.Text = configuracoesJson.Backups.ExecutaGfix.CaminhoGfix;
                tbArgumentosGFIX.Text = configuracoesJson.Backups.ExecutaGfix.ArgumentosGfix;
            }

            if (configuracoesJson.Backups.ExtensaoBackup != null)
            {
                switch (configuracoesJson.Backups.ExtensaoBackup.ToUpper())
                {
                    case ".FBK":
                        dpDownExtensaoArquivoBackup.selectedIndex = 0;
                        break;
                    case ".BCK":
                        dpDownExtensaoArquivoBackup.selectedIndex = 1;
                        break;
                }
            }

           
        }
        private void CarregaIntegracaoTelegram()
        {
            Integracoes.Telegram telegram = new Integracoes.Telegram();

            RootTelegram rootTelegram = telegram.ObtemIntegracaoTelegram();

            if (rootTelegram != null)
            {
                gpbxTelegram.Enabled = true;
                chbxTelegram.Enabled = true;

                tbChatIDDestino_Telegram.Text = rootTelegram.Envio.ChatIDDestino;

                chbxLogBackup_Telegram.Checked = rootTelegram.Envio.Opcoes.ReceberLogTxt;
                chbxNotificacaoErro_Telegram.Checked = rootTelegram.Envio.Opcoes.ReceberNotificacaoErros;
            }
        }

        private void CarregaIntegracaoEmail()
        {
            Integracoes.Email email = new Integracoes.Email();

            RootEmail rootEmail = email.ObtemIntegracaoEmail();

            if (rootEmail != null)
            {
                gpbxEmail.Enabled = true;
                chbxEmail.Enabled = true;

                tbAssunto_Email.Text = rootEmail.Envio.Assunto;
                tbDestinatarios_Email.Text = rootEmail.Envio.Destinatarios;
                chbxLogBackup_Email.Checked = rootEmail.Envio.Opcoes.ReceberLogTxt;
                chbxNotificacaoErro_Email.Checked = rootEmail.Envio.Opcoes.ReceberEmailErros;
            }
        }
        private void CarregaIntegracaoMegaNZ()
        {
            Integracoes.MegaNZ megaNZ = new Integracoes.MegaNZ();

            RootMegaNZ rootMegaNZ = megaNZ.ObtemIntegracaoMegaNZ();

            if (rootMegaNZ != null)
            {
                gpbxMega.Enabled = true;
                chbxMega.Enabled = true;

                tbPasta_MegaNZ.Text = rootMegaNZ.Envio.Pasta;
            }
        }
        private void CarregaIntegracaoFTP()
        {
            Integracoes.FTP ftp = new Integracoes.FTP();
            RootFTP rootFTP = ftp.ObtemIntegracaoFTP();

            if (rootFTP != null)
            {
                gpbxFTP.Enabled = true;
                chbxFTP.Enabled = true;

                chbxExcluiBackupsAntigos_FTP.Checked = rootFTP.Envio.Opcoes.ExcluirBackupsAntigos.Ativo;
                DiasExcluirBackupsAntigos_FTP.Value = Shared.Helpers.ConverteStringParaNumero(rootFTP.Envio.Opcoes.ExcluirBackupsAntigos.Dias);
                tbDiretorio_FTP.Text = rootFTP.Envio.Diretorio;
                chbxHabilitarExclusaoExtensoesDifFbkFTP.Checked = rootFTP.Envio.Opcoes.ExcluirBackupsAntigos.HabilitarExclusaoExtensoesDifFbk;
            }
        }

        private void CarregaIntegracoes()
        {
            CarregaIntegracaoTelegram();
            CarregaIntegracaoEmail();
            CarregaIntegracaoMegaNZ();
            CarregaIntegracaoFTP();
        }
        private void frmNovoBackup_Load(object sender, EventArgs e)
        {
            dpDownFrequenciaBackupHoraMinuto.selectedIndex = 0;

            CarregaConfiguracoes();
            CarregaIntegracoes();
        }

        private void btnEscolherBancoDeDados_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    tbDiretorioBancoDeDados_Servidor.Text = fbd.FileName;
                }
            }
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

        private void dpDownFrequenciaBackups_onItemSelected(object sender, EventArgs e)
        {
            if (dpDownFrequenciaBackups.selectedIndex == 0)
            {
                gpbxSemanalmente.Enabled = false;
                gpbxDiariamente.Enabled = false;
                gpbxPorHora.Enabled = true;
            }

            if (dpDownFrequenciaBackups.selectedIndex == 1)
            {
                gpbxPorHora.Enabled = false;
                gpbxSemanalmente.Enabled = false;
                gpbxDiariamente.Enabled = true;
            }

            if (dpDownFrequenciaBackups.selectedIndex == 2)
            {
                gpbxPorHora.Enabled = false;
                gpbxDiariamente.Enabled = false;
                gpbxSemanalmente.Enabled = true;
            }

            chbxExecutaRotinaIniAppFreqHoraMinuto.Checked = false;
        }

        private void btnBuscarChatID_Click(object sender, EventArgs e)
        {
            Integracoes.Telegram telegram = new Integracoes.Telegram();

            RootTelegram rootTelegram = telegram.ObtemIntegracaoTelegram();

            Telegram.Chats chats = new Telegram.Chats();

            

            if (rootTelegram != null && !string.IsNullOrWhiteSpace(rootTelegram.Credenciais.AccessTokenBot))
            {
                Tuple<string, string> respostaChatIDDestino = chats.ObtemChatIDDestino(rootTelegram.Credenciais.AccessTokenBot);

                if (!string.IsNullOrWhiteSpace(respostaChatIDDestino.Item1))
                {

                    MessageBox.Show(string.Format("Seu ChatID de Destino é: {0}\n\nO Tipo deste Chat é: {1}", respostaChatIDDestino.Item1, respostaChatIDDestino.Item2), "ChatID de Destino", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Não foi possível obter o ChatID de destino. Certifique-se de ter mandado uma mensagem ao BOT criado e que o AccessToken informado esteja correto/válido.", "ChatID de Destino vazio", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void lblExplicacaoIdentificador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("O Identificador serve para que você saiba sobre qual Banco de Dados o AutoFBackup se refere ao enviar uma notificação, um arquivo de log, etc.\nO identificador pode ser o nome do estabelecimento, por exemplo: \"Loja do Edson\".", "Identificador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void lblExplicacaoExclusaoBackupsAntigos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("O AutoFBackup excluirá qualquer arquivo que possua uma extensão do tipo ZIP ou FBK e se enquadre na regra de Exclusão de Dias informada.\nPortanto, cuidado ao salvar arquivos pessoais no Diretório de Backups Remoto se essa opção estiver ativa.", "Exclusão de Backups Antigos", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            MessageBox.Show("Se marcado a opção: 'Habilitar Exclusão de Arquivos de Backup com extensão diferente de .FBK', arquivos da exntesão .BCK que se enquadrem na regra de Exclusão de Dias informada também serão excluídos", "Exclusão de Backups Antigos - Outras Extensões", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

        }

        private void lblExplicacaoExclusaoBackupsAntigos1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("O AutoFBackup excluirá qualquer arquivo que possua uma extensão do tipo ZIP ou FBK e se enquadre na Regra de Exclusão de Dias informada.\nPortanto, cuidado ao salvar arquivos pessoais no Diretório de Backups Local se essa opção estiver ativa.", "Exclusão de Backups Antigos", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            MessageBox.Show("Se marcado a opção: 'Habilitar Exclusão de Arquivos de Backup com extensão diferente de .FBK', arquivos da exntesão .BCK que se enquadrem na regra de Exclusão de Dias informada também serão excluídos", "Exclusão de Backups Antigos - Outras Extensões", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

        }

        private void lblAvisoGfix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Há suporte para essa opção apenas se o AutoFBackup estiver sendo executado no mesmo computador onde o Banco de Dados está localizado.", "GFIX", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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

        private void dpDownExtensaoArquivoBackup_onItemSelected(object sender, EventArgs e)
        {

        }

        private void dpDownFrequenciaBackupHoraMinuto_onItemSelected(object sender, EventArgs e)
        {

        }
    }
}
