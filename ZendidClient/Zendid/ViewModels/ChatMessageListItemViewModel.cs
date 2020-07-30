using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZendidCommons;
using Zendid.Models;

namespace Zendid.ViewModels
{
    class ChatMessageListItemViewModel
    {
        /// <summary>
        /// a view model for each chat message thread item in a chat thread
        /// </summary>

        public static Message serverMessage = new Message();

        public string SenderName { get { return serverMessage.UserSender; } set {serverMessage.UserSender = value; } }
        public DateTimeOffset MessageSentTime  { get { return serverMessage.Time; } set { serverMessage.Time = value; } }
        public string Message { get { return serverMessage.MessageStr; } set { serverMessage.MessageStr = value; } }
    }
}
