using System;
using System.Collections.Generic;
using System.Text;

namespace ZendidServer.Data.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string TokenValue { get; set; }
        public DateTime ExpiresAt { get; set; }
        public User User { get; set; }
    }
}
