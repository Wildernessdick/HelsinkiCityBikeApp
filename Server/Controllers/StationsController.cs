using HelsinkiCityBikeApp.Server.Data;
using HelsinkiCityBikeApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelsinkiCityBikeApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly HelsinkiCityBikeContext _context;
        public StationsController(HelsinkiCityBikeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetStations()
        {
            var stations = await _context.Stations.OrderBy(s => s.Nimi).ToListAsync();

            return Ok(stations);
        }
        [HttpGet("{id}")]
        public IActionResult GetStation(int id)
        {
            var station = _context.Stations.FirstOrDefault(s => s.ID == id);
            if (station == null)
            {
                return NotFound();
            }
            return Ok(station);
        }

        [HttpPost]
        public IActionResult PostStation(Station station)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public IActionResult PutStation(int id, Station station)
        {
            if (id != station.ID)
            {
                return BadRequest();
            }
            _context.Entry(station).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStation(int id)
        {
            var station = _context.Stations.Find(id);
            if (station == null)
            {
                return NotFound();
            }
            _context.Stations.Remove(station);
            _context.SaveChanges();
            return NoContent();
        }
        private bool StationExists(int id)
        {
            return _context.Stations.Any(e => e.ID == id);
        }

    }
}
