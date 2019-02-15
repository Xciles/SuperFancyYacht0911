using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperAwesome.Api.Business
{
    public interface ICar : IBaseEntity<Domain.Car, int>
    {
        Task<List<Domain.Car>> GetAllByRange(int start, int take = 20);
    }
}