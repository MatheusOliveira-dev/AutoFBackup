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
        public static bool emModoCLI { get; set; }
        public static string arquivoJSONRotinaBackup { get; set; }

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Program.iniciarMinimizado = args != null && args.Any(arg => arg.Equals("iniciarMinimizado", StringComparison.CurrentCultureIgnoreCase));

            int argumentoArquivoJSONRotinaBackup = Array.IndexOf(args, "arquivoJSONRotinaBackup");

            if (argumentoArquivoJSONRotinaBackup != -1 && args.Length > argumentoArquivoJSONRotinaBackup + 1 && !string.IsNullOrEmpty(args[argumentoArquivoJSONRotinaBackup + 1]))
            {
                Program.emModoCLI = true;
                Program.arquivoJSONRotinaBackup = args[argumentoArquivoJSONRotinaBackup + 1];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
