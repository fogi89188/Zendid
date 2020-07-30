using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Zendid.Models
{
    public sealed class SingletonModel
    {
        private static SingletonModel instance = new SingletonModel();

        public string token = "";
        public DateTime lastmodified;


        private DateTime timeOfLastUpdate = DateTime.Now;
        static SingletonModel()
        {

        }

        private SingletonModel()
        {

        }

        public static SingletonModel Instance { get; set; }
    }
}
