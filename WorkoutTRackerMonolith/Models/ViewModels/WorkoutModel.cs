using System.Collections.Generic;
using System.Linq;
using WorkoutTRackerMonolith.Models.Entities;

namespace WorkoutTRackerMonolith.Models.ViewModels
{
    public class WorkoutModel
    {
        public string Name { get; set; }
        public IEnumerable<WorkoutExerciseModel> WorkoutExercises { get; set; }
        
        public WorkoutModel(Workout workout)
        {
            Name = workout.Name;
            WorkoutExercises = workout.WorkoutExercises?.Select(e => new WorkoutExerciseModel(e)) ??
                               Enumerable.Empty<WorkoutExerciseModel>();
        }
    }
}