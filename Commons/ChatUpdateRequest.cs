using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZendidCommons
{
    public class ChatUpdateRequest
    {
        public DateTime TimeOfLastUpdate { get; set; }
        public string Token { get; set; }
    }
}
