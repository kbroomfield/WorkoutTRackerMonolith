using System.Collections.Generic;

namespace WorkoutTRackerMonolith.Models.Entities
{
    public class Exercise
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Muscle> MusclesWorked { get; set; }
    }
}