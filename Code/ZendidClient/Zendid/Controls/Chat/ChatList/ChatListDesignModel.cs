using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.Models;
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
            Items = SingletonModel.Users;
        }

        #endregion
    }
}
