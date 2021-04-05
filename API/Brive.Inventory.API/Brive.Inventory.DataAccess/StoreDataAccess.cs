namespace Brive.Inventory.DataAccess
{
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Product;
    using Brive.Inventory.Framework.Providers;
    using Dapper;
    using System.Data;
    using System.Threading.Tasks;

    /// <summary>
    /// Capa de acceso a datos para modulo productos
    /// </summary>
    public class StoreDataAccess : IStoreDataAccess
    {
        private const string SP_NAME = "USP_CRUDStore";
        private readonly IDapper dapper = null;
        public StoreDataAccess(IDapper dapper)
        {
            this.dapper = dapper;
        }      
        public async Task<object> GetAll(StoreModel item, PagerModel pager)
        {
            return await dapper.GetAll<object>(SP_NAME, BuildParams(item, ActionTypeEnum.Get, pager), commandType: CommandType.StoredProcedure);
        }

        private DynamicParameters BuildParams(StoreModel item, ActionTypeEnum option, PagerModel page = null)
        {
            if (page == null) page = new PagerModel();

            var parameters = new DynamicParameters();
            parameters.Add("Id", item.Id);
            parameters.Add("Name", item.Name);
            parameters.Add("Option", (int)option);
            parameters.Add("PageNumber", page.PageNumber);
            parameters.Add("RecordsPerPage", page.RecordsPerPage);
            parameters.Add("ReturnAll", page.ReturnAll);
            return parameters;
        }
    }
}