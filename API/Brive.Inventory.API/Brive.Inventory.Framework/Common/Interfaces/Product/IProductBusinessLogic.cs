namespace Brive.Inventory.Framework.Common.Interfaces.Product
{
    using Brive.Inventory.Entities;
    using Brive.Inventory.Framework.Common.Interfaces.Shared;
    /// <summary>
    /// Interface para capa de logica en modulo productos
    /// </summary>
    public interface IProductBusinessLogic : IAddAction<ProductModel, CommonResponseModel>, IGetAllAction<ProductModel, object> { }
}
