using FluentScheduler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram;
using static FBackup.Models.ReplicacaoDeDados;
using static Models.Backup;

namespace Rotinas
{
    public class Rotinas
    {
        public List<dynamic> ObtemArquivosRotinas()
        {
            List<string> listArquivosRotinas = Shared.Helpers.ObtemArquivosDiretorio("Rotinas", "*.json");

            List<dynamic> lstRootRotinas = new List<dynamic>(); 

            foreach (string arquivo in listArquivosRotinas)
            {
                dynamic rootRotina = Shared.Helpers.LeArquivo(arquivo);

                lstRootRotinas.Add(rootRotina);
            }

            return lstRootRotinas;
        }
        public void CriaArquivoRotina(dynamic rootRotina, bool isRotinaBackup)
        {
            if (isRotinaBackup)
            {
                Shared.Helpers.CriaArquivo(string.Format(@"Rotinas\{0}.json", string.Format("{0}{1}{2}", rootRotina.BancoDeDados.Identificador.Replace(" ", null), rootRotina.CriacaoBackup.Frequencia.Tipo, DateTime.Now.ToLongTimeString().Replace(":", null))), JsonConvert.SerializeObject(rootRotina));
            }
            else
            {
                Shared.Helpers.CriaArquivo(string.Format(@"Rotinas\{0}.json", string.Format("{0}{1}{2}", rootRotina.Principal.Identificador.Replace(" ", null), rootRotina.Principal.Frequencia.Tipo, DateTime.Now.ToLongTimeString().Replace(":", null))), JsonConvert.SerializeObject(rootRotina));
            }
        }

        public static bool IsRotinaBackup(dynamic rootRotina)
        {
            var jsonObject = JObject.Parse(rootRotina);

            if (jsonObject["TipoRotina"] != null && jsonObject["TipoRotina"].ToString() == "REPLICACAO_DE_DADOS")
            {
                return false;
            }
            else
            {
                return true;
            
            }
        }

