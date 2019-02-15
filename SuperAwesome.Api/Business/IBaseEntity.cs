using System.Collections.Generic;
using System.Threading.Tasks;
using SuperAwesome.Api.Domain;

namespace SuperAwesome.Api.Business
{
    public interface IBaseEntity<T, TId>
        where T : BaseDomain<TId>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(int id, T project);
        Task Add(T project);
        Task<T> Delete(int id);
    }
}