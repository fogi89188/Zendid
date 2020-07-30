using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zendid.ViewModels
{
    /// <summary>
    /// a view model for the chat list
    /// </summary>
    class ChatListViewModel
    {
        /// <summary>
        /// the chat list items for the list
        /// </summary>
        public ObservableCollection<ChatListItemViewModel> Items { get; set; }
    }
}
