using Microsoft.EntityFrameworkCore;
using WorkoutTRackerMonolith.Models;

namespace WorkoutTRackerMonolith.Data
{
    public class WorkoutDbContext: DbContext
    {
        public WorkoutDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
    }
}