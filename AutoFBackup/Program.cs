using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBackup
{
    internal static class Program
    {
        public static bool iniciarMinimizado { get; set; }

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Program.iniciarMinimizado = args != null && args.Any(arg => arg.Equals("iniciarMinimizado", StringComparison.CurrentCultureIgnoreCase));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