        public class RegistroTarefasAgendadas : Registry
        {
            public RegistroTarefasAgendadas(List<dynamic> lstRootRotinas, bool rotinaBackupManual = false)
            {
                foreach (dynamic rootRotina in lstRootRotinas)
                {
                    Root_Backup rootRotina_Backup = null;
                    Root_ReplicacaoDeDados rootRotina_ReplicacaoDeDados = null;

                    bool isRotinaBackup = IsRotinaBackup(rootRotina);

                    if (isRotinaBackup)
                        rootRotina_Backup = JsonConvert.DeserializeObject<Root_Backup>(rootRotina);
                    else
                        rootRotina_ReplicacaoDeDados = JsonConvert.DeserializeObject<Root_ReplicacaoDeDados>(rootRotina);


                    string nomeJob = (isRotinaBackup || rotinaBackupManual) ?  
                        Shared.Helpers.GeraUidRotinaBackup(rootRotina_Backup.BancoDeDados.Identificador) 
                        : Shared.Helpers.GeraUidRotinaBackup(rootRotina_ReplicacaoDeDados.Principal.Identificador);

                    int hora = (isRotinaBackup || rotinaBackupManual) ?
                        Shared.Helpers.ConverteStringParaNumero(rootRotina_Backup.CriacaoBackup.Frequencia.Hora)
                        : Shared.Helpers.ConverteStringParaNumero(rootRotina_ReplicacaoDeDados.Principal.Frequencia.Hora);


                        int minutos = (isRotinaBackup || rotinaBackupManual) ?
                        Shared.Helpers.ConverteStringParaNumero(rootRotina_Backup.CriacaoBackup.Frequencia.Minuto)
                        : Shared.Helpers.ConverteStringParaNumero(rootRotina_ReplicacaoDeDados.Principal.Frequencia.Minuto);


                    string tipoFrquencia = (isRotinaBackup || rotinaBackupManual) ?
                        rootRotina_Backup.CriacaoBackup.Frequencia.Tipo 
                        : rootRotina_ReplicacaoDeDados.Principal.Frequencia.Tipo;

                    bool executaIniAppHoraMinuto = false; 

                    if (isRotinaBackup || rotinaBackupManual)
                    {
                        executaIniAppHoraMinuto = rootRotina_Backup.CriacaoBackup.Frequencia.ExecutaNaInicializacaoApp;
                    }


                    List<string> diasSemana = (isRotinaBackup || rotinaBackupManual) ?
                        rootRotina_Backup.CriacaoBackup.Frequencia.DiasSemana 
                        : rootRotina_ReplicacaoDeDados.Principal.Frequencia.DiasSemana;

                    switch (tipoFrquencia)
                    {
                        case "Hora":
                         
                            Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                .NonReentrant()
                                .WithName(nomeJob)
                                .ToRunEvery(hora)
                                .Hours();
                            break;

                        case "HoraMinuto":
                            if (!string.IsNullOrWhiteSpace(
                                (isRotinaBackup || rotinaBackupManual) 
                                ? rootRotina_Backup.CriacaoBackup.Frequencia.Minuto 
                                : rootRotina_ReplicacaoDeDados.Principal.Frequencia.Minuto) && minutos > 0)
                            {
                                if (executaIniAppHoraMinuto)
                                {
                                    Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                      .NonReentrant()
                                       .WithName(nomeJob)
                                       .ToRunNow()
                                       .AndEvery(minutos)
                                       .Minutes();
                                }
                                else
                                {
                                    Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
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
                                    Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                       .NonReentrant()
                                       .WithName(nomeJob)
                                       .ToRunNow()
                                       .AndEvery(hora)
                                       .Hours();
                                }
                                else
                                {
                                    Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                      .NonReentrant()
                                       .WithName(nomeJob)
                                       .ToRunEvery(hora)
                                       .Hours();
                                }
                            }

                            break;

                        case "Diaria":
                            Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
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
                                        Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                           .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Monday).At(hora, minutos);
                                        break;
                                    case "Terca-Feira":
                                        Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                              .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Tuesday).At(hora, minutos);
                                        break;
                                    case "Quarta-Feira":
                                        Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                           .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Wednesday).At(hora, minutos);
                                        break;
                                    case "Quinta-Feira":
                                        Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                                  .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Thursday).At(hora, minutos);
                                        break;
                                    case "Sexta-Feira":
                                        Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                           .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Friday).At(hora, minutos);
                                        break;
                                    case "Sabado":
                                        Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
                                           .NonReentrant()
                                            .WithName(nomeJob)
                                            .ToRunEvery(0)
                                            .Weeks()
                                            .On(DayOfWeek.Saturday).At(hora, minutos);
                                        break;
                                    case "Domingo":
                                        Schedule(() => new ExecutaJobRotina(rootRotina, (isRotinaBackup || rotinaBackupManual)))
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
            string extensaoArquivoBackup = root_Backup.CriacaoBackup.Opcoes.ExtensaoBackup != null ? root_Backup.CriacaoBackup.Opcoes.ExtensaoBackup : ".fbk";

            Firebird.Backup firebirdBackup = new Firebird.Backup(geraLogTxt, compactaBackupZip, dadosDaConexao,
                root_Backup.CriacaoBackup.Opcoes.FlagsBackup, uidRotinaBackup, diretorioBackups, extensaoArquivoBackup);

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

                bool habilitaExclusaoArquivosExtensaoDifFk = root_Backup.CriacaoBackup.Opcoes.ExcluirBackupsAntigosLocal.HabilitarExclusaoExtensoesDifBkp;

