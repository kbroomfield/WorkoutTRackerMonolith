using WorkoutTRackerMonolith.Models.Entities;

namespace WorkoutTRackerMonolith.Models.ViewModels
{
    public class MuscleModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public MuscleModel(Muscle muscle)
        {
            Id = muscle.Id;
            Name = muscle.Name;
        }
    }
}