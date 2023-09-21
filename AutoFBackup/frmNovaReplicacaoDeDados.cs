using FBackup.Models;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FBackup.Models.ReplicacaoDeDados;
using static Models.Backup;
using static Models.Email;

namespace FBackup
{
    public partial class frmNovaReplicacaoDeDados : Form
    {
        frmMain frmMain = null;
        public frmNovaReplicacaoDeDados(frmMain frmMain)
        {
            InitializeComponent();
            dpDownFrequenciaBackups.selectedIndex = 0;
            tbControl.SelectedIndex = 0;
            this.frmMain = frmMain;
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

        private void btnEscolherPastaMonitoramento_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbDiretorioLocalMonitoramento.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnDiretorioLogsSucesso_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbDiretorioLogsSucesso.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnDiretorioLogsErro_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbDiretorioLogsErro.Text = fbd.SelectedPath;
                }
            }
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
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ValidaPrincipal()
        {
            if (string.IsNullOrWhiteSpace(tbIdentificador.Text))
            {
                MessageBox.Show("Identificador da Rotina deve ser informado.", "Principal", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidaFrequencia()
        {
            if (dpDownFrequenciaBackups.selectedIndex == 0 &&
                string.IsNullOrEmpty(nmUpDownHorasFreqPorHora.Value.ToString()))
            {
                MessageBox.Show("Hora inválida para a Frequência de Checagem e Transporte de Novos Arquivos por Hora.", "Frequência", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if ((dpDownFrequenciaBackups.selectedIndex == 1) &&
                (string.IsNullOrEmpty(nmUpDownHorasFreqDiaria.Value.ToString()) ||
                string.IsNullOrEmpty(nmUpDownMinutosFreqDiaria.Value.ToString())))
            {
                MessageBox.Show("Hora/Minutos inválidos para a Frequência de Checagem e Transporte de Novos Arquivos Diária.", "Frequência", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if ((dpDownFrequenciaBackups.selectedIndex == 2) && (lstBoxDiasSemanaFreqSemanal.SelectedItems.Count <= 0 ||
                string.IsNullOrEmpty(nmUpDownHorasFreqSemanal.Value.ToString()) ||
                string.IsNullOrEmpty(nmUpDownMinutosFreqSemanal.Value.ToString())))
            {

                MessageBox.Show("Hora/Minutos/nenhum dia selecionado para a Frequência de Checagem e Transporte de Novos Arquivos Semanal.", "Frequência", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }

            return true;
        }

        private bool ValidaArquivosReplicacaoDados()
        {
            if (string.IsNullOrWhiteSpace(tbDiretorioDestino.Text))
            {
                MessageBox.Show("O Diretório de Envio (Diretório de Destino dos Arquivos de Replicação de Dados) para os Arquivos da Replicação de Dados deve ser informado.", "Upload de Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(tbDiretorioLocalMonitoramento.Text))
            {
                MessageBox.Show("O Diretório de Monitoramento (Diretório de Origem dos Arquivos de Replicação de Dados) para Checagem de Novos Arquivos da Replicação de Dados deve ser informada.", "Principal", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
            {
                return true;
            }
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

        private bool ValidaLogsLocais()
        {
            if (string.IsNullOrWhiteSpace(tbDiretorioLogsSucesso.Text))
            {
                MessageBox.Show("O Diretório de Logs de Sucesso deve ser informado.", "Logs Locais", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(tbDiretorioLogsErro.Text))
            {
                MessageBox.Show("O Diretório de Logs de Erro deve ser informado.", "Logs Locais", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
            {
                return true;
            }
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

        private void CriaRotinaReplicacaoDeDados()
        {
            Rotinas.Rotinas rotinas = new Rotinas.Rotinas();
            Root_ReplicacaoDeDados rootReplicacaoDeDados = new Root_ReplicacaoDeDados();

            Principal_ReplicacaoDeDados principal_ReplicacaoDeDados = new Principal_ReplicacaoDeDados();
            Frequencia_ReplicacaoDeDados frequencia_ReplicacaoDeDados = new Frequencia_ReplicacaoDeDados();
            DiretoriosEEnvio_ReplicacaoDeDados diretoriosEEnvio_ReplicacaoDeDados = new DiretoriosEEnvio_ReplicacaoDeDados();
            Integracoes_ReplicacaoDeDados integracoes_ReplicacaoDeDados = new Integracoes_ReplicacaoDeDados();


            Tuple<string, string, string, List<string>> dadosFrequenciaSelecionada = ObtemDadosFrequenciaSelecionada();

            frequencia_ReplicacaoDeDados.Tipo = dadosFrequenciaSelecionada.Item1;
            frequencia_ReplicacaoDeDados.Hora = dadosFrequenciaSelecionada.Item2;
            frequencia_ReplicacaoDeDados.Minuto = dadosFrequenciaSelecionada.Item3;
            frequencia_ReplicacaoDeDados.DiasSemana = dadosFrequenciaSelecionada.Item4;

            principal_ReplicacaoDeDados.Identificador = tbIdentificador.Text.Trim();
            principal_ReplicacaoDeDados.Frequencia = frequencia_ReplicacaoDeDados;


            diretoriosEEnvio_ReplicacaoDeDados.DiretorioLocalOrigem = tbDiretorioLocalMonitoramento.Text.Trim();
            diretoriosEEnvio_ReplicacaoDeDados.MetodoEnvioArquivosReplicacao = dpDownMetodoEnvioArquivosReplicacaoDados.selectedValue.ToString();
            diretoriosEEnvio_ReplicacaoDeDados.DiretorioRemotoDestino = tbDiretorioDestino.Text.Trim();
            diretoriosEEnvio_ReplicacaoDeDados.DiretorioLogsSucesso = tbDiretorioLogsSucesso.Text.Trim();
            diretoriosEEnvio_ReplicacaoDeDados.DiretorioLogsErro = tbDiretorioLogsErro.Text.Trim();
            diretoriosEEnvio_ReplicacaoDeDados.CriarDiretorioFilhoDataDia = chbxCriarDiretorioFilhoDataDiaDiretorioLocalLogs.Checked;




            Notificacoes_ReplicacaoDeDados notificacoes_ReplicacaoDeDados = new Notificacoes_ReplicacaoDeDados();

            Telegram_ReplicacaoDeDados telegram_ReplicacaoDeDados = new Telegram_ReplicacaoDeDados();
            Envio_Telegram_ReplicacaoDeDados envio_Telegram_ReplicacaoDeDados = new Envio_Telegram_ReplicacaoDeDados();
            Opcoes_Telegram_ReplicacaoDeDados opcoes_Telegram_ReplicacaoDeDados = new Opcoes_Telegram_ReplicacaoDeDados();

            telegram_ReplicacaoDeDados.Ativo = chbxTelegram.Checked;
            envio_Telegram_ReplicacaoDeDados.ChatIDDestino = tbChatIDDestino_Telegram.Text;

            opcoes_Telegram_ReplicacaoDeDados.ReceberNotificacoesSucesso = chbxNotificacoesSucesso_Telegram.Checked;
            opcoes_Telegram_ReplicacaoDeDados.ReceberNotificacoesErros = chbxNotificacoesErro_Telegram.Checked;

            envio_Telegram_ReplicacaoDeDados.Opcoes = opcoes_Telegram_ReplicacaoDeDados;

            telegram_ReplicacaoDeDados.Envio = envio_Telegram_ReplicacaoDeDados;

            notificacoes_ReplicacaoDeDados.Telegram = telegram_ReplicacaoDeDados;



            Email_ReplicacaoDeDados email_ReplicacaoDeDados = new Email_ReplicacaoDeDados();
            Envio_Email_ReplicacaoDeDados envio_Email_ReplicacaoDeDados = new Envio_Email_ReplicacaoDeDados();
            Opcoes_Email_ReplicacaoDeDados opcoes_Email_ReplicacaoDeDados = new Opcoes_Email_ReplicacaoDeDados();

            email_ReplicacaoDeDados.Ativo = chbxEmail.Checked;

            envio_Email_ReplicacaoDeDados.Assunto = tbAssunto_Email.Text;
            envio_Email_ReplicacaoDeDados.Destinatarios = tbDestinatarios_Email.Text;

            opcoes_Email_ReplicacaoDeDados.ReceberNotificacoesErros = chbxNotificacoesErro_Email.Checked;
            opcoes_Email_ReplicacaoDeDados.ReceberNotificacoesSucesso = chbxNotificacoesSucesso_Email.Checked;

            envio_Email_ReplicacaoDeDados.Opcoes = opcoes_Email_ReplicacaoDeDados;
            email_ReplicacaoDeDados.Envio = envio_Email_ReplicacaoDeDados;

            notificacoes_ReplicacaoDeDados.Email = email_ReplicacaoDeDados;

            integracoes_ReplicacaoDeDados.Notificacoes = notificacoes_ReplicacaoDeDados;



            rootReplicacaoDeDados.TipoRotina = "REPLICACAO_DE_DADOS";
            rootReplicacaoDeDados.Principal = principal_ReplicacaoDeDados;
            rootReplicacaoDeDados.DiretoriosEEnvio = diretoriosEEnvio_ReplicacaoDeDados;
            rootReplicacaoDeDados.Integracoes = integracoes_ReplicacaoDeDados;

            rotinas.CriaArquivoRotina(rootReplicacaoDeDados, false);

            this.frmMain.Re_InicializaRotinas = true;

            MessageBox.Show("Rotina de Replicação de Dados Criada com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidaPrincipal())
            {
                return;
            }

            if (!ValidaFrequencia())
            {
                return;
            }

            if (!ValidaArquivosReplicacaoDados())
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

            if (!ValidaLogsLocais())
            {
                return;
            }

            CriaRotinaReplicacaoDeDados();
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
            }
        }
    
        private void CarregaIntegracoes()
        {
            CarregaIntegracaoTelegram();
            CarregaIntegracaoEmail();
        }

        private void frmNovaReplicacaoDeDados_Load(object sender, EventArgs e)
        {
            dpDownMetodoEnvioArquivosReplicacaoDados.selectedIndex = 0;
            dpDownFrequenciaBackupHoraMinuto.selectedIndex = 0;
            CarregaIntegracoes();
        }

        private void lblExplicacaoIdentificador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("O Identificador serve para que você saiba sobre qual Banco de Dados o AutoFBackup se refere ao enviar uma notificação, salvar um arquivo de log, etc.\nO identificador pode ser o nome do estabelecimento, por exemplo: \"Loja do Edson\".", "Identificador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void dpDownMetodoEnvioArquivosReplicacaoDados_onItemSelected(object sender, EventArgs e)
        {
            if (dpDownMetodoEnvioArquivosReplicacaoDados.selectedIndex == 0)
            {
                lblDiretorioRemoto.Text = "(ex: /diretorio/para/upload)";
            }
            if (dpDownMetodoEnvioArquivosReplicacaoDados.selectedIndex == 1)
            {
                lblDiretorioRemoto.Text = @"(ex: \\diretorio\para\upload";
            }
        }
    }
}