                Firebird.Delete firebirdDelete = new Firebird.Delete();
                firebirdDelete.ExcluiBackupsAntigos(diretorioBackups, diasExcluir, uidRotinaBackup, habilitaExclusaoArquivosExtensaoDifFk);
            }
        }

        public static async void EnviaNotificacaoSucessoTelegram(dynamic rootRotina, string uidRotina, 
            string conclusaoBackup, bool backupCompactado, int arquivosPendentesReplicacaoDeDados, 
            int arquivosEnviadosReplicacaoDeDados, bool isRotinaBackup)
        {
            Integracoes.Telegram integracoesTelegram = new Integracoes.Telegram();
            
            Root_Backup rootRotina_Backup = null;
            Root_ReplicacaoDeDados rootRotina_ReplicacaoDeDados = null;

            string diretorioLogsSucessoReplicacaoDados = string.Empty;
            string diretorioLogsErro = string.Empty;

           

            if (isRotinaBackup)
            {
                rootRotina_Backup = JsonConvert.DeserializeObject<Root_Backup>(rootRotina);
            }
            else
            {
                rootRotina_ReplicacaoDeDados = JsonConvert.DeserializeObject<Root_ReplicacaoDeDados>(rootRotina);

                diretorioLogsSucessoReplicacaoDados = rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.CriarDiretorioFilhoDataDia
                    ? System.IO.Path.Combine(rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsSucesso, DateTime.Now.ToShortDateString().Replace("/", string.Empty))
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsSucesso;

                diretorioLogsErro = rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.CriarDiretorioFilhoDataDia
                    ? System.IO.Path.Combine(rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro, DateTime.Now.ToShortDateString().Replace("/", string.Empty))
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro;
            }
               


            if (isRotinaBackup 
                ? rootRotina_Backup.Integracoes.Notificacoes.Telegram.Ativo
                : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Telegram.Ativo)
            {
                string accessTokenBot = integracoesTelegram.ObtemIntegracaoTelegram().Credenciais.AccessTokenBot;
                
                string chatIDDestino = isRotinaBackup 
                    ? rootRotina_Backup.Integracoes.Notificacoes.Telegram.Envio.ChatIDDestino
                    : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Telegram.Envio.ChatIDDestino;

                string identificadorRotina = isRotinaBackup 
                    ? rootRotina_Backup.BancoDeDados.Identificador 
                    : rootRotina_ReplicacaoDeDados.Principal.Identificador;
                
                
                string diretorioBackupOuReplicacaoDeDados = isRotinaBackup 
                    ? rootRotina_Backup.CriacaoBackup.Diretorio_Backup
                    : diretorioLogsSucessoReplicacaoDados;


                Telegram.Notificacao telegramNotificacao = new Telegram.Notificacao(accessTokenBot, chatIDDestino,
                    identificadorRotina, uidRotina, conclusaoBackup, isRotinaBackup, diretorioBackupOuReplicacaoDeDados, 
                    isRotinaBackup ? string.Empty
                    : diretorioLogsErro);

                await telegramNotificacao.EnviaMensagemSucesso(backupCompactado, arquivosPendentesReplicacaoDeDados, arquivosEnviadosReplicacaoDeDados);

                if (isRotinaBackup 
                    ? rootRotina_Backup.Integracoes.Notificacoes.Telegram.Envio.Opcoes.ReceberLogTxt
                    : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Telegram.Envio.Opcoes.ReceberNotificacoesSucesso)
                {
                    await telegramNotificacao.EnviaLogTxtAsync(isRotinaBackup ? "LogBackup" : "LogReplicacaoDeDados");
                }
            }
        }

        public static void EnviaNotificacaoSucessoEmail(dynamic rootRotina, string uidRotina,
            string conclusaoRotina, bool compactaBackupZip, int arquivosPendentesReplicacaoDeDados, 
            int arquivosEnviadosReplicacaoDeDados, bool isRotinaBackup)
        {
            Integracoes.Email integracoesEmail = new Integracoes.Email();

            string diretorioLogsSucessoReplicacaoDados = string.Empty;
            string diretorioLogsErro = string.Empty;

            Root_Backup rootRotina_Backup = null;
            Root_ReplicacaoDeDados rootRotina_ReplicacaoDeDados = null;

            if (isRotinaBackup)
            {
                rootRotina_Backup = JsonConvert.DeserializeObject<Root_Backup>(rootRotina);
            }
            else
            {
                rootRotina_ReplicacaoDeDados = JsonConvert.DeserializeObject<Root_ReplicacaoDeDados>(rootRotina);

                diretorioLogsSucessoReplicacaoDados = rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.CriarDiretorioFilhoDataDia
                    ? System.IO.Path.Combine(rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsSucesso, DateTime.Now.ToShortDateString().Replace("/", string.Empty))
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsSucesso;

                diretorioLogsErro = rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.CriarDiretorioFilhoDataDia
                    ? System.IO.Path.Combine(rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro, DateTime.Now.ToShortDateString().Replace("/", string.Empty))
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro;
            }


            if (isRotinaBackup 
                ? rootRotina_Backup.Integracoes.Notificacoes.Email.Ativo
                : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Email.Ativo)
            {
                string identificadorRotina = isRotinaBackup
                   ? rootRotina_Backup.BancoDeDados.Identificador
                   : rootRotina_ReplicacaoDeDados.Principal.Identificador;


                string diretorioBackupOuReplicacaoDeDados = isRotinaBackup
                    ? rootRotina_Backup.CriacaoBackup.Diretorio_Backup
                    : diretorioLogsSucessoReplicacaoDados;

                string host = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Host;
                string porta = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Porta;
                string usuario = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Usuario;
                string senha = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Senha;
                bool ssl = integracoesEmail.ObtemIntegracaoEmail().Credenciais.SSL;

                string destinatarios = isRotinaBackup
                    ? rootRotina_Backup.Integracoes.Notificacoes.Email.Envio.Destinatarios
                    : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Email.Envio.Destinatarios;

                string assunto = isRotinaBackup 
                    ? rootRotina_Backup.Integracoes.Notificacoes.Email.Envio.Assunto
                    : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Email.Envio.Assunto;

                Email.Notificacao emailNotificacao = new Email.Notificacao(host, porta, usuario, senha, ssl,
                    destinatarios, 
                    isRotinaBackup 
                    ? rootRotina_Backup.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberLogTxt 
                    : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberNotificacoesSucesso,
                    assunto, identificadorRotina, diretorioBackupOuReplicacaoDeDados, uidRotina, conclusaoRotina, 
                    compactaBackupZip, isRotinaBackup, 
                    isRotinaBackup ? string.Empty
                    : diretorioLogsErro,
                    isRotinaBackup ? string.Empty
                    : diretorioLogsSucessoReplicacaoDados);

                emailNotificacao.EnviaNotificacao(arquivosPendentesReplicacaoDeDados, arquivosEnviadosReplicacaoDeDados);
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

                string extensaoBackup = root_Backup.CriacaoBackup.Opcoes.ExtensaoBackup != null ? root_Backup.CriacaoBackup.Opcoes.ExtensaoBackup : ".fbk";

                megaNZUpload.ExecutaUpload(email, senha, pasta, diretorioBackups, uidRotinaBackup, compactaBackupZip, extensaoBackup);
            }
        }

        public static void EnviaArquivoParaFTP(dynamic rootRotina, string uidRotinaBackup, bool compactaBackupZip,
            bool isRotinaBackup, string arquivoReplicacaoDeDados)
        {
            Integracoes.FTP integracoesFTP = new Integracoes.FTP();

            bool isIntegracaoFTPAtiva = false;

            Root_Backup rootRotina_Backup = null;
            Root_ReplicacaoDeDados rootRotina_ReplicacaoDeDados = null;

            if (isRotinaBackup)
            {
                rootRotina_Backup = JsonConvert.DeserializeObject<Root_Backup>(rootRotina);
                isIntegracaoFTPAtiva = rootRotina_Backup.Integracoes.Uploads.FTP.Ativo;
            }

            else
            {
                rootRotina_ReplicacaoDeDados = JsonConvert.DeserializeObject<Root_ReplicacaoDeDados>(rootRotina);
                isIntegracaoFTPAtiva = true;
            }
                

            if (isIntegracaoFTPAtiva)
            {
              
                string diretorioBackups = isRotinaBackup 
                    ? rootRotina_Backup.CriacaoBackup.Diretorio_Backup :
                    rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLocalOrigem;

                string host = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Host;
                string porta = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Porta;
                string usuario = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Usuario;
                string senha = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Senha;

                string diretorioUploadRemoto = isRotinaBackup
                    ? rootRotina_Backup.Integracoes.Uploads.FTP.Envio.Diretorio
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioRemotoDestino;

                string extensaoBackup = string.Empty; 
                
                if (isRotinaBackup)
                    extensaoBackup = rootRotina_Backup.CriacaoBackup.Opcoes.ExtensaoBackup != null ? rootRotina_Backup.CriacaoBackup.Opcoes.ExtensaoBackup : ".fbk";

                FTP.Upload ftpUpload = new FTP.Upload(host, porta, usuario, senha, diretorioUploadRemoto, uidRotinaBackup,
                    compactaBackupZip, extensaoBackup, diretorioBackups, isRotinaBackup, 
                    isRotinaBackup 
                    ? string.Empty
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro, false, string.Empty);

                ftpUpload.ExecutaUpload(arquivoReplicacaoDeDados);
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

                bool habilitaExclusaoArquivosExtensaoDifFk = root_Backup.Integracoes.Uploads.FTP.Envio.Opcoes.ExcluirBackupsAntigos.HabilitarExclusaoExtensoesDifBkp;

                ftpDelete.ExcluiBackupsAntigos(host, porta, usuario, senha, diretorioUploadRemoto,
                    root_Backup.Integracoes.Uploads.FTP.Envio.Opcoes.ExcluirBackupsAntigos.Dias,
                    uidRotinaBackup, diretorioBackupsLocal, habilitaExclusaoArquivosExtensaoDifFk);
            }
        }

        public static async void EnviaNotificacaoErroTelegram(dynamic rootRotina, string uidRotina, 
            int arquivosPendentesReplicacaoDeDados, int arquivosEnviadosReplicacaoDeDados, bool isRotinaBackup)
        {
            Integracoes.Telegram integracoesTelegram = new Integracoes.Telegram();

            string diretorioLogsErroReplicacaoDados = string.Empty;

            Root_Backup rootRotina_Backup = null;
            Root_ReplicacaoDeDados rootRotina_ReplicacaoDeDados = null;

            if (isRotinaBackup)
            {
                rootRotina_Backup = JsonConvert.DeserializeObject<Root_Backup>(rootRotina);
            }
            else
            {
                rootRotina_ReplicacaoDeDados = JsonConvert.DeserializeObject<Root_ReplicacaoDeDados>(rootRotina);

              
                diretorioLogsErroReplicacaoDados = rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.CriarDiretorioFilhoDataDia
                    ? System.IO.Path.Combine(rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro, DateTime.Now.ToShortDateString().Replace("/", string.Empty))
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro;
            }


            if (
                (isRotinaBackup ? rootRotina_Backup.Integracoes.Notificacoes.Telegram.Ativo : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Telegram.Ativo)
                && 
                (isRotinaBackup ? rootRotina_Backup.Integracoes.Notificacoes.Telegram.Envio.Opcoes.ReceberNotificacoesErros: rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Telegram.Envio.Opcoes.ReceberNotificacoesErros))
            {

                string accessTokenBot = integracoesTelegram.ObtemIntegracaoTelegram().Credenciais.AccessTokenBot;
                
                string chatIDDestino = isRotinaBackup 
                    ? rootRotina_Backup.Integracoes.Notificacoes.Telegram.Envio.ChatIDDestino
                    : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Telegram.Envio.ChatIDDestino;

                string identificadorRotina = isRotinaBackup
                   ? rootRotina_Backup.BancoDeDados.Identificador
                   : rootRotina_ReplicacaoDeDados.Principal.Identificador;


                string diretorioBackupOuReplicacaoDeDados = isRotinaBackup
                    ? rootRotina_Backup.CriacaoBackup.Diretorio_Backup
                    : diretorioLogsErroReplicacaoDados;

                Telegram.Notificacao telegramNotificacao = new Telegram.Notificacao(accessTokenBot, chatIDDestino,
                    identificadorRotina, uidRotina, string.Empty, isRotinaBackup, diretorioBackupOuReplicacaoDeDados,
                    isRotinaBackup ? string.Empty 
                    : diretorioLogsErroReplicacaoDados);

                await telegramNotificacao.EnviaMensagemErro(arquivosPendentesReplicacaoDeDados, arquivosEnviadosReplicacaoDeDados);

                await telegramNotificacao.EnviaLogTxtAsync(isRotinaBackup ? "LogErroBackup" : "LogErroReplicacaoDeDados");
            }
        }

        public static void EnviaNotificacaoErroEmail(dynamic rootRotina, string uidRotina, 
            int arquivosPendentesReplicacaoDeDados, int arquivosEnviadosReplicacaoDeDados, bool isRotinaBackup)
        {
            Integracoes.Email integracoesEmail = new Integracoes.Email();

            string diretorioLogsSucessoReplicacaoDados = string.Empty;
            string diretorioLogsErroReplicacaoDados = string.Empty;

            Root_Backup rootRotina_Backup = null;
            Root_ReplicacaoDeDados rootRotina_ReplicacaoDeDados = null;

            if (isRotinaBackup)
            {
                rootRotina_Backup = JsonConvert.DeserializeObject<Root_Backup>(rootRotina);
            }
            else
            {
                rootRotina_ReplicacaoDeDados = JsonConvert.DeserializeObject<Root_ReplicacaoDeDados>(rootRotina);

                diretorioLogsSucessoReplicacaoDados = rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.CriarDiretorioFilhoDataDia
                    ? System.IO.Path.Combine(rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsSucesso, DateTime.Now.ToShortDateString().Replace("/", string.Empty))
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsSucesso;

                diretorioLogsErroReplicacaoDados = rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.CriarDiretorioFilhoDataDia
                    ? System.IO.Path.Combine(rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro, DateTime.Now.ToShortDateString().Replace("/", string.Empty))
                    : rootRotina_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro;
            }



            if (
                 (isRotinaBackup ? rootRotina_Backup.Integracoes.Notificacoes.Email.Ativo : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Email.Ativo)
                 &&
                 (isRotinaBackup ? rootRotina_Backup.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberEmailErros: rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberNotificacoesErros))
            {
                string host = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Host;
                string porta = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Porta;
                string usuario = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Usuario;
                string senha = integracoesEmail.ObtemIntegracaoEmail().Credenciais.Senha;
                bool ssl = integracoesEmail.ObtemIntegracaoEmail().Credenciais.SSL;

                string destinatarios = isRotinaBackup
                    ? rootRotina_Backup.Integracoes.Notificacoes.Email.Envio.Destinatarios
                    : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Email.Envio.Destinatarios;
                
                
                string assunto = isRotinaBackup 
                    ? rootRotina_Backup.Integracoes.Notificacoes.Email.Envio.Assunto
                    : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Email.Envio.Assunto;

                string identificadorRotina = isRotinaBackup
                  ? rootRotina_Backup.BancoDeDados.Identificador
                  : rootRotina_ReplicacaoDeDados.Principal.Identificador;


                string diretorioBackup = isRotinaBackup
                    ? rootRotina_Backup.CriacaoBackup.Diretorio_Backup
                    : string.Empty;


                Email.Notificacao emailNotificacao = new Email.Notificacao(host, porta, usuario, senha, ssl,
                    destinatarios,
                     isRotinaBackup 
                     ? rootRotina_Backup.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberLogTxt
                     : rootRotina_ReplicacaoDeDados.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberNotificacoesErros,
                    assunto, identificadorRotina, diretorioBackup, uidRotina, string.Empty, false, isRotinaBackup,
                    isRotinaBackup ? string.Empty
                    : diretorioLogsErroReplicacaoDados, 
                    isRotinaBackup ? string.Empty
                    : diretorioLogsSucessoReplicacaoDados);

                emailNotificacao.EnviaNotificacaoErro(arquivosPendentesReplicacaoDeDados, arquivosEnviadosReplicacaoDeDados);
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

        public static Tuple<bool, int, int> EnviaArquivosReplicacaoDeDados(Root_ReplicacaoDeDados root_ReplicacaoDeDados, string uidRotina)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(root_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLocalOrigem);

            bool rotinaConcluidaSemErros = true;
            bool rotinaInterrompidaPorErro = false;
            int totalArquivosPendentes = directoryInfo.GetFiles().Count();
            int arquivosEnviados = 0;

            Integracoes.FTP integracoesFTP = new Integracoes.FTP();
            string diretorioUploadRemoto = root_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioRemotoDestino;

            string diretorioLogsSucesso = 
                root_ReplicacaoDeDados.DiretoriosEEnvio.CriarDiretorioFilhoDataDia 
                ? Path.Combine(root_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsSucesso, DateTime.Now.ToShortDateString().Replace("/", string.Empty))
                : root_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsSucesso;

            string diretorioLogsErro =
            root_ReplicacaoDeDados.DiretoriosEEnvio.CriarDiretorioFilhoDataDia
            ? Path.Combine(root_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro, DateTime.Now.ToShortDateString().Replace("/", string.Empty))
            : root_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioLogsErro;

            foreach (var arquivo in directoryInfo.GetFiles().OrderBy(file => file.CreationTime))
            {

                Thread.Sleep(2000);

                if (!rotinaInterrompidaPorErro)
                {
                    try
                    {
                        Helpers.CriaDiretorio(diretorioLogsSucesso);
                        Helpers.CriaDiretorio(diretorioLogsErro);

                        if (root_ReplicacaoDeDados.DiretoriosEEnvio.MetodoEnvioArquivosReplicacao.Equals("FTP"))
                        {

                            string host = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Host;
                            string porta = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Porta;
                            string usuario = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Usuario;
                            string senha = integracoesFTP.ObtemIntegracaoFTP().Credenciais.Senha;

                            FTP.Upload ftpUpload = new FTP.Upload(host, porta, usuario, senha, diretorioUploadRemoto, uidRotina, 
                                false, string.Empty, string.Empty, false, diretorioLogsErro, false, string.Empty);

                            ftpUpload.ExecutaUpload(arquivo.FullName);
                            
                        }

                        if (root_ReplicacaoDeDados.DiretoriosEEnvio.MetodoEnvioArquivosReplicacao.Equals("Pasta Compartilhada"))
                        {
                            File.Copy(arquivo.FullName, Path.Combine(root_ReplicacaoDeDados.DiretoriosEEnvio.DiretorioRemotoDestino, Path.GetFileName(arquivo.FullName)));
                        }
                        
                        Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LogReplicacaoDeDados-{1}.txt",
                            diretorioLogsSucesso, uidRotina),
                            string.Format("Arquivo: {0} transmitido com sucesso.", arquivo.FullName), tipoArquivo: "SUCESSO");

                        arquivosEnviados++;

                        File.Move(arquivo.FullName, Path.Combine(diretorioLogsSucesso, Path.GetFileName(arquivo.FullName)));
                    }
                    catch (Exception ex)
                    {
                        rotinaInterrompidaPorErro = true;
                        rotinaConcluidaSemErros = false;
                        Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LogErroReplicacaoDeDados-{1}.txt",
                               diretorioLogsErro, uidRotina),
                               string.Format("Erro ao Transmitir (com o método: {3}) o Arquivo: {0} (Exception: {1} | InnerException: {2}).\n\n" +
                               "A Rotina foi abortada. O AutoFBackup tentará realizar novamente a transmissão do(s) arquivo(s) pendente(s) restante(s) na próxima execução da Rotina.", arquivo.FullName, ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty, root_ReplicacaoDeDados.DiretoriosEEnvio.MetodoEnvioArquivosReplicacao));
                    }   
                }
            }

            return Tuple.Create(rotinaConcluidaSemErros, totalArquivosPendentes, arquivosEnviados);
        }

        public class ExecutaJobRotina : IJob
        {
            dynamic _rootRotina;
            Root_Backup _rootRotina_Backup = null;
            Root_ReplicacaoDeDados _rootRotina_ReplicacaoDeDados = null;
            bool _isRotinaBackup;
            public ExecutaJobRotina(dynamic rootRotina, bool isRotinaBackup)
            {
                 _rootRotina = rootRotina;
                _isRotinaBackup = isRotinaBackup;
            }
            public void Execute()
            {
                string conclusaoRotina = string.Empty;

                if (_isRotinaBackup)
                {
                    _rootRotina_Backup = JsonConvert.DeserializeObject<Root_Backup>(_rootRotina);

                    string identificadorBancoDeDados = _rootRotina_Backup.BancoDeDados.Identificador;
                    string uidRotinaBackup = Shared.Helpers.GeraUidRotinaBackup(identificadorBancoDeDados);

                    bool geraLogTxt = _rootRotina_Backup.Integracoes.Notificacoes.Telegram.Envio.Opcoes.ReceberLogTxt.Equals(true) ||
                        _rootRotina_Backup.Integracoes.Notificacoes.Email.Envio.Opcoes.ReceberLogTxt.Equals(true);

                    bool compactaBackupZip = _rootRotina_Backup.CriacaoBackup.Opcoes.FlagsBackup.Contains("Compactar");

                    ExecutaAplicativoPreBackup(_rootRotina_Backup, uidRotinaBackup);

                    ExecutaGfix(_rootRotina_Backup, uidRotinaBackup);

                    if (ExecutaBackup(_rootRotina_Backup, geraLogTxt, compactaBackupZip, uidRotinaBackup))
                    {
                        conclusaoRotina = string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

                        ExcluiBackupsAntigosLocal(_rootRotina_Backup, uidRotinaBackup);

                        EnviaNotificacaoSucessoTelegram(_rootRotina, uidRotinaBackup, conclusaoRotina, compactaBackupZip, 0, 0, true);
                        EnviaNotificacaoSucessoEmail(_rootRotina, uidRotinaBackup, conclusaoRotina, compactaBackupZip, 0, 0, true);

                        EnviaBackupParaMeganz(_rootRotina_Backup, uidRotinaBackup, compactaBackupZip);
                        EnviaArquivoParaFTP(_rootRotina, uidRotinaBackup, compactaBackupZip, _isRotinaBackup, string.Empty);
                        ExcluiBackupsAntigosFTP(_rootRotina_Backup, uidRotinaBackup);
                        ExecutaAplicativoPosBackup(_rootRotina_Backup, uidRotinaBackup);
                    }
                    else
                    {
                        EnviaNotificacaoErroTelegram(_rootRotina, uidRotinaBackup, 0, 0, true);
                        EnviaNotificacaoErroEmail(_rootRotina, uidRotinaBackup, 0, 0, true);
                    }
                }
                else
                {
                    _rootRotina_ReplicacaoDeDados = JsonConvert.DeserializeObject<Root_ReplicacaoDeDados>(_rootRotina);

                    string identificadorRotina = _rootRotina_ReplicacaoDeDados.Principal.Identificador;
                    string uidRotina = Shared.Helpers.GeraUidRotinaBackup(identificadorRotina);


                    Tuple<bool, int, int> tupleResultEnvioArqsReplicacaoDeDados;
                    tupleResultEnvioArqsReplicacaoDeDados = EnviaArquivosReplicacaoDeDados(_rootRotina_ReplicacaoDeDados, uidRotina);

                    if (tupleResultEnvioArqsReplicacaoDeDados.Item1 
                        && tupleResultEnvioArqsReplicacaoDeDados.Item2 > 0 
                        && tupleResultEnvioArqsReplicacaoDeDados.Item3 > 0)
                    {
                        conclusaoRotina = string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

                        EnviaNotificacaoSucessoTelegram(_rootRotina, uidRotina, conclusaoRotina, false, tupleResultEnvioArqsReplicacaoDeDados.Item2, tupleResultEnvioArqsReplicacaoDeDados.Item3, false);
                        Thread.Sleep(2000);
                        EnviaNotificacaoSucessoEmail(_rootRotina, uidRotina, conclusaoRotina, false, tupleResultEnvioArqsReplicacaoDeDados.Item2, tupleResultEnvioArqsReplicacaoDeDados.Item3, false);
                    }

                    if ((!tupleResultEnvioArqsReplicacaoDeDados.Item1) 
                        || (tupleResultEnvioArqsReplicacaoDeDados.Item2 != tupleResultEnvioArqsReplicacaoDeDados.Item3))
                    {
                        Thread.Sleep(2000);
                        EnviaNotificacaoErroTelegram(_rootRotina, uidRotina, tupleResultEnvioArqsReplicacaoDeDados.Item2, tupleResultEnvioArqsReplicacaoDeDados.Item3, false);
                        Thread.Sleep(2000);
                        EnviaNotificacaoErroEmail(_rootRotina, uidRotina, tupleResultEnvioArqsReplicacaoDeDados.Item2, tupleResultEnvioArqsReplicacaoDeDados.Item3, false);
                    }
                }
            }
        }
    }
}
