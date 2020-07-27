using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zendid.Models
{
    /// <summary>
    /// a page of the application
    /// </summary>
    public enum ApplicationPageModel
    {
        /// <summary>
        /// the initial login page
        /// </summary>
        Login = 0,
        /// <summary>
        /// the registration page
        /// </summary>
        Registration = 1,

        /// <summary>
        /// the main chat page
        /// </summary>
        Chat = 2,
    }
}
