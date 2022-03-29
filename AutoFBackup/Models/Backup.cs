using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Backup
    {
        public class BancoDeDados_Backup
        {
            public string Identificador { get; set; }
            public string Servidor { get; set; }
            public string Porta { get; set; }
            public string Usuario { get; set; }
            public string Senha { get; set; }
            public string Caminho { get; set; }
        }

        public class Frequencia_Backup
        {
            public string Tipo { get; set; }
            public string Hora { get; set; }
            public string Minuto { get; set; }
            public List<string> DiasSemana { get; set; }
        }

        public class AplicativoPreBackup_Backup
        {
            public string Aplicativo { get; set; }
            public string Argumentos { get; set; }
        }

        public class AplicativoPosBackup_Backup
        {
            public string Aplicativo { get; set; }
            public string Argumentos { get; set; }
        }

        public class ExcluirBackupsAntigosLocal_Backup
        {
            public bool Ativo { get; set; }
            public string Dias { get; set; }
        }

        public class Opcoes_CriacaoBackup_Backup
        {
            public List<string> FlagsBackup { get; set; }
            public AplicativoPreBackup_Backup AplicativoPreBackup { get; set; }
            public AplicativoPosBackup_Backup AplicativoPosBackup { get; set; }
            public ExcluirBackupsAntigosLocal_Backup ExcluirBackupsAntigosLocal { get; set; }
        }

        public class CriacaoBackup_Backup
        {
            public string Diretorio_Backup { get; set; }
            public Frequencia_Backup Frequencia { get; set; }
            public Opcoes_CriacaoBackup_Backup Opcoes { get; set; }
        }

        public class Opcoes_Telegram_Backup
        {
            public bool ReceberLogTxt { get; set; }
            public bool ReceberNotificacoesErros { get; set; }
        }
        public class Envio_Telegram_Backup
        {
            public string ChatIDDestino { get; set; }
            public Opcoes_Telegram_Backup Opcoes { get; set; }
        }

        public class Envio_Email_Backup
        {
            public string Assunto { get; set; }
            public string Destinatarios { get; set; }
            public Opcoes_Email_Backup Opcoes { get; set; }
        }

        public class Telegram_Backup
        {
            public bool Ativo { get; set; }
            public Envio_Telegram_Backup Envio { get; set; }
        }

        public class Email_Backup
        {
            public bool Ativo { get; set; }
            public Envio_Email_Backup Envio { get; set; }
           
        }

        public class Opcoes_Email_Backup
        {
            public bool ReceberLogTxt { get; set; }
            public bool ReceberEmailErros { get; set; }
        }


        public class Notificacoes_Backup
        {
            public Telegram_Backup Telegram { get; set; }
            public Email_Backup Email { get; set; }
        }


        public class Envio_MegaNZ_Backup
        {
            public string Pasta { get; set; }
        }

        public class MegaNZ_Backup
        {
            public bool Ativo { get; set; }
            public Envio_MegaNZ_Backup Envio { get; set; }
        }

        public class ExcluirBackupsAntigos_FTP_Backup
        {
            public bool Ativo { get; set; }
            public string Dias { get; set; }
        }

        public class Envio_FTP_Backup
        {
            public string Diretorio { get; set; }
            public Opcoes_FTP_Backup Opcoes { get; set; }
        }

        public class Opcoes_FTP_Backup
        {
            public ExcluirBackupsAntigos_FTP_Backup ExcluirBackupsAntigos { get; set; }
        }

        public class FTP_Backup
        {
            public bool Ativo { get; set; }
            public Envio_FTP_Backup Envio { get; set; }

        }

        public class Uploads_Backup
        {
            public MegaNZ_Backup MegaNZ { get; set; }
            public FTP_Backup FTP { get; set; }
        }

        public class Integracoes_Backup
        {
            public Notificacoes_Backup Notificacoes { get; set; }
            public Uploads_Backup Uploads { get; set; }
        }

        public class Root_Backup
        {
            public BancoDeDados_Backup BancoDeDados { get; set; }
            public CriacaoBackup_Backup CriacaoBackup { get; set; }
            public Integracoes_Backup Integracoes { get; set; }
        }
    }
}
