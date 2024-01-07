using Domain.Models.Cars;
using Domain.Models.Spareparts;
using Infrastructure.Database.SqlDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.SparepartsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SparepartsController : ControllerBase
    {

        private readonly SqlServer _sqlServer;
        public SparepartsController(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }
        // GET: api/<SparepartsController>
        [HttpPost]
        public async Task<IActionResult> AddSteeringWheel([FromBody] SteeringWheel steeringWheel)
        {
            var brand = await _sqlServer.Brands.Where(b => b.BrandName == steeringWheel.BrandName).FirstOrDefaultAsync();

            //var steeringWheelToCreate = new SteeringWheel { SteeringWheelId = Guid.NewGuid(), BrandId = brand.BrandId, BrandName = brand.BrandName, SteeringWheelHeater = steeringWheel.SteeringWheelHeater, SteeringWheelSize = steeringWheel.SteeringWheelSize };

            var spareparts = new Sparepart { SteeringWheel = new SteeringWheel { SteeringWheelId = Guid.NewGuid(), BrandId = brand.BrandId, BrandName = brand.BrandName, SteeringWheelHeater = steeringWheel.SteeringWheelHeater, SteeringWheelSize = steeringWheel.SteeringWheelSize } };


            var car = new Car { BrandName = brand.BrandName, BrandId = brand.BrandId, Sparepart = spareparts };

            return Ok(car);
        }

    }
}
