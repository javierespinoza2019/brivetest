namespace Brive.Inventory.BusinessLogic
{
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Product;
    using System.Threading.Tasks;

    /// <summary>
    /// Capa de logica para modulo productos
    /// </summary>
    public class ProductBusinessLogic : IProductBusinessLogic
    {
        private readonly IProductDataAccess productDataAccess = null;
        public ProductBusinessLogic(IProductDataAccess productDataAccess)
        {
            this.productDataAccess = productDataAccess;
        }
        public async Task<CommonResponseModel> Add(ProductModel item)
        {
            return await productDataAccess.Add(item);
        }
        public async Task<object> GetAll(ProductModel item, PagerModel pager)
        {
            return await productDataAccess.GetAll(item, pager);
        }
    }
}
