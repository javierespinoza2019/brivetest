namespace Brive.Inventory.Framework.Common.Interfaces.Shared
{
    using System.Threading.Tasks;

    public interface IAddAction<T,R>
    {
        Task<R> Add(T item);
    }
}
