using System.Collections.Generic;
using WorkoutTRackerMonolith.Models.Entities;

namespace WorkoutTRackerMonolith.Models.ViewModels
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public IEnumerable<WorkoutModel> Workouts { get; set; }
    }
}