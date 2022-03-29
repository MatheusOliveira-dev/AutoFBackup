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
using static Models.Email;

namespace FBackup
{
    public partial class UCIntegracoes : UserControl
    {
        public UCIntegracoes()
        {
            InitializeComponent();
            tbControl.SelectedIndex = 0;
        }

        private void TelegramNotificacao()
        {
            if (chbxTelegram.Checked)
            {
                gpbxTelegram.Enabled = true;
            }
            else
            {
                gpbxTelegram.Enabled = false;
            }
        }

        private void EmailNotificacao()
        {
            if (chbxEmail.Checked)
            {
                gpbxEmail.Enabled = true;
            }
            else
            {
                gpbxEmail.Enabled = false;
            }
        }

        private void MegaNZUpload()
        {
            if (chbxMega.Checked)
            {
                gpbxMega.Enabled = true;
            }
            else
            {
                gpbxMega.Enabled = false;
            }
        }

        private void FTPUpload()
        {
            if (chbxFTP.Checked)
            {
                gpbxFTP.Enabled = true;
            }
            else
            {
                gpbxFTP.Enabled = false;
            }
        }

        private void chbxTelegram_CheckedChanged(object sender, EventArgs e)
        {
            TelegramNotificacao();
        }

        private void chbxEmail_CheckedChanged(object sender, EventArgs e)
        {
            EmailNotificacao();
        }

        private void chbxMega_CheckedChanged(object sender, EventArgs e)
        {
            MegaNZUpload();
        }

