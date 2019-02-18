using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WorkoutTRackerMonolith.Data;
using WorkoutTRackerMonolith.Models.Entities;
using WorkoutTRackerMonolith.Models.ViewModels;

namespace WorkoutTRackerMonolith.Services
{
    public class UserService
    {
        private readonly WorkoutDbContext _workoutDbContext; // Ideally, this would be a repository.
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(WorkoutDbContext workoutDbContext)
        {
            _workoutDbContext = workoutDbContext;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<UserModel> Authenticate(LoginModel login)
        {
            var user = await _workoutDbContext.Users
                .Include(u => u.Workouts)
                    .ThenInclude(w => w.WorkoutExercises)
                        .ThenInclude(e => e.Exercise)
                .SingleOrDefaultAsync(u =>
                u.Email.Equals(login.Email, StringComparison.CurrentCultureIgnoreCase) && HasGoodPassword(u, login.Password));
            
            if (user == null)
            {
                return null;
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ThisSecretShouldBeStoredInSecretsAndChanged");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return new UserModel(user)
            {
                Token = tokenHandler.WriteToken(token)
            };
        }

        public async Task<UserModel> AddWorkoutToUser(long userId, long workoutId)
        {
            return null;
        }

        private bool HasGoodPassword(User user, string password)
        {
            return _passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success;
        }
    }
}