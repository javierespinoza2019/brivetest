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
    public class ProductDataAccess : IProductDataAccess
    {
        private const string SP_NAME = "USP_CRUDProduct";
        private readonly IDapper dapper = null;
        public ProductDataAccess(IDapper dapper)
        {
            this.dapper = dapper;
        }
        public async Task<CommonResponseModel> Add(ProductModel item)
        {
            return await dapper.Insert<ProductModel, CommonResponseModel>(SP_NAME, BuildParams(item, ActionTypeEnum.Add), commandType: CommandType.StoredProcedure);
        }
        
        public async Task<object> GetAll(ProductModel item, PagerModel pager)
        {
            return await dapper.GetAll<object>(SP_NAME, BuildParams(item, ActionTypeEnum.Get), commandType: CommandType.StoredProcedure);
        }

        private DynamicParameters BuildParams(ProductModel item, ActionTypeEnum option, PagerModel page = null)
        {
            if (page == null) page = new PagerModel();

            var parameters = new DynamicParameters();
            parameters.Add("Id", item.Id);
            parameters.Add("Name", item.Name);
            parameters.Add("UnitPrice", item.UnitPrice);
            parameters.Add("Barcode", item.Barcode);
            parameters.Add("Option", (int)option);
            parameters.Add("PageNumber", page.PageNumber);
            parameters.Add("RecordsPerPage", page.RecordsPerPage);
            parameters.Add("ReturnAll", page.ReturnAll);
            return parameters;
        }
    }
}