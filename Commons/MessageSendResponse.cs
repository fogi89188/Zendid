﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZendidCommons
{
    public class MessageSendResponse
    {
        public string Status { get; set; }
        public ZendidErrorCodes ErrorCode { get; set; }
    }
}
