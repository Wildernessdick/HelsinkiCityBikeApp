using Microsoft.EntityFrameworkCore;

namespace HelsinkiCityBikeApp.Server.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HelsinkiCityBikeContext(
            serviceProvider.GetRequiredService<
                    DbContextOptions<HelsinkiCityBikeContext>>()))
            {
                if (context == null)
                {
                    throw new ArgumentNullException("Null QuotesContext");
                }

                context.Database.EnsureCreated();





            }
        }
    }
}
