using Sybase.Data.AseClient;
using System.Data;
using SybaseManager.Core.Models;

namespace SybaseManager.Core.Factories
{
    public class SybaseConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create(ConnectionConfiguration configuration)
        {
            return new AseConnection($@"Data Source={configuration.HostName};
                                        Port=5000;
                                        Database={configuration.DatabaseName};
                                        Uid={configuration.UserName};
                                        Pwd={configuration.Password};");
        }
    }
}
