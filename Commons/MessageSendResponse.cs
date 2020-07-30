using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZendidCommons
{
    public class MessageSendResponse
    {
        public string Status { get; set; }

        public ZendidErrorCodes ErrorCode { get; set; }

        public List<Message> Messages { get; set; }
        public List<string> Users { get; set; }

        public DateTime TimeOfLastUpdate { get; set; }
    }
}
