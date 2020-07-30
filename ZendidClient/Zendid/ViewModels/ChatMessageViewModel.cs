using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.Chat;
using Zendid.ViewModels.Base;

namespace Zendid.ViewModels
{
    /// <summary>
    /// a view model for the chat message thread
    /// </summary>
    class ChatMessageViewModel : BaseViewModel
    {
        public List<ChatMessageListItemViewModel> Item { get; set; }
    }
}
