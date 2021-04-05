namespace Brive.Inventory.API.Controllers
{
    using System.Threading.Tasks;
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Product;
    using Microsoft.AspNetCore.Mvc;

    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusinessLogic productBusinessLogic = null;
        public ProductController(IProductBusinessLogic productBusinessLogic)
        {
            this.productBusinessLogic = productBusinessLogic;
        }

        [HttpGet]
        public async Task<object> GetAll()
        {
            return await productBusinessLogic.GetAll(new ProductModel(), new PagerModel() { ReturnAll = true });
        }

        [Route("Add")]
        [HttpPost]
        public async Task<object> Add(ProductModel item)
        {
            return await productBusinessLogic.Add(item);
        }
    }
}
