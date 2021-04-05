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
    public class InventoryDataAccess : IInventoryDataAccess
    {
        private const string SP_NAME = "USP_CRUDInventory";
        private readonly IDapper dapper = null;
        public InventoryDataAccess(IDapper dapper)
        {
            this.dapper = dapper;
        }
        public async Task<CommonResponseModel> Add(InventoryModel item)
        {
            return await dapper.Insert<InventoryModel, CommonResponseModel>(SP_NAME, BuildParams(item, ActionTypeEnum.Add), commandType: CommandType.StoredProcedure);
        }
        
        public async Task<object> GetAll(InventoryModel item, PagerModel pager)
        {
            return await dapper.GetAll<object>(SP_NAME, BuildParams(item, ActionTypeEnum.Get), commandType: CommandType.StoredProcedure);
        }

        private DynamicParameters BuildParams(InventoryModel item, ActionTypeEnum option, PagerModel page = null)
        {
            if (page == null) page = new PagerModel();

            var parameters = new DynamicParameters();
            parameters.Add("Id", item.Id);
            parameters.Add("StoreId", item.StoreId);
            parameters.Add("TransactionDate", item.TransactionDate);
            parameters.Add("Barcode", item.Barcode);
            parameters.Add("Quantity", item.Quantity);
            parameters.Add("ProductName", item.ProductName);
            parameters.Add("Option", (int)option);
            parameters.Add("PageNumber", page.PageNumber);
            parameters.Add("RecordsPerPage", page.RecordsPerPage);
            parameters.Add("ReturnAll", page.ReturnAll);
            return parameters;
        }
    }
}