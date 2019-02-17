using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WorkoutTRackerMonolith.Models;

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
    }
}