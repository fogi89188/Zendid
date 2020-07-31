using System;
using System.Collections.Generic;
using System.Text;

namespace ZendidServer.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string MessageStr { get; set; }
        public DateTime SendTime { get; set; }
    }
}
