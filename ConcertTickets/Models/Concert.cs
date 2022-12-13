using System;
using System.ComponentModel.DataAnnotations;

namespace ConcertTickets
{
    public class Concert //return abstract
    {
        [Key]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Group Or Artist Name is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 30")]
        public string GroupOrArtistName { get; set; }

        [Required(ErrorMessage = "Tickets Count is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number (more than 0)")]
        public int TicketsCount { get; set; }

        [Required(ErrorMessage = "Event Date is required")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Event Place is required")]
        public string EventPlace { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Number (more than 0)")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ImageURL is required")]
        public string ImageURL { get; set; }
    }
}
