using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.ViewModels;

namespace Zendid.Chat
{
    class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        #region Singleton

        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();

        #endregion

        #region Constructor

        public ChatMessageListItemDesignModel()
        {
            SenderName = "userName";
            Message = "message";
            MessageSentTime = DateTimeOffset.UtcNow;
        }

        #endregion
    }
}
