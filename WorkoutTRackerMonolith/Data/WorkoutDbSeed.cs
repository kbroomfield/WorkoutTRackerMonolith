using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WorkoutTRackerMonolith.Models.Entities;
using Enumerable = System.Linq.Enumerable;

namespace WorkoutTRackerMonolith.Data
{
    public class WorkoutDbSeed
    {
        public static async Task SeedWorkoutDatabase(WorkoutDbContext context)
        {
            try
            {
                context.Database.Migrate();
                
                if (!context.Muscles.Any())
                {
                    context.Muscles.AddRange(GetSeedMuscles());
                    await context.SaveChangesAsync();
                }

                if (!context.Workouts.Any())
                {
                    context.Workouts.AddRange(GetSeedWorkouts());
                    await context.SaveChangesAsync();
                }

                if (!context.Users.Any())
                {
                    context.Users.Add(GetSeedUser());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static IEnumerable<Workout> GetSeedWorkouts()
        {
            return new List<Workout>
            {
                new Workout
                {
                    Name = "Candito Linear",
                    WorkoutExercises = GetSeedWorkoutExercises()
                }
            };
        }

        static IEnumerable<WorkoutExercise> GetSeedWorkoutExercises()
        {
            return new List<WorkoutExercise>
            {
                new WorkoutExercise
                {
                    Exercise = new Exercise { Name= "Squat" },
                    Order = 1,
                    Optional = false,
                    Sets = 3,
                    Reps = 6
                },
                new WorkoutExercise
                {
                    Exercise = new Exercise { Name = "Deadlift" },
                    Order = 2,
                    Optional = false,
                    Sets = 2,
                    Reps = 6
                }
            };
        }

        static IEnumerable<Muscle> GetSeedMuscles()
        {
            return new List<Muscle>
            {
                new Muscle { Name = "Quads" },
                new Muscle { Name = "Hamstrings" }
            };
        }

        static User GetSeedUser()
        {
            var passwordHasher = new PasswordHasher<User>();
            
            var user =  new User
            {
                Name = "kyle",
                Email = "my@email.com",
                Workouts = Enumerable.Empty<Workout>()
            };

            user.Password = passwordHasher.HashPassword(user, "MyPassword123!");

            return user;
        }
    }
}