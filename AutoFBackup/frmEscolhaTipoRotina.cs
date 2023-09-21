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
    public partial class frmEscolhaTipoRotina : Form
    {
        frmMain frmMain = null;
        public frmEscolhaTipoRotina(frmMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            frmNovoBackup frmNovoBackup = new frmNovoBackup(this.frmMain);
            frmNovaReplicacaoDeDados frmNovaReplicacaoDeDados = new frmNovaReplicacaoDeDados(this.frmMain);

            this.Opacity = 0;

            if (rdbtnRotinaBackups.Checked)
                frmNovoBackup.ShowDialog();
            else
                frmNovaReplicacaoDeDados.ShowDialog();


            this.Close();

        }

        private void lblRotinaBackups_Click(object sender, EventArgs e)
        {
            rdbtnRotinaReplicacaoDados.Checked = false;
            rdbtnRotinaBackups.Checked = true;
        }

        private void lblRotinaReplicacaoDeDados_Click(object sender, EventArgs e)
        {
            rdbtnRotinaBackups.Checked = false;
            rdbtnRotinaReplicacaoDados.Checked = true;
        }
    }
}
