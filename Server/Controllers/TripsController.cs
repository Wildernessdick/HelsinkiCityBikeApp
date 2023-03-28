using HelsinkiCityBikeApp.Server.Data;
using HelsinkiCityBikeApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HelsinkiCityBikeApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly HelsinkiCityBikeContext _context;
        public TripsController(HelsinkiCityBikeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetTrips()
        {
            //because there is 3million trips in the database, we only want to return 100 :)
            var trips = await _context.Trips.Take(100).ToListAsync();
            return Ok(trips);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound();
            }

            return trip;
        }
        [HttpPost]
        public async Task<ActionResult<Trip>> PostTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTrip", new { id = trip.ID }, trip);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip(int id, Trip trip)
        {
            if (id != trip.ID)
            {
                return BadRequest();
            }
            _context.Entry(trip).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trip>> DeleteTrip(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return trip;
        }
        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.ID == id);
        }

    }
}
