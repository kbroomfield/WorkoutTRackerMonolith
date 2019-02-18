using WorkoutTRackerMonolith.Models.Entities;

namespace WorkoutTRackerMonolith.Models.ViewModels
{
    public class WorkoutExerciseModel
    {
        public long Id { get; set; }
        public ExerciseModel Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public bool Optional { get; set; }
        public int Order { get; set; }

        public WorkoutExerciseModel(WorkoutExercise workoutExercise)
        {
            Id = workoutExercise.Id;
            Exercise = new ExerciseModel(workoutExercise.Exercise);
            Sets = workoutExercise.Sets;
            Reps = workoutExercise.Reps;
            Optional = workoutExercise.Optional;
            Order = workoutExercise.Order;
        }
    }
}