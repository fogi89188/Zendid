using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Interop;
using System.Windows.Media.Media3D;
using Zendid.Chat;
using Zendid.ViewModels;
using Zendid.ViewModels.Base;
using ZendidCommons;

namespace Zendid.Models
{
    class SingletonModel : ChatMessageViewModel
    {
        private static SingletonModel instance = new SingletonModel();

        public static string token = "";
        public static DateTime timeOfLastUpdate = DateTime.Now;
        private static ObservableCollection<ZendidCommons.Message> messages = new ObservableCollection<ZendidCommons.Message>();
        public static ObservableCollection<string> Users = new ObservableCollection<string>();

        static SingletonModel()
        {

        }

        private SingletonModel()
        {
        }

        public static SingletonModel Instance { get { return instance; } set { instance = value; } }

        public static ObservableCollection<ZendidCommons.Message> Messages { get => messages; set { messages = value; } }

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
                foreach (ZendidCommons.Message message in res.Messages)
                {
                    SingletonModel.Messages.Add(message);
                }
                SingletonModel.timeOfLastUpdate = res.TimeOfLastUpdate;
                ObservableCollection<string> myCollection = new ObservableCollection<string>(res.Users);
                SingletonModel.Users = myCollection;
                Items = SingletonModel.Users;
                Item = SingletonModel.Messages;
            }
        }


        public async void SendRequest(string message)
        {
            // request a chat update
            MessageSendRequest messageRequest = new MessageSendRequest
            {
                Token = SingletonModel.token,
                MessageStr = message,
                TimeOfLastUpdate = SingletonModel.timeOfLastUpdate
            };
            var res = await ApiClient.RequestServerPost<MessageSendRequest, MessageSendResponse>
                ("https://zendid.in.kutiika.net/chat/sendmessage", messageRequest);
            if (res.Status == "success")
            {
                foreach (ZendidCommons.Message item in res.Messages)
                {
                    SingletonModel.Messages.Add(item);
                }
                SingletonModel.timeOfLastUpdate = res.TimeOfLastUpdate;
                ObservableCollection<string> myCollection = new ObservableCollection<string>(res.Users);
                SingletonModel.Users = myCollection;
                Items = SingletonModel.Users;
                Item = SingletonModel.Messages;
            }
        }
    }
}