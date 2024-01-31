using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using P140_API.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;

namespace P140_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController:ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountsController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration(RegisterDTO account)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = account.Username,
                Email = account.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user,account.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
            }

            await _userManager.AddToRoleAsync(user, "Member");
            return NoContent();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO account)
        {
            IdentityUser user = await _userManager.FindByNameAsync(account.Username);
            if (user is null) return NotFound();
            bool result = await _userManager.CheckPasswordAsync(user, account.Password);
            if (!result) return BadRequest();

            //Payload
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email)
            };
            IList<string> roles =  await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r=>new Claim(ClaimTypes.Role,r)));

            //Signature
            string keyStr = _configuration["JWT:SecurityKey"];
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
            //Header
            SigningCredentials creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            //Creation section
            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    signingCredentials: creds,
                    expires: DateTime.Now.AddSeconds(20)
                );

            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(tokenStr);
        }
    }
}
