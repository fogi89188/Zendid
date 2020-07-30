using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.ViewModels.Base;

namespace Zendid.ViewModels
{
    /// <summary>
    /// a view model for the chat list
    /// </summary>
    class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// the chat list items for the list
        /// </summary>
        public ObservableCollection<string> Items { get; set; }
    }
}
