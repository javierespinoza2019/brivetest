namespace Brive.Inventory.Framework.Common.Interfaces.Product
{
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Shared;
    /// <summary>
    /// Interface para capa de acceso a datos en modulo productos
    /// </summary>
    public interface IStoreDataAccess : IGetAllAction<StoreModel, object> { }
}
