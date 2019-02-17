using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTRackerMonolith.Data;
using WorkoutTRackerMonolith.Models;

namespace WorkoutTRackerMonolith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusclesController: Controller
    {
        private readonly WorkoutDbContext _workoutDbContext;

        public MusclesController(WorkoutDbContext workoutDbContext)
        {
            _workoutDbContext = workoutDbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Muscle>>> GetMuscles()
        {
            var muscles = await _workoutDbContext.Muscles.ToListAsync();
            return muscles;
        }
    }
}