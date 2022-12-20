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

                //context.Database.EnsureDeleted();
               // context.Database.EnsureCreated();

                if (!context.PartyConcerts.Any())
                {
                    context.PartyConcerts.AddRange(new List<PartyConcert>()
                    {
                        new PartyConcert()
                        {
                            GroupOrArtistName = "Баста",
                            TicketsCount = 10,
                            EventDate = new System.DateTime(2022,6,5),
                            EventPlace = "Minsk Arena",
                            AgeLimit = 18,
                            Price = 50,
                            Description = "1111111",
                            ImageURL = "https://www.kvitki.by/imageGenerator/eventDetails/932bf3232a3cc5e3e1fdb23d78259579"
                        },
                        new PartyConcert()
                        {
                            GroupOrArtistName = "Григорий Лепс",
                            TicketsCount = 0,
                            EventDate = new System.DateTime(2023,2,26),
                            EventPlace = "Minsk Arena",
                            AgeLimit = 18,
                            Price = 50,
                            Description = "2222222",
                            ImageURL = "https://www.kvitki.by/imageGenerator/eventDetails/4e2bd642b63bc9449a0c5c6e4857b252"
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
                            GroupOrArtistName = "Classic",
                            TicketsCount = 5,
                            EventDate = new System.DateTime(2023,1,10),
                            EventPlace = "Minsk",
                            VoiceType = VoiceType.Сопрано,
                            ConcertName = "Classic",
                            СomposerName = "Vasiliy",
                            Price = 30,
                            Description = "3333333",
                            ImageURL = "https://www.kvitki.by/imageGenerator/eventDetails/b3b9c7b672c006d88ed815c3ba5771da"
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.OpenAirConcerts.Any())
                {
                    context.OpenAirConcerts.AddRange(new List<OpenAirConcert>()
                    {
                        new OpenAirConcert()
                        {
                            GroupOrArtistName = "Minsk Sea beach 2",
                            TicketsCount = 11,
                            EventDate = new System.DateTime(2023,5,22),
                            EventPlace = "Minsk",
                            HeadLiner = "DJ Egor",
                            HowToGetTo = "village Braslau -> southern side of beach",
                            Price = 20,
                            Description = "44444444",
                            ImageURL = "http://sun9-85.userapi.com/s/v1/if2/h4GchSmMxoPkH-8ORiUEF1ColcedCEfDQPrzUWNeLR56LiAZYI4XifzIXhEh6rTYiPM8dpA47uqLwP7by2pXfsJC.jpg?size=200x294&quality=96&crop=0,0,696,1024&ava=1"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
