namespace Brive.Inventory.Framework.Common.Interfaces.Product
{
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Shared;
    /// <summary>
    /// Interface para capa de logica en modulo inventarios
    /// </summary>
    public interface IInventoryBusinessLogic : IAddAction<InventoryModel, CommonResponseModel>, IGetAllAction<InventoryModel, object> { }
}
