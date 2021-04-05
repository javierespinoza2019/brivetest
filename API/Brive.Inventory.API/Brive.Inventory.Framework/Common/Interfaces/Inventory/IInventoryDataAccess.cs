namespace Brive.Inventory.Framework.Common.Interfaces.Product
{
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Shared;
    /// <summary>
    /// Interface para capa de acceso a datos en modulo inventarios
    /// </summary>
    public interface IInventoryDataAccess : IAddAction<InventoryModel, CommonResponseModel>, IGetAllAction<InventoryModel, object> { }
}
