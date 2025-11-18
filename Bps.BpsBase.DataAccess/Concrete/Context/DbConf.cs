using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.DataAccess.Concrete.Context
{
    public class DbConf : DbConfiguration
    {
        public DbConf()
        {
            //SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            //SetDefaultConnectionFactory(new SqlConnectionFactory("Data Source=IGMS\\MSSQL19;Initial Catalog=EFIARC; User Id=sa; Password=8051f122ibg;"));
            //SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}
