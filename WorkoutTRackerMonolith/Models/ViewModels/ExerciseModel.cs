using System.Collections.Generic;
using System.Linq;
using WorkoutTRackerMonolith.Models.Entities;

namespace WorkoutTRackerMonolith.Models.ViewModels
{
    public class ExerciseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MuscleModel> MusclesWorked { get; set; }

        public ExerciseModel(Exercise exercise)
        {
            Id = exercise.Id;
            Name = exercise.Name;
            MusclesWorked = exercise.MusclesWorked.Select(m => new MuscleModel(m));
        }
    }
}