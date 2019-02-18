using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkoutTRackerMonolith.Models.ViewModels;
using WorkoutTRackerMonolith.Services;

namespace WorkoutTRackerMonolith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.Authenticate(model);

            return Ok(user);
        }
    }
}