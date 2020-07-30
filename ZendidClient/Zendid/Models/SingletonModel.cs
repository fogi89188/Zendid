using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ZendidCommons;

namespace Zendid.Models
{
    class SingletonModel
    {
        private static SingletonModel instance = new SingletonModel();

        public static string token = "";
        public static DateTime timeOfLastUpdate = DateTime.Now;
        public static ICollection<ZendidCommons.Message> Messages;
        static SingletonModel()
        {

        }

        private SingletonModel()
        {

        }

        public static SingletonModel Instance { get { return instance; } set { instance = value; } }

        public async void UpdateRequest()
        {
            // request a chat update
            ChatUpdateRequest chatUpdateRequest = new ChatUpdateRequest
            {
                Token = SingletonModel.token,
                TimeOfLastUpdate = DateTime.Now
            };
            var res = await ApiClient.RequestServerPost<ChatUpdateRequest, ChatUpdateResponse>
                ("https://zendid.in.kutiika.net/chat/update", chatUpdateRequest);
            if (res.Status == "success")
            {
                SingletonModel.Messages = res.Messages;
            }
        }
    }
}