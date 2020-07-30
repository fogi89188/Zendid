using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZendidCommons;
using Zendid.Models;
using System.Collections;

namespace Zendid.ViewModels
{
    class ChatMessageListItemViewModel
    {
        /// <summary>
        /// a view model for each chat message thread item in a chat thread
        /// </summary>

        public static Message message = new Message();

        public string SenderName { get { return message.UserSender; } set {message.UserSender = value; } }
        public DateTimeOffset MessageSentTime  { get { return message.Time; } set { message.Time = value; } }
        public string Message { get { return message.MessageStr; } set { message.MessageStr = value; } }
    }
}
