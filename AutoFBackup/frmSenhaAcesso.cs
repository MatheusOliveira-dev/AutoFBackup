using FBackup.Enums;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBackup
{
    public partial class frmSenhaAcesso : Form
    {

        private TipoAcessos tipoAcesso;

        public frmSenhaAcesso(TipoAcessos tipoAcesso)
        {
            InitializeComponent();

            tbSenha.MaxLength = 20;

            this.tipoAcesso = tipoAcesso;
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComparaSenhas()
        {
            Configuracoes.Configuracoes Configuracoes = new Configuracoes.Configuracoes();

            string senhaConfiguracoes = this.tipoAcesso == TipoAcessos.Botao
                ? Helpers.Base64Decode(Configuracoes.ObtemConfiguracoes().Geral.SenhaAcessoBotoes) 
                : Helpers.Base64Decode(Configuracoes.ObtemConfiguracoes().Geral.SenhaFecharApp);

            if (senhaConfiguracoes.ToLower().Trim().Equals(tbSenha.Text.Trim().ToLower()))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Senha Incorreta!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSenha.Focus();
            }

        }

        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSenha.Text))
            {
                MessageBox.Show("A Senha deve ser Informada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSenha.Focus();
                return;
            }

            ComparaSenhas();
        }
    }
}
