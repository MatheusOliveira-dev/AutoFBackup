using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Shared
{
    public static class Helpers
    {
        public static bool VerificaArquivoExistente(string arquivo)
        {
            return File.Exists(string.Format(@"{0}", arquivo));
        }

        public static void CriaArquivo(string arquivo, string conteudo)
        {
            File.WriteAllText(arquivo, conteudo);
        }

        public static void EscreveArquivo(string arquivo, string conteudo)
        {

            conteudo = string.Format("\n\n[X] {0} [{1}-{2}]", conteudo, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

            File.AppendAllText(arquivo, conteudo);
        }

        public static string LeArquivo(string arquivo)
        {
            return File.ReadAllText(arquivo);
        }

        //get all files from a directory
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
                File.Delete(arquivo);
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

            if (adicionarAtualizar)
                rk.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
            else
                rk.DeleteValue(Application.ProductName, false);
        }
    }
}
