using Domain.Models.Brands;
using Infrastructure.Database.SqlDatabase;
using Infrastructure.EmailService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.BrandsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly SqlServer _sqlServer;
        private readonly SendEmailService _sendEmailService;

        public BrandsController(SqlServer sqlServer, SendEmailService sendEmailService)
        {
            _sqlServer = sqlServer;
            _sendEmailService = sendEmailService;
        }
        // GET: api/<BrandsController>
        [HttpPost]
        public async Task<IActionResult> AddBrands(string brand)
        {
            var brandToCreate = new Brand { BrandName = brand, BrandId = Guid.NewGuid() };

            _sqlServer.Brands.Add(brandToCreate);

            _sqlServer.SaveChanges();

            await _sendEmailService.SendEmail();

            return Ok(brandToCreate);
        }

    }
}
