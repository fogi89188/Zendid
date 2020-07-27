using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZendidServer.Models
{
    public class LoginResponse
    {
        public string Status { get; set; }
        public string Token { get; set; }
    }
}
