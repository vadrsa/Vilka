using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using BusinessEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration =     configuration;
        }

        public ActionResult<object> Connect()
        {
            return "Successfully connected!";
        }
        
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            
            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return new UserClientDto { Email = appUser.Email, Username = appUser.UserName, Token = await GenerateJwtToken(model.Email, appUser) };
            }

            throw new Exception("Wrong credentials.");
        }
       
        [HttpPost]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            var user = new User
            {
                UserName = model.Email, 
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return new UserClientDto { Email = user.Email, Username = user.UserName, Token = await GenerateJwtToken(model.Email, user) };
            }
            
            throw new ApplicationException("UNKNOWN_ERROR");
        }
        
        private async Task<object> GenerateJwtToken(string email, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        public class LoginDto
        {
            [Required]
            public string Email { get; set; } = "";

            [Required]
            public string Password { get; set; } = "";
            
        }

        public class UserClientDto
        { 
            public string Email { get; set; }
            public string Username { get; set; }
            public object Token { get; set; }
        }
        
        public class RegisterDto
        {
            [Required]
            public string Email { get; set; } = "";

            [Required]
            [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
            public string Password { get; set; } = "";
        }
    }
}
