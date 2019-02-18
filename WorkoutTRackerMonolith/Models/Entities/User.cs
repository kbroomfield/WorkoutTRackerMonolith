using System.Collections.Generic;

namespace WorkoutTRackerMonolith.Models.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; } // A good company is all about transparency so we'll store this in plain text
        public IEnumerable<Workout> Workouts { get; set; }
    }
}