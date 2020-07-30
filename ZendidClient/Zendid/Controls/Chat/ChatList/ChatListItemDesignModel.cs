using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.ViewModels;

namespace Zendid.Chat
{
    class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton

        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion

        #region Constructor

        public ChatListItemDesignModel()
        {
            Name = "userName";
        }

        #endregion
    }
}
