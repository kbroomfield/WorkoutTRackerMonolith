using System.Collections.Generic;
using System.Linq;
using WorkoutTRackerMonolith.Models.Entities;

namespace WorkoutTRackerMonolith.Models.ViewModels
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public IEnumerable<WorkoutModel> Workouts { get; set; }

        public UserModel()
        {
        }

        public UserModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Workouts = user.Workouts?.Select(w => new WorkoutModel(w)) ?? Enumerable.Empty<WorkoutModel>();
        }
    }
}