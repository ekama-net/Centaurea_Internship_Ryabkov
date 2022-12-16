using System.ComponentModel.DataAnnotations;

namespace ConcertTickets
{
    public class PartyConcert : Concert
    {
        [Required(ErrorMessage = "Age Limit is required")]
        [Range(0, 100, ErrorMessage = "Please enter valid Number (between 0 and 100)")]
        public int AgeLimit { get; set; }
    }
}
