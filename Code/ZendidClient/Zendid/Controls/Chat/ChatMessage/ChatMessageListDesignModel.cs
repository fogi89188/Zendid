using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.Models;
using Zendid.ViewModels;
using ZendidCommons;

namespace Zendid.Chat
{
    class ChatMessageListDesignModel : ChatMessageViewModel, INotifyPropertyChanged
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
