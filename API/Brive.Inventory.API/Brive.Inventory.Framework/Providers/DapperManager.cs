namespace Brive.Inventory.Framework.Providers.Sql
{
    using Brive.Inventory.Framework.Common.Utilities;
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;


    public class DapperManager : IDapper
    {
        private readonly IConfiguration _config;
        private readonly string CONNECTION_STRING = "";
        private const string CONNECTION_PATH = "ConnectionStrings:BriveDBConnection";
        public DapperManager(IConfiguration config)
        {
            _config = config;
            CONNECTION_STRING = _config[CONNECTION_PATH];
        }
        public Task<R> Delete<T, R>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {           
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        public async Task<object> Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = GetDbconnection();
            return (await db.ExecuteReaderAsync(sp, parms, commandType: commandType)).ToJSON().ToCamelCase(isRootArray: false);
        }

        public async Task<object> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = GetDbconnection();
            return (await db.ExecuteReaderAsync(sp, parms, commandType: commandType)).ToJSON().ToCamelCase(isRootArray: true);
        }

        public async Task<R> Insert<T, R>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = GetDbconnection();
            return (await db.QueryAsync<R>(sp, parms, commandType: commandType)).FirstOrDefault();
        }

        public Task<R> Update<T, R>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new System.NotImplementedException();
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(CONNECTION_STRING);
        }
    }
}
