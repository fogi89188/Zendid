using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.Models;
using Zendid.ViewModels;
using ZendidCommons;

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
            ZendidCommons.Message meseg = new ZendidCommons.Message();
            meseg.MessageStr = "lets test this thing";
            meseg.Time = DateTime.Now;
            meseg.UserSender = "test";
            SingletonModel.Messages.Add(meseg);
            Item = SingletonModel.Messages;
        }

        #endregion
    }
}
