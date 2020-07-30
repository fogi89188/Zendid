using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media.Media3D;
using Zendid.Chat;
using ZendidCommons;

namespace Zendid.Models
{
    class SingletonModel
    {
        private static SingletonModel instance = new SingletonModel();

        public static string token = "";
        public static DateTime timeOfLastUpdate = DateTime.Now;
        private static List<ZendidCommons.Message> messages;

        static SingletonModel()
        {

        }

        private SingletonModel()
        {
        }

        public static SingletonModel Instance { get { return instance; } set { instance = value; } }
        public static List<ZendidCommons.Message> Messages { get => messages; set => messages = value; }

        public async void UpdateRequest()
        {
            // request a chat update
            ChatUpdateRequest chatUpdateRequest = new ChatUpdateRequest
            {
                Token = SingletonModel.token,
                TimeOfLastUpdate = SingletonModel.timeOfLastUpdate
            };
            var res = await ApiClient.RequestServerPost<ChatUpdateRequest, ChatUpdateResponse>
                ("https://zendid.in.kutiika.net/chat/update", chatUpdateRequest);
            if (res.Status == "success")
            {
                SingletonModel.Messages = res.Messages;
                SingletonModel.timeOfLastUpdate = res.TimeOfLastUpdate;
            }
        }
    }
}