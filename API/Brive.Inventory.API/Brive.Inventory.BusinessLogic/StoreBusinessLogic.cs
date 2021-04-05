namespace Brive.Inventory.BusinessLogic
{
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Product;
    using System.Threading.Tasks;

    /// <summary>
    /// Capa de logica para modulo sucursales
    /// </summary>
    public class StoreBusinessLogic : IStoreBusinessLogic
    {
        private readonly IStoreDataAccess storeDataAccess = null;
        public StoreBusinessLogic(IStoreDataAccess storeDataAccess)
        {
            this.storeDataAccess = storeDataAccess;
        }      
        public async Task<object> GetAll(StoreModel item, PagerModel pager)
        {
            return await storeDataAccess.GetAll(item, pager);
        }
    }
}
