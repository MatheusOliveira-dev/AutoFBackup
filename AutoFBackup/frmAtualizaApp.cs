using AutoUpdaterDotNET;
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
    public partial class frmAtualizaApp : Form
    {
        public frmAtualizaApp()
        {
            InitializeComponent();
        }

        private void frmAtualizaApp_Load(object sender, EventArgs e)
        {
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Mandatory = true;
            AutoUpdater.Synchronous = true;
            AutoUpdater.Start("https://raw.githubusercontent.com/MatheusOliveira-dev/AutoFBackupUpdater/main/Update.xml");
            this.Close();
        }
    }
}
