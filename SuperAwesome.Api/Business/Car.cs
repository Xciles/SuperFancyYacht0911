using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAwesome.Api.Data;

namespace SuperAwesome.Api.Business
{
    public class Car : BaseEntity<Domain.Car, int>, ICar
    {
        public Car(ApiDbContext context) : base(context)
        {
        }

        public Task<List<Domain.Car>> GetAllByRange(int start, int take = 20)
        {
            return Context.Set<Domain.Car>().Skip(start).Take(take).ToListAsync();
        }
    }
}