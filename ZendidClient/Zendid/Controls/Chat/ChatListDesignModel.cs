using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.ViewModels;

namespace Zendid.Chat
{
    class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton

        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Constructor

        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                // chat list item list add
                new ChatListItemViewModel
                {
                    Name = "Viktor"
                },
                new ChatListItemViewModel
                {
                    Name = "Niki"
                },
                new ChatListItemViewModel
                {
                    Name = "Max"
                },
            };
        }

        #endregion
    }
}
