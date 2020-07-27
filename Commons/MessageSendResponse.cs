using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZendidCommons
{
    public class RegisterResponse
    {
        public string Status { get; set; }
        public ZendidErrorCodes ErrorCode { get; set; }
        public string Token { get; set; }
    }
}
