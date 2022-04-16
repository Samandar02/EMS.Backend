using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.IdentityModel.Tokens;

namespace WhileLearnAsp.NetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public UserManager<IdentityUser> _userManager { get; set; }
        public SignInManager<IdentityUser> _signInManager { get; set; }
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Models.Credentials credentials)
        {
            var user = new IdentityUser { UserName = "admin", Email = "admin@mail.ru" };

            var result = await _userManager.CreateAsync(user, "aaA11!");
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            await _signInManager.SignInAsync(user, false);
            return Ok("200 Muwaffaqiyatli yaratikdi kirishingiz mumkin!");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Models.Credentials credentials)
        {
            var result = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, false, false);
            if (!result.Succeeded)
                return BadRequest();
            var user = await _userManager.FindByEmailAsync("admin@mail.ru");
            return Ok(CreateToken(user));
        }
        private string CreateToken(IdentityUser user)
        {
            // tokenni imzolash
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EmployeeDbContexts"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[] // payloadga claim yordamida malumot joylash
            {
                new Claim("user_id",user.Id)
            };
            var header = new JwtHeader(signingCredentials);
            var payload = new JwtPayload(claims);
            var jwt = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}