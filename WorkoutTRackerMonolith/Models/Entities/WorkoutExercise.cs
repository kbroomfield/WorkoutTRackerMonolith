namespace WorkoutTRackerMonolith.Models.Entities
{
    public class WorkoutExercise
    {
        public long Id { get; set; }
        public long ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public bool Optional { get; set; }
        public int Order { get; set; }
    }
}