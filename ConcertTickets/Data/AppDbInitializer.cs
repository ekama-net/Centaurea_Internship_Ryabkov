using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace ConcertTickets
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.PartyConcerts.Any())
                {
                    context.PartyConcerts.AddRange(new List<PartyConcert>()
                    {
                        new PartyConcert()
                        {
                            GroupOrArtistName = "QQQ",
                            TicketsCount = 10,
                            EventDate = new System.DateTime(2022,1,7),
                            EventPlace = "Minsk",
                            AgeLimit = 18,
                            Price = 10,
                            Description = "1111111",
                            ImageURL = "Later feature"
                        },
                        new PartyConcert()
                        {
                            GroupOrArtistName = "WWW",
                            TicketsCount = 10,
                            EventDate = new System.DateTime(2022,1,8),
                            EventPlace = "Minsk1",
                            AgeLimit = 20,
                            Price = 15,
                            Description = "2222222",
                            ImageURL = "Later feature"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.ClassicalConcerts.Any())
                {
                    context.ClassicalConcerts.AddRange(new List<ClassicalConcert>()
                    {
                        new ClassicalConcert()
                        {
                            GroupOrArtistName = "ClassicQ",
                            TicketsCount = 10,
                            EventDate = new System.DateTime(2022,1,10),
                            EventPlace = "MinskClassicQ",
                            VoiceType = VoiceType.Бас,
                            ConcertName = "ClassicQConcert",
                            СomposerName = "Vasya",
                            Price = 5,
                            Description = "1111111",
                            ImageURL = "Later feature"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
