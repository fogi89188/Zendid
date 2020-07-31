using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.ViewModels;
using ZendidCommons;

namespace Zendid.Chat
{
    class ChatMessageListItemDesignModel : ZendidCommons.Message
    {
        #region Singleton

        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();

        #endregion

        #region Constructor

        public ChatMessageListItemDesignModel()
        {
            UserSender = "userName";
            MessageStr = "message";
            Time = DateTimeOffset.UtcNow;
        }

        #endregion
    }
}
