namespace Brive.Inventory.Framework.Common.Interfaces.Shared
{
    using System.Threading.Tasks;

    public interface IUpdateAction<T,R>
    {
        Task<R> Update(T item);
    }
}
