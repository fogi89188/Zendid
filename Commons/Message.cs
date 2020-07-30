using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZendidCommons
{
    public class Message
    {
        public string UserSender { get; set; }

        public string MessageStr { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}
