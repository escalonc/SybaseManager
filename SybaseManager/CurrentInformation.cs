using SybaseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SybaseManager
{
    public static class CurrentInformation
    {
        public static ConnectionInformation ConnectionProperties { get; set; }
        public static string ObjectType { get; set; }
        public static string ObjectName { get; set; }

        public static string sqlGenObject()
        {
            return $@"SELECT c.text
            FROM sysusers u, syscomments c, sysobjects o
            WHERE o.type = '{ObjectTypes[ObjectType]}' AND o.id = c.id AND o.uid = u.uid and o.name = '{ObjectName}'";
        }

        private static readonly Dictionary<string, string> ObjectTypes = new Dictionary<string, string>
        {
            {"StoredProcedure", "P"},
            {"Function", "SF"},
            {"View", "V"},
            {"Trigger", "TR"},
            {"Constraint", "R"}
        };
    }
}
