using SybaseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SybaseManager
{
    public static class CurrentInformation
    {
        public static List<ConnectionInformation> Connections { get; } = new List<ConnectionInformation>();
        
        public static ConnectionInformation ConnectionProperties { get; set; }
        public static string ObjectType { get; set; }
        public static string ObjectName { get; set; }

        public static string SqlGenObject()
        {
            return $@"SELECT c.text
            FROM sysusers u, syscomments c, sysobjects o
            WHERE o.type = '{ObjectTypes[ObjectType]}' AND o.id = c.id AND o.uid = u.uid and o.name = '{ObjectName}'";
        }
        
        public static void AddConnection(ConnectionInformation connectionInformation)
        {
            if (Connections.Any(connection => connection.Name.Equals(connectionInformation.Name)))
            {
                throw new SybaseManagerException("Connection name already exists");
            }

            Connections.Add(connectionInformation);
        }

        private static readonly Dictionary<string, string> ObjectTypes = new Dictionary<string, string>
        {
            {"StoredProcedure", "P"},
            {"Function", "SF"},
            {"View", "V"},
            {"Trigger", "TR"},
            {"Constraint", "R"},
            {"Connection", "C"}
        };
    }
}
