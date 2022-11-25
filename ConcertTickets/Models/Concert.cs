using System;
using System.ComponentModel.DataAnnotations;

namespace ConcertTickets
{
    public abstract class Concert 
    {
        [Key]
        public int ConcertId { get; set; }
        public string GroupOrArtistName { get; set; }
        public int TicketsCount { get; set; }
        public DateTime EventDate { get; set; }
        public string EventPlace { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }


    }
}
