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