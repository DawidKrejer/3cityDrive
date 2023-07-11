using System.Collections.Generic;
using System.Linq;
using ASP_NET_REACT_CRUD_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASP_NET_REACT_CRUD_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaceController : ControllerBase
    {
        private readonly DriverDbContext _context;

        public RaceController(DriverDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("AddRace")]
        public async Task<ActionResult<Race>> AddRace(Race race)
        {
            _context.Race.Add(race);
            await _context.SaveChangesAsync();
            return race;
        }

        [HttpGet]
        [Route("GetRace")]
        public async Task<IEnumerable<Race>> GetRace()
        {
            return await _context.Race.ToListAsync();
        }

        [HttpPatch]
        [Route("UpdateRace/{id}")]
        public async Task<Race> UpdateRace(Race race)
        {
            _context.Entry(race).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return race;
        }

        [HttpDelete]
        [Route("DeleteRace/{id}")]
        public bool DeleteRace(int id)
        {
            bool a = false;
            var race = _context.Race.Find(id);
            if (race != null)
            {
                a = true;
                _context.Entry(race).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            else
            {
                a = false;
            }

            return a;
        }
    }
}
