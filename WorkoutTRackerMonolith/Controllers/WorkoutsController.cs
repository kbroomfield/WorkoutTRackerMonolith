using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkoutTRackerMonolith.Models.ViewModels;
using WorkoutTRackerMonolith.Services;

namespace WorkoutTRackerMonolith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController: Controller
    {
        private readonly WorkoutService _workoutService;

        public WorkoutsController(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkoutModel>> GetWorkouts([FromQuery] string searchBy)
        {
            if (string.IsNullOrWhiteSpace(searchBy))
            {
                return await _workoutService.GetAll();
            }

            return await _workoutService.SearchWorkouts(searchBy);
        }

        [HttpGet("{workoutId:long}")]
        public async Task<IActionResult> GetWorkoutById(long workoutId)
        {
            var result = await _workoutService.GetById(workoutId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<WorkoutModel> CreateWorkout([FromBody] WorkoutModel workout)
        {
            return null;
        }
    }
}