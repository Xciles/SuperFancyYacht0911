using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAwesome.Api.Business;

namespace SuperAwesome.Api.Controllers
{
    public class CarsController : GenericBaseController<Domain.Car, int>
    {
        public new ICar Entity => ((ICar) base.Entity);

        public CarsController(ICar car) : base(car)
        {
        }

        [HttpGet("page/{start}/{take=20}")]
        public async Task<IActionResult> GetAllByRange(int start, int take = 20)
        {
            return Ok(await Entity.GetAllByRange(start, take));
        }
    }
}