using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace Shared
{
    public static class Helpers
    {
        public static bool VerificaArquivoExistente(string arquivo)
        {
            return System.IO.File.Exists(string.Format(@"{0}", arquivo));
        }

        public static void CriaArquivo(string arquivo, string conteudo)
        {
            System.IO.File.WriteAllText(arquivo, conteudo);
        }

        public static void EscreveArquivo(string arquivo, string conteudo)
        {

            conteudo = string.Format("\n\n[X] {0} [{1}-{2}]", conteudo, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

            System.IO.File.AppendAllText(arquivo, conteudo);
        }

        public static string LeArquivo(string arquivo)
        {
            return System.IO.File.ReadAllText(arquivo);
        }

        public static List<string> ObtemArquivosDiretorio(string diretorio, string extensoes)
        {
            List<string> listArquivos = new List<string>();

            foreach (string arquivo in Directory.GetFiles(diretorio, "*.*", SearchOption.AllDirectories).Where(s => extensoes.Contains(Path.GetExtension(s).ToLower())))
            {
                listArquivos.Add(arquivo);
            }

            return listArquivos;
        }

        public static void ExcluiArquivo(string arquivo)
        {
            if (VerificaArquivoExistente(arquivo))
            {
                System.IO.File.Delete(arquivo);
            }
        }

        public static void CriaDiretorio(string diretorio)
        {
            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }
        }
        public static int ConverteStringParaNumero(string valor)
        {
            int numero;
            int.TryParse(valor, out numero);

            return numero;
        }

        public static string GeraUidRotinaBackup(string identificador)
        {
            return string.Format("{0}{1}{2}", identificador.Replace(" ", null), DateTime.Now.ToShortDateString().Replace("/", null),  DateTime.Now.ToLongTimeString().Replace(":", null));
        }
        public static string FormataMensagemParaEnvioTelegram(string mensagem)
        {
            return mensagem.Replace(@"\", "/").Replace("-", @"\").Replace(".", @"\");
        }

        public static string ObtemVersaoAutoFBackup()
        {
            return Application.ProductVersion;
        }

        public static void HabilitaDesabilitaInicializacaoComWindows(bool adicionarAtualizar)
        {
           
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.DeleteValue(Application.ProductName, false);

           
            WshShell wshShell = new WshShell();
            IWshRuntimeLibrary.IWshShortcut atalhoLnkAutoFBackup;

            string startUpDiretorio =
              Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            atalhoLnkAutoFBackup =
              (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(string.Format(@"{0}\AutoFBackup.lnk", startUpDiretorio));

            if (adicionarAtualizar)
            {
                atalhoLnkAutoFBackup.TargetPath = Application.ExecutablePath;
                atalhoLnkAutoFBackup.WorkingDirectory = Application.StartupPath;
                atalhoLnkAutoFBackup.Description = "Executa o AutoFBackup com o Windows";
                atalhoLnkAutoFBackup.Arguments = "iniciarMinimizado";
                atalhoLnkAutoFBackup.Save();
            }
            else
            {
                ExcluiArquivo(string.Format(@"{0}\AutoFBackup.lnk", startUpDiretorio));
            }
        }

        public static bool IniciadoComWindows()
        {
            return true;
        }

        public static string Base64Encode(string texto)
        {
            var textoBytes = System.Text.Encoding.UTF8.GetBytes(texto);
            return System.Convert.ToBase64String(textoBytes);
        }

        public static string Base64Decode(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
                return string.Empty;

            var base64Bytes = System.Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(base64Bytes);
        }
    }
}
