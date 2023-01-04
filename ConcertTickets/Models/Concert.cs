using System;
using System.ComponentModel.DataAnnotations;

namespace ConcertTickets
{
    public abstract class Concert
    {
        private string imageURL;

        [Key]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Group Or Artist Name is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 30 symbols")]
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
        public string ImageURL
        {
            get 
            {
                if (imageURL != null) return imageURL;
                else return "https://banffventureforum.com/wp-content/uploads/2019/08/No-Image.png";
            }
            set {imageURL = value;}
        }

        public string Discriminator { get; set; }
    }
}
