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
        //counts how many trips starts from the station
        [HttpGet("startStation/{stationId}")]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTripsStartingFromStation(int stationId)
        {
            return await _context.Trips.Where(t => t.DepartureStationId == stationId).ToListAsync();
        }
        //count how many trips ends at the station
        [HttpGet("endStation/{stationId}")]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTripsEndingAtStation(int stationId)
        {
            return await _context.Trips.Where(t => t.ReturnStationId == stationId).ToListAsync();
        }
        //counts avarage distance of trips starting from the station
        [HttpGet("startStation/{stationId}/averageDistance")]
        public ActionResult<double> GetAverageDistanceFromStartStation(int stationId)
        {
            var tripsStartingFromStation = _context.Trips.Where(t => t.DepartureStationId == stationId);
            if (!tripsStartingFromStation.Any())
            {
                return NotFound();
            }
            return tripsStartingFromStation.Average(t => t.CoveredDistance);
        }
        //counts avarage distance of trips ending at the station
        [HttpGet("endStation/{stationId}/averageDistance")]
        public ActionResult<double> GetAverageDistanceToEndStation(int stationId)
        {
            var tripsEndingAtStation = _context.Trips.Where(t => t.ReturnStationId == stationId);
            if (!tripsEndingAtStation.Any())
            {
                return NotFound();
            }
            return tripsEndingAtStation.Average(t => t.CoveredDistance);
        }

        //Top stations for end the trip

        [HttpGet("returnStations/{id}")]
        public async Task<ActionResult<List<Station>>> GetTopReturnStationsStartingFromStation(int id)
        {
            var tripsStartingFromStation = await _context.Trips.Where(t => t.DepartureStationId == id).ToListAsync();
            var returnStationsStartingFromStation = tripsStartingFromStation
                .GroupBy(t => t.ReturnStationId)
                .Select(g => new { StationId = g.Key, Count = g.Count() })
                .OrderByDescending(r => r.Count)
                .Take(5)
                .ToList();


            var topStations = await _context.Stations
                .Where(s => returnStationsStartingFromStation.Any(r => r.StationId == s.ID))
                .ToListAsync();

            return topStations;
        }
        //top stations to start the trip
        [HttpGet("departureStations/{id}")]
        public async Task<ActionResult<List<Station>>> GetTopDepartureStationsEndingAtStation(int id)
        {
            var tripsEndingAtStation = await _context.Trips.Where(t => t.ReturnStationId == id).ToListAsync();
            var departureStationsEndingAtStation = tripsEndingAtStation
            .GroupBy(t => t.DepartureStationId)
            .Select(g => new { StationId = g.Key, Count = g.Count() })
            .OrderByDescending(r => r.Count)
            .Take(5)
            .ToList();

            var stationIds = departureStationsEndingAtStation.Select(r => r.StationId).ToList();
            var stations = await _context.Stations.Where(s => stationIds.Contains(s.ID)).ToListAsync();

            return stations;
        }









        //For now, we are not adding, deleting or updating trips. But if we would, we would use these methods:
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
