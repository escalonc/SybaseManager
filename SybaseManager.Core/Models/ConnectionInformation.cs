using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SybaseManager.Core.Models
{
    public class ConnectionInformation
    {
        public string Name { get; set; }

        public IDbConnection Connection { get; set; }

        public ConnectionConfiguration Configuration { get; set; }

    }
}