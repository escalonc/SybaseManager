using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SybaseManager.Core.Models
{
    public class ConnectionConfiguration
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string HostName { get; set; }

        public string DatabaseName { get; set; }
    }
}
