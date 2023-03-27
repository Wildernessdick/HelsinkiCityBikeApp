using HelsinkiCityBikeApp.Shared;
using Microsoft.EntityFrameworkCore;
namespace HelsinkiCityBikeApp.Server.Data
{
    public class HelsinkiCityBikeContext : DbContext
    {
        public HelsinkiCityBikeContext(DbContextOptions<HelsinkiCityBikeContext> options)
            : base(options)
        {
        }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Trips> Trips { get; set; }
    }
}
