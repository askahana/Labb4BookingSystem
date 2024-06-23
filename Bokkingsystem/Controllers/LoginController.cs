using AutoMapper;
using Bokkingsystem.Data;
using Bokkingsystem.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Bokkingsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly BookingDbContext _dbContext;
        public LoginController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IConfiguration config,
        IMapper mapper,
        BookingDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        /*
        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount(LoginDTO model)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return BadRequest("User already exists.");
            }

            AppUser newUser = _mapper.Map<AppUser>(model);
            newUser.UserName = model.Email;

            IdentityResult result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest("User creation failed.");
            }

            Claim[] userClaims = new[]
            {
            new Claim(ClaimTypes.Email, model.Email),
            new Claim(ClaimTypes.Role, model.Role),
        };

            await _userManager.AddClaimsAsync(newUser, userClaims);

            return Ok("User created successfully.");
        }
        /*

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest("Invalid credentials.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: await _userManager.GetClaimsAsync(user),
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }*/

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var customer = await _dbContext.Customers.SingleOrDefaultAsync(c => c.Email == model.Email);
            var company = await _dbContext.Companies.SingleOrDefaultAsync(c => c.Email == model.Email);

            if (customer == null && company == null)
            {
                return NotFound("User not found.");
            }

            var user = customer ?? (object)company;

            bool isPasswordValid;
            if (customer != null)
            {
                isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, customer.Password);
            }
            else
            {
                isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, company.Password);
            }

            if (!isPasswordValid)
            {
                return BadRequest("Invalid credentials.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Role, model.Role),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
