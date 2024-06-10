using KacperKolos2.Context;
using Microsoft.EntityFrameworkCore;
using KacperKolos2.Models;

namespace KacperKolos2.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApbdContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApbdContext>>()))
            {
                // Check if any data exists and skip seeding if data exists
                if (context.Events.Any() || context.Organisers.Any())
                {
                    return;   // DB has been seeded
                }

                // Seed Organisers
                var organisers = new Organiser[]
                {
                    new Organiser {Name = "Organiser A" },
                    new Organiser {Name = "Organiser B" },
                    new Organiser {Name = "Organiser C" }
                };

                context.Organisers.AddRange(organisers);
                context.SaveChanges();

                // Seed Events
                var events = new Event[]
                {
                    new Event {Name = "Event 1", DateFro = DateTime.Now.AddMonths(-1), DateTo = DateTime.Now.AddMonths(1) },
                    new Event {Name = "Event 2", DateFro = DateTime.Now.AddMonths(-2), DateTo = DateTime.Now.AddMonths(2) },
                    new Event {Name = "Event 3", DateFro = DateTime.Now.AddMonths(-3), DateTo = DateTime.Now.AddMonths(3) }
                };

                context.Events.AddRange(events);
                context.SaveChanges();

                // Seed Event_Organisers
                var eventOrganisers = new Event_Organiser[]
                {
                    new Event_Organiser { IdEvent = 1, IdOrganiser = 1, MainOrganiser = true },
                    new Event_Organiser { IdEvent = 1, IdOrganiser = 2, MainOrganiser = false },
                    new Event_Organiser { IdEvent = 2, IdOrganiser = 2, MainOrganiser = true },
                    new Event_Organiser { IdEvent = 3, IdOrganiser = 3, MainOrganiser = true }
                };

                context.EventOrganisers.AddRange(eventOrganisers);
                context.SaveChanges();
            }
        }
    }
}
