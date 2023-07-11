using ASP_NET_REACT_CRUD_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_REACT_CRUD_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly DriverDbContext _context;


        public DriverController(DriverDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetDriver")]
        public async Task<IEnumerable<Driver>> GetDrivers()
        {
            return await _context.Driver.ToListAsync();
        }

        [HttpPost]
        [Route("AddDriver")]
        public async Task<Driver> AddDriver(Driver driver)
        {
            _context.Driver.Add(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        [HttpPatch]
        [Route("UpdateDriver/{id}")]
        public async Task<Driver> UpdateDriver(Driver driver)
        {
            _context.Entry(driver).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return driver;
        }

        [HttpDelete]
        [Route("DeleteDriver/{id}")]
        public bool DeleteDriver(int id) 
        { 
            bool a =false;
            var driver = _context.Driver.Find(id);
            if (driver != null)
            {
                a = true;
                _context.Entry(driver).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            else { 
                a = false;
            }

            return a;  
        }
        [HttpGet]
        [Route("GetAllDrivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _context.Driver.ToListAsync();
            return Ok(drivers);
        }


    }
}
