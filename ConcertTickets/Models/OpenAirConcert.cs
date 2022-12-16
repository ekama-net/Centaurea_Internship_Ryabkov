using System.ComponentModel.DataAnnotations;

namespace ConcertTickets
{
    public class OpenAirConcert : Concert
    {
        [Required(ErrorMessage = "HeadLiner is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "HeadLiner Name must be between 2 and 30 symbols")]
        public string HeadLiner { get; set; }

        [Required(ErrorMessage = "'How To Get To' is required")]
        public string HowToGetTo { get; set; }
    }
}
