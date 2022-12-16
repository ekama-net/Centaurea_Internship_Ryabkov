using System.ComponentModel.DataAnnotations;

namespace ConcertTickets
{
    public class ClassicalConcert : Concert
    {
        [Required(ErrorMessage = "Voice Type is required")]
        public VoiceType VoiceType { get; set; }

        [Required(ErrorMessage = "Concert Name is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Concert Name must be between 2 and 30 symbols")]
        public string ConcertName { get; set; }

        [Required(ErrorMessage = "Сomposer Name is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Сomposer Name must be between 2 and 30 symbols")]
        public string СomposerName { get; set; }
    }
}
