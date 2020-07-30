using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zendid.ViewModels
{
    class ChatMessageListItemViewModel
    {
        /// <summary>
        /// a view model for each chat message thread item in a chat thread
        /// </summary>
        public string SenderName { get; set; }
        public DateTimeOffset MessageSentTime  { get; set; }
        public string Message { get; set; }
    }
}
