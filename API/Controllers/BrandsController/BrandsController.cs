using Domain.Models.Brands;
using Infrastructure.Database.SqlDatabase;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.BrandsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly SqlServer _sqlServer;

        public BrandsController(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }
        // GET: api/<BrandsController>
        [HttpPost]
        public async Task<IActionResult> AddBrands(string brand)
        {
            var brandToCreate = new Brand { BrandName = brand, BrandId = Guid.NewGuid() };

            _sqlServer.Brands.Add(brandToCreate);

            _sqlServer.SaveChanges();


            return Ok(brandToCreate);
        }

    }
}
