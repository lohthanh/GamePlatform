using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GamePlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.AspNetCore.Authorization;

using GamePlatform.Models;

namespace GamePlatform.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DBContext db;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, DBContext context)
        {
            _logger = logger;
            db = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser userSubmission)
        {
            _logger.LogInformation("Login Attempted");
            if (ModelState.IsValid)
            {
                User? userInDb = db.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
                if (userInDb == null)
                {
                    return Unauthorized("Invalid Email/Password");
                }
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                // Verify provided password against hash stored in db        
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);                                    // Result can be compared to 0 for failure        
                if (result == 0)
                {
                    return Unauthorized("Invalid Email/Password");
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", userInDb.Id.ToString()),
                        new Claim("FirstName", userInDb.FirstName),
                        new Claim("LastName", userInDb.LastName),
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere way too many secrets")), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest("Invalid Email/Password");
            }
        }

        // create function for new user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userSubmission)
        {
            _logger.LogInformation("Register Attempted");
            if (ModelState.IsValid)
            {
                User? userInDb = db.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if (userInDb != null)
                {
                    return BadRequest("Email already in use!");
                }
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                userSubmission.Password = hasher.HashPassword(userSubmission, userSubmission.Password);
                User newUser = new User
                {
                    FirstName = userSubmission.FirstName,
                    LastName = userSubmission.LastName,
                    Email = userSubmission.Email,
                    Password = userSubmission.Password
                };
                db.Add(newUser);
                db.SaveChanges();
                return Created("User", newUser);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpPost("games")]
        public async Task<IActionResult> AddUserGame([FromBody] int gameId)
        {
            _logger.LogInformation("Add User Game Attempted");
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            int userId = int.Parse(userIdClaim.Value);

            User? userInDb = db.Users.FirstOrDefault(u => u.Id == userId);
            if (userInDb == null)
            {
                return NotFound("User not found");
            }

            UserGames newUserGame = new UserGames
            {
                UserId = userId,
                GameId = gameId
            };
            db.Add(newUserGame);
            db.SaveChanges();
            return Created("UserGame", newUserGame);
        }
    }
}