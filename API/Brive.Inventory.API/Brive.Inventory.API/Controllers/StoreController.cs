namespace Brive.Inventory.API.Controllers
{
    using System.Threading.Tasks;
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Product;
    using Microsoft.AspNetCore.Mvc;

    [Route("stores")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreBusinessLogic storeBusinessLogic = null;
        public StoreController(IStoreBusinessLogic storeBusinessLogic)
        {
            this.storeBusinessLogic = storeBusinessLogic;
        }

        [HttpGet]
        public async Task<object> GetAll()
        {
            return await storeBusinessLogic.GetAll(new StoreModel(), new PagerModel() { ReturnAll = true });
        }
    }
}
