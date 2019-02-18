using System.Collections.Generic;

namespace WorkoutTRackerMonolith.Models.Entities
{
    public class Workout
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }
    }
}