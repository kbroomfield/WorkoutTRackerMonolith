using System.ComponentModel.DataAnnotations;

namespace WorkoutTRackerMonolith.Models.ViewModels
{
    public class LoginModel
    {
        [EmailAddress] [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}