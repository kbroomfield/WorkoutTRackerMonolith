using WorkoutTRackerMonolith.Models.Entities;

namespace WorkoutTRackerMonolith.Models.ViewModels
{
    public class WorkoutModel
    {
        public string Name { get; set; }
        
        public WorkoutModel(Workout workout)
        {
            Name = workout.Name;
        }
    }
}