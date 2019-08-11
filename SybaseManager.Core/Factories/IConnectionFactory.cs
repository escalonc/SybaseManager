using SybaseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SybaseManager.Core.Factories
{
    public interface IConnectionFactory
    {
        IDbConnection Create(ConnectionConfiguration configuration);
    }
}