        private void chbxFTP_CheckedChanged(object sender, EventArgs e)
        {
            FTPUpload();
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool ValidaTelegram()
        {
            if (chbxTelegram.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbAccessTokenBot_Telegram.Text) ||
                    string.IsNullOrWhiteSpace(tbChatIDDestino_Telegram.Text))
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
                if (string.IsNullOrWhiteSpace(tbHost_Email.Text) ||
                    string.IsNullOrWhiteSpace(nmUpDownPorta_Email.Value.ToString()) ||
                    string.IsNullOrWhiteSpace(tbUsuario_Email.Text) ||
                    string.IsNullOrWhiteSpace(tbSenha_Email.Text) ||
                    string.IsNullOrWhiteSpace(tbAssunto_Email.Text) ||
                    string.IsNullOrWhiteSpace(tbDestinatarios_Email.Text))
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
                if (string.IsNullOrWhiteSpace(tbEmail_MegaNZ.Text) ||
                    string.IsNullOrWhiteSpace(tbSenha_MegaNZ.Text) ||
                    string.IsNullOrWhiteSpace(tbPasta_MegaNZ.Text))
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
                if (string.IsNullOrWhiteSpace(tbHost_FTP.Text) ||
                    string.IsNullOrWhiteSpace(nmUpDownPorta_FTP.Value.ToString()) ||
                    string.IsNullOrWhiteSpace(tbUsuario_FTP.Text) ||
                    string.IsNullOrWhiteSpace(tbSenha_FTP.Text) ||
                    string.IsNullOrWhiteSpace(tbDiretorio_FTP.Text))
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

        private void CriaAtualizaIntegracaoTelegram()
        {
            Integracoes.Telegram telegram = new Integracoes.Telegram();

            if (chbxTelegram.Checked && ValidaTelegram())
            {

                

                RootTelegram rootTelegram = new RootTelegram();
                CredenciaisTelegram credenciaisTelegram = new CredenciaisTelegram();
                OpcoesTelegram opcoesTelegram = new OpcoesTelegram();
                EnvioTelegram envioTelegram = new EnvioTelegram();

                credenciaisTelegram.AccessTokenBot = tbAccessTokenBot_Telegram.Text;

                opcoesTelegram.ReceberNotificacaoErros = chbxNotificacaoErro_Telegram.Checked;
                opcoesTelegram.ReceberLogTxt = chbxLogBackup_Telegram.Checked;

                envioTelegram.ChatIDDestino = tbChatIDDestino_Telegram.Text;
                envioTelegram.Opcoes = opcoesTelegram;

                rootTelegram.Credenciais = credenciaisTelegram;
                rootTelegram.Envio = envioTelegram;

                telegram.CriaAtualizaIntegracaoTelegram(rootTelegram);
                
            }
            else
            {
                telegram.ExcluiIntegracaoTelegram();
            }
        }


        private void CriaAtualizaIntegracaoEmail()
        {
            Integracoes.Email email = new Integracoes.Email();

            if (chbxEmail.Checked && ValidaEmail())
            {
                RootEmail rootEmail = new RootEmail();
                OpcoesEmail opcoesEmail = new OpcoesEmail();
                EnvioEmail envioEmail = new EnvioEmail();
                CredenciaisEmail credenciaisEmail = new CredenciaisEmail();

                credenciaisEmail.SSL = chbxSSL_Email.Checked;
                credenciaisEmail.Usuario = tbUsuario_Email.Text;
                credenciaisEmail.Senha = tbSenha_Email.Text;
                credenciaisEmail.Host = tbHost_Email.Text;
                credenciaisEmail.Porta = nmUpDownPorta_Email.Value.ToString();

                opcoesEmail.ReceberEmailErros = chbxNotificacaoErro_Email.Checked;
                opcoesEmail.ReceberLogTxt = chbxLogBackup_Email.Checked;

                envioEmail.Assunto = tbAssunto_Email.Text;
                envioEmail.Destinatarios = tbDestinatarios_Email.Text;

                envioEmail.Opcoes = opcoesEmail;

                rootEmail.Credenciais = credenciaisEmail;
                rootEmail.Envio = envioEmail;

                email.CriaAtualizaIntegracaoEmail(rootEmail);

            }
            else
            {
                email.ExcluiIntegracaoEmail();
            }
        }

        private void CriaAtualizaIntegracaoMegaNZ()
        {
            Integracoes.MegaNZ megaNZ = new Integracoes.MegaNZ();


            if (chbxMega.Checked && ValidaMegaNZ())
            {    
                RootMegaNZ rootMegaNZ = new RootMegaNZ();
                CredenciaisMegaNZ credenciaisMegaNZ = new CredenciaisMegaNZ();
                EnvioMegaNZ envioMegaNZ = new EnvioMegaNZ();

                credenciaisMegaNZ.Email = tbEmail_MegaNZ.Text;
                credenciaisMegaNZ.Senha = tbSenha_MegaNZ.Text;

                envioMegaNZ.Pasta = tbPasta_MegaNZ.Text;

                rootMegaNZ.Credenciais = credenciaisMegaNZ;
                rootMegaNZ.Envio = envioMegaNZ;

                megaNZ.CriaAtualizaIntegracaoMegaNZ(rootMegaNZ);

            }
            else
            {
                megaNZ.ExcluiIntegracaoMegaNZ();
            }

        }

        private void CriaAtualizaIntegracaoFTP()
        {
            Integracoes.FTP ftp = new Integracoes.FTP();

            if (chbxFTP.Checked && ValidaFTP())
            {
                CredenciaisFTP credenciaisFTP = new CredenciaisFTP();
                ExcluirBackupsAntigosFTP excluirBackupsAntigosFTP = new ExcluirBackupsAntigosFTP();
                OpcoesFTP opcoesFTP = new OpcoesFTP();
                EnvioFTP envioFTP = new EnvioFTP();
                RootFTP rootFTP = new RootFTP();

                credenciaisFTP.Host = tbHost_FTP.Text;
                credenciaisFTP.Porta = nmUpDownPorta_FTP.Value.ToString();
                credenciaisFTP.Passivo = chbxPassivo_FTP.Checked;
                credenciaisFTP.Usuario = tbUsuario_FTP.Text;
                credenciaisFTP.Senha = tbSenha_FTP.Text;

                excluirBackupsAntigosFTP.Ativo = chbxExcluiBackupsAntigos_FTP.Checked;
                excluirBackupsAntigosFTP.Dias = DiasExcluirBackupsAntigos_FTP.Value.ToString();

                envioFTP.Diretorio = tbDiretorio_FTP.Text;

                opcoesFTP.ExcluirBackupsAntigos = excluirBackupsAntigosFTP;
                envioFTP.Opcoes = opcoesFTP;

                rootFTP.Credenciais = credenciaisFTP;
                rootFTP.Envio = envioFTP;

                ftp.CriaAtualizaIntegracaoFTP(rootFTP);
            }
            else
            {
                ftp.ExcluiIntegracaoFTP();
            }

        }


        private void CriaAtualizaIntegracoes()
        {
            CriaAtualizaIntegracaoTelegram();
            CriaAtualizaIntegracaoEmail();
            CriaAtualizaIntegracaoMegaNZ();
            CriaAtualizaIntegracaoFTP();
        }



        private void CarregaIntegracaoTelegram()
        {
            Integracoes.Telegram telegram = new Integracoes.Telegram();

            RootTelegram rootTelegram = telegram.ObtemIntegracaoTelegram();

            if (rootTelegram != null)
            {
                chbxTelegram.Checked = true;

                tbAccessTokenBot_Telegram.Text = rootTelegram.Credenciais.AccessTokenBot;
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
                chbxEmail.Checked = true;

                tbHost_Email.Text = rootEmail.Credenciais.Host;
                nmUpDownPorta_Email.Value = Shared.Helpers.ConverteStringParaNumero(rootEmail.Credenciais.Porta);
                chbxSSL_Email.Checked = rootEmail.Credenciais.SSL;
                tbUsuario_Email.Text = rootEmail.Credenciais.Usuario;
                tbSenha_Email.Text = rootEmail.Credenciais.Senha;
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
                chbxMega.Checked = true;

                tbEmail_MegaNZ.Text = rootMegaNZ.Credenciais.Email;
                tbSenha_MegaNZ.Text = rootMegaNZ.Credenciais.Senha;
                tbPasta_MegaNZ.Text = rootMegaNZ.Envio.Pasta;
            }
        }
        private void CarregaIntegracaoFTP()
        {
            Integracoes.FTP ftp = new Integracoes.FTP();
            RootFTP rootFTP = ftp.ObtemIntegracaoFTP();

            if (rootFTP != null)
            {
                chbxFTP.Checked = true;

                tbHost_FTP.Text = rootFTP.Credenciais.Host;
                nmUpDownPorta_FTP.Value = Shared.Helpers.ConverteStringParaNumero(rootFTP.Credenciais.Porta);
                chbxPassivo_FTP.Checked = rootFTP.Credenciais.Passivo;
                tbUsuario_FTP.Text = rootFTP.Credenciais.Usuario;
                tbSenha_FTP.Text = rootFTP.Credenciais.Senha;
                chbxExcluiBackupsAntigos_FTP.Checked = rootFTP.Envio.Opcoes.ExcluirBackupsAntigos.Ativo;
                DiasExcluirBackupsAntigos_FTP.Value = Shared.Helpers.ConverteStringParaNumero(rootFTP.Envio.Opcoes.ExcluirBackupsAntigos.Dias);
                tbDiretorio_FTP.Text = rootFTP.Envio.Diretorio;
            }
        }

        private void CarregaIntegracoes()
        {
            CarregaIntegracaoTelegram();
            CarregaIntegracaoEmail();
            CarregaIntegracaoMegaNZ();
            CarregaIntegracaoFTP();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
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

            CriaAtualizaIntegracoes();
        }

        private void UCIntegracoes_Load(object sender, EventArgs e)
        {
            CarregaIntegracoes();
        }

        private void btnBuscarChatID_Telegram_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(tbAccessTokenBot_Telegram.Text))
            {
                Telegram.Chats chats = new Telegram.Chats();

                Tuple<string, string> respostaChatIDDestino = chats.ObtemChatIDDestino(tbAccessTokenBot_Telegram.Text);

                if (!string.IsNullOrWhiteSpace(respostaChatIDDestino.Item1))
                {
                    MessageBox.Show(string.Format("Seu ChatID de Destino é: {0}\n\nO Tipo deste Chat é: {1}", respostaChatIDDestino.Item1, respostaChatIDDestino.Item2), "ChatID de Destino", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Não foi possível obter o ChatID de destino. Certifique-se de ter mandado uma mensagem ao BOT criado e que o AccessToken informado esteja correto/válido.", "ChatID de Destino vazio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }  
        }

        private void lblExplicacaoExclusaoBackupsAntigos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("O AutoFBackup excluirá qualquer arquivo que possua uma extensão do tipo ZIP ou FBK e se enquadre na regra de Exclusão de Dias informada.\nPortanto, cuidado ao salvar arquivos pessoais no Diretório de Backups Remoto se essa opção estiver ativa.", "Exclusão de Backups Antigos", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
    }
}
