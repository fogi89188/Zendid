using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
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
        public ObservableCollection<Message> Item { get; set; }

    }
}
