using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.BunifuRadioButton.Transitions;
using static FBackup.Models.ReplicacaoDeDados;
using static Models.Backup;

namespace FBackup
{
    public partial class UCDashboard : UserControl
    {

        frmMain frmMain = null;

        public UCDashboard(frmMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }

        private void SetaStatusIntegracao(string integracao, Bunifu.UI.WinForms.BunifuRadioButton btn)
        {
            if (Shared.Helpers.VerificaArquivoExistente(string.Format(@"Integracoes\{0}.json", integracao)))
            {
                btn.OutlineColor = Color.FromArgb(59, 213, 79);
                btn.RadioColor = Color.FromArgb(59, 213, 79);
            }
        }


        private void CarregaRotinasBackup()
        {
            dtGridViewRotinas.Rows.Clear();

            List<string> listArquivosRotinas = Shared.Helpers.ObtemArquivosDiretorio("Rotinas", "*.json");

            
            foreach (string arquivo in listArquivosRotinas)
            {

                bool isRotinaBackup = Rotinas.Rotinas.IsRotinaBackup(Shared.Helpers.LeArquivo(arquivo));

                Root_Backup rootRotina_Backup = null;
                Root_ReplicacaoDeDados rootRotina_ReplicacaoDeDados = null; 

                if (isRotinaBackup)
                    rootRotina_Backup = JsonConvert.DeserializeObject<Root_Backup>(Shared.Helpers.LeArquivo(arquivo));
                else
                    rootRotina_ReplicacaoDeDados = JsonConvert.DeserializeObject<Root_ReplicacaoDeDados>(Shared.Helpers.LeArquivo(arquivo));


                string identificadorRotina = isRotinaBackup 
                    ? rootRotina_Backup.BancoDeDados.Identificador
                    : rootRotina_ReplicacaoDeDados.Principal.Identificador;
                
                string tipoFrequenciaRotina = isRotinaBackup 
                    ? rootRotina_Backup.CriacaoBackup.Frequencia.Tipo
                    : rootRotina_ReplicacaoDeDados.Principal.Frequencia.Tipo;

                string diretorioBackups = isRotinaBackup 
                    ? rootRotina_Backup.CriacaoBackup.Diretorio_Backup 
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLocalOrigem;
                
                string horaRotina = isRotinaBackup 
                    ? rootRotina_Backup.CriacaoBackup.Frequencia.Hora
                    : rootRotina_ReplicacaoDeDados.Principal.Frequencia.Hora;

                string minutoRotina = isRotinaBackup 
                    ? rootRotina_Backup.CriacaoBackup.Frequencia.Minuto
                    : rootRotina_ReplicacaoDeDados.Principal.Frequencia.Minuto;

                string horarioExecucaoRotina = string.Empty;

                if (tipoFrequenciaRotina != "Hora")
                {
                    horarioExecucaoRotina = string.Format("{0} hrs. {1} mins.", horaRotina, minutoRotina);
                }
                else
                {
                    horarioExecucaoRotina = string.Format("{0} hrs.", horaRotina);
                }


                dtGridViewRotinas.Rows.Add(identificadorRotina, isRotinaBackup ? "Arquivo de Backup" : "Replicação de Dados", tipoFrequenciaRotina, horarioExecucaoRotina, diretorioBackups, arquivo);
            }
        }
        private void UCDashboard_Load(object sender, EventArgs e)
        {
            SetaStatusIntegracao("email", rdBtnEmail);
            SetaStatusIntegracao("telegram", rdBtnTelegram);
            SetaStatusIntegracao("meganz", rdBtnMegaNz);
            SetaStatusIntegracao("ftp", rdBtnFTP);

            CarregaRotinasBackup();
        }

        private void dtGridViewRotinas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtGridViewRotinas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGridViewRotinas.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir a Rotina de Backup selecionada?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Shared.Helpers.ExcluiArquivo(dtGridViewRotinas.SelectedRows[0].Cells["column_NomeRotinaJSON"].Value.ToString());
                    this.frmMain.Re_InicializaRotinas = true;
                }
            }
        }
        private void dtGridViewRotinas_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void dtGridViewRotinas_MouseClick(object sender, MouseEventArgs e)
        {
            if (dtGridViewRotinas.Rows.Count > 0 && dtGridViewRotinas.SelectedRows.Count > 0 && e.Button == MouseButtons.Right)
            {
                ContextMenuStrip m = new ContextMenuStrip();

                int currentMouseOverRow = dtGridViewRotinas.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    m.Items.Add("Executar Rotina Agora").Name = "ExecutarRotinaAgora";
                }

                m.Show(dtGridViewRotinas, new Point(e.X, e.Y));

                m.ItemClicked += M_ItemClicked;
            }
        }

        private void M_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            switch (e.ClickedItem.Name.ToString())
            {
                case "ExecutarRotinaAgora":

                    dynamic rootRotina = Shared.Helpers.LeArquivo(dtGridViewRotinas.SelectedRows[0].Cells["column_NomeRotinaJSON"].Value.ToString());

                    bool isRotinaBackup = Rotinas.Rotinas.IsRotinaBackup(rootRotina);

                    Rotinas.Rotinas.ExecutaJobRotina executaJobRotina = new Rotinas.Rotinas.ExecutaJobRotina(rootRotina, isRotinaBackup);

                    Task.Run(() => executaJobRotina.Execute());
                    
                    break;
            }
        }
    }
}
