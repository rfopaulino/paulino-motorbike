using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Paulino.Motorbike.Api.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Paulino.Motorbike.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password, string role, string email)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
                return BadRequest("Invalid role.");

            var user = new IdentityUser
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
                await _userManager.SetLockoutEnabledAsync(user, false);
                return Ok();
            }
            else
            {
                var errors = string.Join(Environment.NewLine, result.Errors.Select(x => x.Description));
                return BadRequest(errors);
            }
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return Unauthorized();

            var response = await GenerateToken(user);

            return Ok(response);
        }

        private async Task<AuthResponse> GenerateToken(IdentityUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtOptions:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var claims = await GetClaims(user);
            var expiresIn = DateTime.Now.AddHours(2);

            var jwt = new JwtSecurityToken(
                issuer: _configuration["JwtOptions:Issuer"],
                audience: _configuration["JwtOptions:Audience"],
                claims: claims,
                expires: expiresIn,
                signingCredentials: creds);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AuthResponse
            {
                AccessToken = accessToken,
                Type = "Bearer",
                ExpiresIn = expiresIn
            };
        }

        private async Task<IList<Claim>> GetClaims(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iss, _configuration["JwtOptions:Issuer"]));
            claims.Add(new Claim(JwtRegisteredClaimNames.Aud, _configuration["JwtOptions:Audience"]));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;
        }
    }
}
