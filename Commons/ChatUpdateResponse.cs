﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZendidCommons
{
    public class ChatUpdateResponse
    {
        public string Status { get; set; }
        public ZendidErrorCodes ErrorCode { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}