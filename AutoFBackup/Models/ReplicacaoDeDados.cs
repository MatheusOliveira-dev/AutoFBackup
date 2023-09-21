using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBackup.Models
{
    public class ReplicacaoDeDados
    {
        public class DiretoriosEEnvio_ReplicacaoDeDados
        {
            public string DiretorioLocalOrigem { get; set; }
            public string MetodoEnvioArquivosReplicacao { get; set; }
            public string DiretorioRemotoDestino { get; set; }
            public string DiretorioLogsSucesso { get; set; }
            public string DiretorioLogsErro { get; set; }
            public bool CriarDiretorioFilhoDataDia { get; set; }
        }

        public class Email_ReplicacaoDeDados
        {
            public bool Ativo { get; set; }
            public Envio_Email_ReplicacaoDeDados Envio { get; set; }
        }


        public class Envio_Email_ReplicacaoDeDados
        {
            public Opcoes_Email_ReplicacaoDeDados Opcoes { get; set; }
            public string Assunto { get; set; }
            public string Destinatarios { get; set; }
        }

        public class Envio_Telegram_ReplicacaoDeDados
        {
            public string ChatIDDestino { get; set; }
            public Opcoes_Telegram_ReplicacaoDeDados Opcoes { get; set; }
        }

        public class Frequencia_ReplicacaoDeDados
        {
            public string Tipo { get; set; }
            public string Hora { get; set; }
            public string Minuto { get; set; }
            public List<string> DiasSemana { get; set; }
        }

        public class Integracoes_ReplicacaoDeDados
        {
            public Notificacoes_ReplicacaoDeDados Notificacoes { get; set; }
        }

        public class Notificacoes_ReplicacaoDeDados
        {
            public Telegram_ReplicacaoDeDados Telegram { get; set; }
            public Email_ReplicacaoDeDados Email { get; set; }
        }

        public class Opcoes_Email_ReplicacaoDeDados
        {
            public bool ReceberNotificacoesSucesso { get; set; }
            public bool ReceberNotificacoesErros { get; set; }
        }
        public class Opcoes_Telegram_ReplicacaoDeDados
        {
            public bool ReceberNotificacoesSucesso { get; set; }
            public bool ReceberNotificacoesErros { get; set; }
        }

        public class Principal_ReplicacaoDeDados
        {
            public string Identificador { get; set; }
            public Frequencia_ReplicacaoDeDados Frequencia { get; set; }
        }

        public class Root_ReplicacaoDeDados
        {
            public string TipoRotina { get; set; }
            public Principal_ReplicacaoDeDados Principal { get; set; }
            public DiretoriosEEnvio_ReplicacaoDeDados DiretoriosEEnvio { get; set; }
            public Integracoes_ReplicacaoDeDados Integracoes { get; set; }
        }

        public class Telegram_ReplicacaoDeDados
        {
            public bool Ativo { get; set; }
            public Envio_Telegram_ReplicacaoDeDados Envio { get; set; }
        }
    }
}
