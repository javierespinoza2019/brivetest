namespace Brive.Inventory.Framework.Common.Interfaces.Shared
{
    using System.Threading.Tasks;

    public interface IGetAction<T,R>
    {
        Task<R> Get(T item);
    }
}
