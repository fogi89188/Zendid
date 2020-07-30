using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.Models;
using Zendid.ViewModels;

namespace Zendid.Chat
{
    class ChatMessageListDesignModel : ChatMessageViewModel
    {
        #region Singleton

        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        #endregion

        #region Constructor

        public ChatMessageListDesignModel()
        {
            Item = SingletonModel.Messages;
        }

        #endregion
    }
}
