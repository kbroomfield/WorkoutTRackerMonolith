using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutTRackerMonolith.Data;
using WorkoutTRackerMonolith.Models.ViewModels;

namespace WorkoutTRackerMonolith.Services
{
    public class WorkoutService: IAsyncService<WorkoutModel>
    {
        private readonly WorkoutDbContext _workoutDbContext;

        public WorkoutService(WorkoutDbContext workoutDbContext)
        {
            _workoutDbContext = workoutDbContext;
        }

        public async Task<WorkoutModel> GetById(long id)
        {
            var workout = await _workoutDbContext.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(e => e.Exercise)
                        .ThenInclude(ex => ex.MusclesWorked)
                .FirstOrDefaultAsync(w => w.Id == id);

            return workout != null ? new WorkoutModel(workout) : null;
        }

        public async Task<IEnumerable<WorkoutModel>> GetAll()
        {
            var workouts = await _workoutDbContext.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(e => e.Exercise)
                        .ThenInclude(ex => ex.MusclesWorked)
                .ToListAsync();

            return workouts.Select(w => new WorkoutModel(w));
        }

        public async Task<IEnumerable<WorkoutModel>> SearchWorkouts(string searchString)
        {
            var workouts = await _workoutDbContext.Workouts
                .Where(w => w.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase))
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(e => e.Exercise)
                        .ThenInclude(ex => ex.MusclesWorked)
                .ToListAsync();

            return workouts.Select(w => new WorkoutModel(w));
        }

        public Task<WorkoutModel> Create(WorkoutModel entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<WorkoutModel> Delete(WorkoutModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}