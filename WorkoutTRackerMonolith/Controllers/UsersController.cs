using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using WorkoutTRackerMonolith.Models.ViewModels;
using WorkoutTRackerMonolith.Services;

namespace WorkoutTRackerMonolith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController: Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.Authenticate(model);

            return Ok(user);
        }

        // In the real world, we would want to use a GUID instead of a long
        [HttpPut("{userId:long}/workouts/{workoutId:long}")]
        public async Task<IActionResult> AddWorkoutToUser(long userId, long workoutId)
        {
            var actualUserId = long.Parse(HttpContext.User.Identity.Name);

            if (actualUserId != userId)
            {
                return Forbid();
            }
            
            return NoContent();
        }
    }
}