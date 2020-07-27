using System;
using System.Collections.Generic;
using System.Text;

namespace ZendidServer.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Token> Tokens { get; set; }
    }
}
