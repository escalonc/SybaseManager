using Dapper;
using SybaseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SybaseManager
{
    public class TreeViewConnectionBootstrapper
    {
        public static void Init(ConnectionInformation connectionInformation, TreeView treeView)
        {
            var connectionNode = new TreeNode("Local connection");

            var tablesNode = new TreeNode("Tables");
            var triggersNode = new TreeNode("Triggers");
            var storedProceduresNode = new TreeNode("Stored procedures");
            var viewsNode = new TreeNode("Views");
            var functionsNode = new TreeNode("Functions");
            var usersNode = new TreeNode("Users");

            var tables = connectionInformation.Connection.Query<TableModel>(@"select convert(varchar(30),o.name) AS Name, id as Id
                                                                from sysobjects o
                                                                where type = 'U'
                                                                order by Name");
            var triggerNames = connectionInformation.Connection.Query<string>(@"select name from sysobjects where type = 'TR'");
            var storedProcedureNames = connectionInformation.Connection.Query<string>(@"select name from sysobjects where type = 'P'");
            var viewNames = connectionInformation.Connection.Query<string>(@"select name from sysobjects where type = 'V'");
            var functionNames = connectionInformation.Connection.Query<string>(@"select name from sysobjects where type = 'SF'");
            var userNames = connectionInformation.Connection.Query<string>(@"select name as user_name from sysusers");

            foreach (var table in tables)
            {
                var node = new TreeNode
                {
                    Tag = "Table",
                    Text = table.Name
                };

                var constraints = connectionInformation.Connection.Query<ConstraintModel>($@"
                    select object_name(constrid) as Name,
                    col_name(tableid,sysconstraints.colid) as ColumnName,
                    text as Source
                    from sysconstraints,syscomments
                    where sysconstraints.status=128 and sysconstraints.constrid=syscomments.id and object_name(tableid) = '{table.Name}'
                ").ToList();

                if (constraints.Count != 0)
                {
                    var constraintsNode = new TreeNode("Constraints");
                    
                    foreach (var constraint in constraints)
                    {
                        constraintsNode.Nodes.Add(new TreeNode
                        {
                            Name = constraint.Name,
                            Tag = "Constraint"
                        });
                    }
                
                    node.Nodes.Add(constraintsNode);
                }
                
                
                tablesNode.Nodes.Add(node);
                
            }

            foreach (var triggerName in triggerNames)
            {
                var node = new TreeNode
                {
                    Tag = "Trigger",
                    Text = triggerName
                };
                triggersNode.Nodes.Add(node);
            }

            foreach (var storedProcedureName in storedProcedureNames)
            {
                var node = new TreeNode
                {
                    Tag = "StoredProcedure",
                    Text = storedProcedureName
                };
                storedProceduresNode.Nodes.Add(node);
            }

            foreach (var viewName in viewNames)
            {
                var node = new TreeNode
                {
                    Tag = "View",
                    Text = viewName
                };
                viewsNode.Nodes.Add(node);
            }

            foreach (var functionName in functionNames)
            {
                var node = new TreeNode
                {
                    Tag = "Function",
                    Text = functionName
                };
                functionsNode.Nodes.Add(node);
            }

            foreach (var userName in userNames)
            {
                var node = new TreeNode
                {
                    Tag = "View",
                    Text = userName
                };
                usersNode.Nodes.Add(node);
            }

            connectionNode.Nodes.Add(tablesNode);
            connectionNode.Nodes.Add(triggersNode);
            connectionNode.Nodes.Add(storedProceduresNode);
            connectionNode.Nodes.Add(viewsNode);
            connectionNode.Nodes.Add(functionsNode);
            connectionNode.Nodes.Add(usersNode);

            treeView.Nodes[0].Nodes.Add(connectionNode);
        }
    }
}
