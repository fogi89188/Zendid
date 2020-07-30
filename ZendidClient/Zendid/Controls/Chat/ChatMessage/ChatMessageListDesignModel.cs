using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Item = new List<ChatMessageListItemViewModel>
            {
                // chat list item list add
                new ChatMessageListItemViewModel
                {
                    SenderName = "Viktor",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    Message = "This is now the new message!"

                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Viktor",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    Message = "This is now the new message!"

                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Viktor",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    Message = "This is now the new message!"

                },
            };
        }

        #endregion
    }
}
