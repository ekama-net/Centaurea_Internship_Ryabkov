using System;
using System.ComponentModel.DataAnnotations;

namespace ConcertTickets
{
    public abstract class Concert 
    {
        [Key]
        public int ConcertId { get; set; }
        [Display (Name ="Name")]
        public string GroupOrArtistName { get; set; }
        public int TicketsCount { get; set; }
        [Display(Name = "When")]
        public DateTime EventDate { get; set; }
        [Display(Name = "Where")]
        public string EventPlace { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [Display(Name = "Banner")]
        public string ImageURL { get; set; }


    }
}
