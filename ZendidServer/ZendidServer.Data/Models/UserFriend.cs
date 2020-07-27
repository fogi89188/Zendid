using System;
using System.Collections.Generic;
using System.Text;

namespace ZendidServer.Data.Models
{
    public class UserFriend
    {
        public int Id { get; set; }
        public User User { get; set; }
        public User Friend { get; set; }
    }
}
