using FluentScheduler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Models.Backup;

namespace Backup
{
    public class Backup
    {
        public List<Root_Backup> ObtemRotinasBackups()
        {
            List<string> listArquivosRotinas = Shared.Helpers.ObtemArquivosDiretorio("Rotinas", "*.json");

            List<Root_Backup> lstRootBackups = new List<Root_Backup>(); 

            foreach (string arquivo in listArquivosRotinas)
            {
                Root_Backup root_Backup = JsonConvert.DeserializeObject<Root_Backup>(Shared.Helpers.LeArquivo(arquivo));

                lstRootBackups.Add(root_Backup);
            }

            return lstRootBackups;
        }
        public void CriaRotinaBackup(Root_Backup rootBackup)
        {
            Shared.Helpers.CriaArquivo(string.Format(@"Rotinas\{0}.json", string.Format("{0}{1}{2}", rootBackup.BancoDeDados.Identificador.Replace(" ", null), rootBackup.CriacaoBackup.Frequencia.Tipo, DateTime.Now.ToLongTimeString().Replace(":", null))), JsonConvert.SerializeObject(rootBackup));
        }

        public class RegistroTarefasAgendadas : Registry
        {
            public RegistroTarefasAgendadas(List<Root_Backup> lstRoot_Backups)
            {
                foreach (Root_Backup root_Backup in lstRoot_Backups)
                {
                    string nomeJob = Shared.Helpers.GeraUidRotinaBackup(root_Backup.BancoDeDados.Identificador);

                    int hora = Shared.Helpers.ConverteStringParaNumero(root_Backup.CriacaoBackup.Frequencia.Hora);
                    int minutos = Shared.Helpers.ConverteStringParaNumero(root_Backup.CriacaoBackup.Frequencia.Minuto);
                    string tipo = root_Backup.CriacaoBackup.Frequencia.Tipo;
                    bool executaIniAppHoraMinuto = root_Backup.CriacaoBackup.Frequencia.ExecutaNaInicializacaoApp;

                    List<string> diasSemana = root_Backup.CriacaoBackup.Frequencia.DiasSemana;

                    switch (tipo)
                    {
                        case "Hora":
                         
                            Schedule(() => new ExecutaJobBackup(root_Backup))
                                .NonReentrant()
                                .WithName(nomeJob)
                                .ToRunEvery(hora)
                                .Hours();
                            break;

                        case "HoraMinuto":
                            if (!string.IsNullOrWhiteSpace(root_Backup.CriacaoBackup.Frequencia.Minuto) && minutos > 0)
                            {
                                if (executaIniAppHoraMinuto)
                                {
                                    Schedule(() => new ExecutaJobBackup(root_Backup))
                                       .NonReentrant()
                                       .WithName(nomeJob)
                                       .ToRunNow()
                                       .AndEvery(minutos)
                                       .Minutes();
                                }
                                else
                                {
                                    Schedule(() => new ExecutaJobBackup(root_Backup))
                                       .NonReentrant()
                                       .WithName(nomeJob)
                                       .ToRunEvery(minutos)
                                       .Minutes();
                                }
                            }
                            else
                            {
                                if (executaIniAppHoraMinuto)
                                {
                                    Schedule(() => new ExecutaJobBackup(root_Backup))
                                       .NonReentrant()
                                       .WithName(nomeJob)
                                       .ToRunNow()
                                       .AndEvery(hora)
                                       .Hours();
                                }
                                else
                                {
                                    Schedule(() => new ExecutaJobBackup(root_Backup))
                                       .NonReentrant()
                                       .WithName(nomeJob)
                                       .ToRunEvery(hora)
                                       .Hours();
                                }
                            }

                            break;

                        case "Diaria":
                            Schedule(() => new ExecutaJobBackup(root_Backup))
                                .NonReentrant()
                                .WithName(nomeJob)
                                .ToRunEvery(0)
                                .Days()
                                .At(hora, minutos);
                            break;

                        case "Semanal":
                            foreach (var diaSemana in diasSemana)
                            {
                                switch (diaSemana)
                                {
                                    case "Segunda-Feira":
                                        Schedule(() => new ExecutaJobBackup(root_Backup))
                                            .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Monday).At(hora, minutos);
                                        break;
                                    case "Terca-Feira":
                                        Schedule(() => new ExecutaJobBackup(root_Backup))
                                            .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Tuesday).At(hora, minutos);
                                        break;
                                    case "Quarta-Feira":
                                        Schedule(() => new ExecutaJobBackup(root_Backup))
                                            .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Wednesday).At(hora, minutos);
                                        break;
                                    case "Quinta-Feira":
                                        Schedule(() => new ExecutaJobBackup(root_Backup))
                                                  .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Thursday).At(hora, minutos);
                                        break;
                                    case "Sexta-Feira":
                                        Schedule(() => new ExecutaJobBackup(root_Backup))
                                            .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Friday).At(hora, minutos);
                                        break;
                                    case "Sabado":
                                        Schedule(() => new ExecutaJobBackup(root_Backup))
                                            .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Saturday).At(hora, minutos);
                                        break;
                                    case "Domingo":
                                        Schedule(() => new ExecutaJobBackup(root_Backup))
                                            .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Sunday).At(hora, minutos);
                                        break;
                                }
                            }

                            break;
                    }
                }
            }
        }


        public static bool ExecutaBackup(Root_Backup root_Backup, bool geraLogTxt, bool compactaBackupZip, string uidRotinaBackup)
        {
            string dadosDaConexao = string.Format("DataSource={0};Database={1};User={2};Password={3};Port={4};Dialect=3;",
                   root_Backup.BancoDeDados.Servidor, root_Backup.BancoDeDados.Caminho,
                   root_Backup.BancoDeDados.Usuario, root_Backup.BancoDeDados.Senha,
                   root_Backup.BancoDeDados.Porta);

            string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;

            Firebird.Backup firebirdBackup = new Firebird.Backup(geraLogTxt, compactaBackupZip, dadosDaConexao,
                root_Backup.CriacaoBackup.Opcoes.FlagsBackup, uidRotinaBackup, diretorioBackups);

            return firebirdBackup.ExecutaBackup();
        }

        public static void ExecutaGfix(Root_Backup root_Backup, string uidRotinaBackup)
        {

            if (root_Backup.CriacaoBackup.Opcoes.ExecutaGfix != null 
                && root_Backup.CriacaoBackup.Opcoes.ExecutaGfix.Ativo)
            {
                string usuarioBancoDeDados = root_Backup.BancoDeDados.Usuario;
                string senhaBancoDeDados = root_Backup.BancoDeDados.Senha;
                string servidorBancoDeDados = root_Backup.BancoDeDados.Servidor;
                string caminhoBancoDeDados = root_Backup.BancoDeDados.Caminho;

                string caminhoGfix = root_Backup.CriacaoBackup.Opcoes.ExecutaGfix.CaminhoGfix;
                string argumentosGfix = root_Backup.CriacaoBackup.Opcoes.ExecutaGfix.ArgumentosGfix;

                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;


                Firebird.Gfix firebirdGfix = new Firebird.Gfix(usuarioBancoDeDados, senhaBancoDeDados,
                    servidorBancoDeDados, caminhoBancoDeDados, caminhoGfix, argumentosGfix, uidRotinaBackup, diretorioBackups);

                firebirdGfix.ExecutaGfix();
            }
        }

        public static void ExcluiBackupsAntigosLocal(Root_Backup root_Backup, string uidRotinaBackup)
        {
            if (root_Backup.CriacaoBackup.Opcoes.ExcluirBackupsAntigosLocal.Ativo)
            {
                string diasExcluir = root_Backup.CriacaoBackup.Opcoes.ExcluirBackupsAntigosLocal.Dias;
                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;

                Firebird.Delete firebirdDelete = new Firebird.Delete();
                firebirdDelete.ExcluiBackupsAntigos(diretorioBackups, diasExcluir, uidRotinaBackup);
            }
        }

        public static async void EnviaNotificacaoSucessoTelegram(Root_Backup root_Backup, string uidRotinaBackup, 
            string conclusaoBackup, bool backupCompactado)
        {
            Integracoes.Telegram integracoesTelegram = new Integracoes.Telegram();

            if (root_Backup.Integracoes.Notificacoes.Telegram.Ativo)
            {
                string accessTokenBot = integracoesTelegram.ObtemIntegracaoTelegram().Credenciais.AccessTokenBot;
                string chatIDDestino = root_Backup.Integracoes.Notificacoes.Telegram.Envio.ChatIDDestino;

                string identificadorBancoDeDados = root_Backup.BancoDeDados.Identificador;
                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;


                Telegram.Notificacao telegramNotificacao = new Telegram.Notificacao(accessTokenBot, chatIDDestino,
                    identificadorBancoDeDados, diretorioBackups, uidRotinaBackup, conclusaoBackup, backupCompactado);

                telegramNotificacao.EnviaMensagemSucesso();

                if (root_Backup.Integracoes.Notificacoes.Telegram.Envio.Opcoes.ReceberLogTxt)
                {
                    await telegramNotificacao.EnviaLogTxtAsync("LogBackup");
                }
            }
        }

        public static void EnviaNotificacaoSucessoEmail(Root_Backup root_Backup, string uidRotinaBackup,
            string conclusaoBackup, bool compactaBackupZip)
        {
            Integracoes.Email integracoesEmail = new Integracoes.Email();

            if (root_Backup.Integracoes.Notificacoes.Email.Ativo)
            {
                string identificadorBancoDeDados = root_Backup.BancoDeDados.Identificador;
                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;

                string host = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Host;
                string porta = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Porta;
                string usuario = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Usuario;
                string senha = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Senha;
                bool ssl = integracoesEmail.ObtemIntegracaoEmail().Credenciais.SSL;
                string destinatarios = root_Backup.Integracoes.Notificacoes.Email.Envio.Destinatarios;
                string assunto = root_Backup.Integracoes.Notificacoes.Email.Envio.Assunto;

                Email.Notificacao emailNotificacao = new Email.Notificacao(host, porta, usuario, senha, ssl,
                    destinatarios, root_Backup.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberLogTxt,
                    assunto, identificadorBancoDeDados, diretorioBackups, uidRotinaBackup, conclusaoBackup, compactaBackupZip);

                emailNotificacao.EnviaNotificacao();
            }
        }

        public static void EnviaBackupParaMeganz(Root_Backup root_Backup, string uidRotinaBackup,
            bool compactaBackupZip)
        {
            Integracoes.MegaNZ integracoesMegaNZ = new Integracoes.MegaNZ();

            if (root_Backup.Integracoes.Uploads.MegaNZ.Ativo)
            {
                MegaNZ.Upload megaNZUpload = new MegaNZ.Upload();

                string email = integracoesMegaNZ.ObtemIntegracaoMegaNZ().Credenciais.Email;
                string senha = integracoesMegaNZ.ObtemIntegracaoMegaNZ().Credenciais.Senha;

                string pasta = root_Backup.Integracoes.Uploads.MegaNZ.Envio.Pasta;
                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;

                megaNZUpload.ExecutaUpload(email, senha, pasta, diretorioBackups, uidRotinaBackup, compactaBackupZip);
            }
        }

        public static void EnviaBackupParaFTP(Root_Backup root_Backup, string uidRotinaBackup, bool compactaBackupZip)
        {
            Integracoes.FTP integracoesFTP = new Integracoes.FTP();

            if (root_Backup.Integracoes.Uploads.FTP.Ativo)
            {
                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;

                FTP.Upload ftpUpload = new FTP.Upload();

                string host = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Host;
                string porta = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Porta;
                string usuario = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Usuario;
                string senha = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Senha;

                string diretorioUploadRemoto = root_Backup.Integracoes.Uploads.FTP.Envio.Diretorio;

                ftpUpload.ExecutaUpload(host, porta, usuario, senha, diretorioUploadRemoto, uidRotinaBackup,
                    diretorioBackups, compactaBackupZip);
            }
        }
        
        public static void ExcluiBackupsAntigosFTP(Root_Backup root_Backup, string uidRotinaBackup)
        {

            Integracoes.FTP integracoesFTP = new Integracoes.FTP();

            if (root_Backup.Integracoes.Uploads.FTP.Ativo && 
                root_Backup.Integracoes.Uploads.FTP.Envio.Opcoes.ExcluirBackupsAntigos.Ativo)
            {
                FTP.Delete ftpDelete = new FTP.Delete();
                
                string host = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Host;
                string porta = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Porta;
                string usuario = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Usuario;
                string senha = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Senha;

                string diretorioUploadRemoto = root_Backup.Integracoes.Uploads.FTP.Envio.Diretorio;
                string diretorioBackupsLocal = root_Backup.CriacaoBackup.Diretorio_Backup;

                ftpDelete.ExcluiBackupsAntigos(host, porta, usuario, senha, diretorioUploadRemoto,
                    root_Backup.Integracoes.Uploads.FTP.Envio.Opcoes.ExcluirBackupsAntigos.Dias,
                    uidRotinaBackup, diretorioBackupsLocal);
            }
        }

        public static async void EnviaNotificacaoErroTelegram(Root_Backup root_Backup, string uidRotinaBackup)
        {
            Integracoes.Telegram integracoesTelegram = new Integracoes.Telegram();

            if (root_Backup.Integracoes.Notificacoes.Telegram.Ativo &&
                            root_Backup.Integracoes.Notificacoes.Telegram.Envio.Opcoes.ReceberNotificacoesErros)
            {
                string accessTokenBot = integracoesTelegram.ObtemIntegracaoTelegram().Credenciais.AccessTokenBot;
                string chatIDDestino = root_Backup.Integracoes.Notificacoes.Telegram.Envio.ChatIDDestino;

                string identificadorBancoDeDados = root_Backup.BancoDeDados.Identificador;

                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;

                Telegram.Notificacao telegramNotificacao = new Telegram.Notificacao(accessTokenBot, chatIDDestino,
                    identificadorBancoDeDados, diretorioBackups, uidRotinaBackup, string.Empty, false);

                telegramNotificacao.EnviaMensagemErro();

                await telegramNotificacao.EnviaLogTxtAsync("LogErroBackup");
            }
        }

        public static void EnviaNotificacaoErroEmail(Root_Backup root_Backup, string uidRotinaBackup)
        {
            Integracoes.Email integracoesEmail = new Integracoes.Email();

            if (root_Backup.Integracoes.Notificacoes.Email.Ativo &&
                           root_Backup.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberEmailErros)
            {
                string host = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Host;
                string porta = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Porta;
                string usuario = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Usuario;
                string senha = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Senha;
                bool ssl = integracoesEmail.ObtemIntegracaoEmail().Credenciais.SSL;
                string destinatarios = root_Backup.Integracoes.Notificacoes.Email.Envio.Destinatarios;
                string assunto = root_Backup.Integracoes.Notificacoes.Email.Envio.Assunto;

                string identificadorBancoDeDados = root_Backup.BancoDeDados.Identificador;

                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;


                Email.Notificacao emailNotificacao = new Email.Notificacao(host, porta, usuario, senha, ssl,
                    destinatarios, root_Backup.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberLogTxt,
                    assunto, identificadorBancoDeDados, diretorioBackups, uidRotinaBackup, string.Empty,
                    false);

                emailNotificacao.EnviaNotificacaoErro();
            }
        }

        public static void ExecutaAplicativoPreBackup(Root_Backup root_Backup, string uidRotinaBackup)
        {
            if (!string.IsNullOrWhiteSpace(root_Backup.CriacaoBackup.Opcoes.AplicativoPreBackup.Aplicativo))
            {

              

                string aplicativo = root_Backup.CriacaoBackup.Opcoes.AplicativoPreBackup.Aplicativo;
                string argumentos = root_Backup.CriacaoBackup.Opcoes.AplicativoPreBackup.Argumentos;

                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;


                if (!File.Exists(aplicativo))
                {

                    Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackups, uidRotinaBackup),
                    string.Format("Execução do Aplicativo Pré-Backup abortada -> {0}", "O Aplicativo Informado não existe."));
                    return;
                }

                Process aplicativoProcesso = new Process();

                aplicativoProcesso.StartInfo.CreateNoWindow = false;
                aplicativoProcesso.StartInfo.UseShellExecute = false;
                aplicativoProcesso.StartInfo.FileName = aplicativo;
                aplicativoProcesso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                if (!string.IsNullOrWhiteSpace(argumentos))
                {
                    aplicativoProcesso.StartInfo.Arguments = argumentos;
                }

                aplicativoProcesso.Start();

                if (root_Backup.CriacaoBackup.Opcoes.AplicativoPreBackup.AguardaConclusao)
                {
                    aplicativoProcesso.WaitForExit();
                }
            }
        }

        public static void ExecutaAplicativoPosBackup(Root_Backup root_Backup, string uidRotinaBackup)
        {
            if (!string.IsNullOrWhiteSpace(root_Backup.CriacaoBackup.Opcoes.AplicativoPosBackup.Aplicativo))
            {
                string aplicativo = root_Backup.CriacaoBackup.Opcoes.AplicativoPosBackup.Aplicativo;
                string argumentos = root_Backup.CriacaoBackup.Opcoes.AplicativoPosBackup.Argumentos;

                string diretorioBackups = root_Backup.CriacaoBackup.Diretorio_Backup;

                if (!File.Exists(aplicativo))
                {

                    Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", diretorioBackups, uidRotinaBackup),
                    string.Format("Execução do Aplicativo Pós-Backup abortada -> {0}", "O Aplicativo Informado não existe."));
                    return;
                }

                Process aplicativoProcesso = new Process();

                aplicativoProcesso.StartInfo.CreateNoWindow = false;
                aplicativoProcesso.StartInfo.UseShellExecute = false;
                aplicativoProcesso.StartInfo.FileName = aplicativo;
                aplicativoProcesso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                if (!string.IsNullOrWhiteSpace(argumentos))
                {
                    aplicativoProcesso.StartInfo.Arguments = argumentos;
                }

                aplicativoProcesso.Start();
            }
        }

        public class ExecutaJobBackup : IJob
        {
            Root_Backup _root_Backup;

            public ExecutaJobBackup(Root_Backup root_Backup)
            {
                _root_Backup = root_Backup;
            }
            public void Execute()
            {
                string identificadorBancoDeDados = _root_Backup.BancoDeDados.Identificador;
                string uidRotinaBackup = Shared.Helpers.GeraUidRotinaBackup(identificadorBancoDeDados);

                bool geraLogTxt = _root_Backup.Integracoes.Notificacoes.Telegram.Envio.Opcoes.ReceberLogTxt.Equals(true) ||
                    _root_Backup.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberLogTxt.Equals(true);

                bool compactaBackupZip = _root_Backup.CriacaoBackup.Opcoes.FlagsBackup.Contains("Compactar");

                ExecutaAplicativoPreBackup(_root_Backup, uidRotinaBackup);

                ExecutaGfix(_root_Backup, uidRotinaBackup);

                if (ExecutaBackup(_root_Backup, geraLogTxt, compactaBackupZip, uidRotinaBackup))
                {
                    string conclusaoBackup = string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

                    ExcluiBackupsAntigosLocal(_root_Backup, uidRotinaBackup);
                    EnviaNotificacaoSucessoTelegram(_root_Backup, uidRotinaBackup, conclusaoBackup, compactaBackupZip);
                    EnviaNotificacaoSucessoEmail(_root_Backup, uidRotinaBackup, conclusaoBackup, compactaBackupZip);
                    EnviaBackupParaMeganz(_root_Backup, uidRotinaBackup, compactaBackupZip);
                    EnviaBackupParaFTP(_root_Backup, uidRotinaBackup, compactaBackupZip);
                    ExcluiBackupsAntigosFTP(_root_Backup, uidRotinaBackup);
                    ExecutaAplicativoPosBackup(_root_Backup, uidRotinaBackup);
                }
                else
                {
                    EnviaNotificacaoErroTelegram(_root_Backup, uidRotinaBackup);
                    EnviaNotificacaoErroEmail(_root_Backup, uidRotinaBackup);
                }
            }
        }
    }
}
