namespace Brive.Inventory.API.Controllers
{
    using System.Threading.Tasks;
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Product;
    using Microsoft.AspNetCore.Mvc;

    [Route("inventories")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryBusinessLogic inventoryBusinessLogic = null;
        public InventoryController(IInventoryBusinessLogic inventoryBusinessLogic)
        {
            this.inventoryBusinessLogic = inventoryBusinessLogic;
        }
        [Route("GetAll")]
        [HttpPost]
        public async Task<object> GetAll(InventoryModel item)
        {
            return await inventoryBusinessLogic.GetAll(item, new PagerModel() { ReturnAll = true });
        }

        [Route("Add")]
        [HttpPost]
        public async Task<object> Add(InventoryModel item)
        {
            return await inventoryBusinessLogic.Add(item);
        }
    }
}
