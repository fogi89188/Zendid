using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.Chat;
using Zendid.Models;
using Zendid.ViewModels.Base;
using ZendidCommons;

namespace Zendid.ViewModels
{
    /// <summary>
    /// a view model for the chat message thread
    /// </summary>
    class ChatMessageViewModel : BaseViewModel
    {
        public ICollection<Message> Item = SingletonModel.Messages;
    }
}
