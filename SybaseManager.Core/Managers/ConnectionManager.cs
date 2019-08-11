using SybaseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SybaseManager.Core.Managers
{
    public class ConnectionManager
    {
        private readonly List<ConnectionInformation> connections;

        public void AddConnection(ConnectionInformation connectionInformation)
        {
            connections.Add(connectionInformation);
        }
    }
}
