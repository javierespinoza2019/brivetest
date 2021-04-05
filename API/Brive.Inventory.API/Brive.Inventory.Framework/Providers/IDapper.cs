namespace Brive.Inventory.Framework.Providers
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Threading.Tasks;

    public interface IDapper : IDisposable
    {
        Task<object> Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<object> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<R> Insert<T, R>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<R> Delete<T, R>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<R> Update<T, R>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        DbConnection GetDbconnection();
    }
}
