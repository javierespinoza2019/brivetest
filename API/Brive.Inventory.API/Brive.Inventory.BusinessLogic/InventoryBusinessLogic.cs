namespace Brive.Inventory.BusinessLogic
{
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Product;
    using System.Threading.Tasks;

    /// <summary>
    /// Capa de logica para modulo inventarios
    /// </summary>
    public class InventoryBusinessLogic : IInventoryBusinessLogic
    {
        private readonly IInventoryDataAccess inventoryDataAccess = null;
        public InventoryBusinessLogic(IInventoryDataAccess inventoryDataAccess)
        {
            this.inventoryDataAccess = inventoryDataAccess;
        }
        public async Task<CommonResponseModel> Add(InventoryModel item)
        {
            return await inventoryDataAccess.Add(item);
        }
        public async Task<object> GetAll(InventoryModel item, PagerModel pager)
        {
            return await inventoryDataAccess.GetAll(item, pager);
        }
    }
}
