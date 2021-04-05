namespace Brive.Inventory.Framework.Common.Interfaces.Shared
{
    using Brive.Inventory.Entities;
    using System.Threading.Tasks;

    public interface IGetAllAction<T,R>
    {        
        Task<R> GetAll(T item, PagerModel pager);
    }
}
