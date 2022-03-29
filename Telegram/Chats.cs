using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telegram
{
    public class From
    {
        public long id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string language_code { get; set; }
    }

    public class Chat
    {
        public string id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public bool all_members_are_administrators { get; set; }
    }

    public class Message
    {
        public int message_id { get; set; }
        public From from { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
    }

    public class Result
    {
        public int update_id { get; set; }
        public Message message { get; set; }
    }

    public class Root
    {
        public bool ok { get; set; }
        public List<Result> result { get; set; }
    }

    public class Chats
    {
        
        public Tuple<string, string> ObtemChatIDDestino(string accessTokenBot)
        {
            string chatId = string.Empty;
            string chatNome = string.Empty;

            var client = new RestClient(string.Format("{0}{1}/", BaseAPI.HostApi, accessTokenBot));
            var request = new RestRequest("getUpdates")
            .AddQueryParameter("offset", "-1");

            try
            {
                var response = client.GetAsync(request).Result;


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Root rootChats = JsonConvert.DeserializeObject<Root>(response.Content);

                    if (rootChats.result.Count == 1)
                    {
                        chatId = rootChats.result[0].message.chat.id.ToString();
                        chatNome = rootChats.result[0].message.chat.type.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Obter o ChatID de Destino: " + ex.Message, "Erro - ChatID Destino", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            return Tuple.Create(chatId, chatNome);
        }
    }
}
