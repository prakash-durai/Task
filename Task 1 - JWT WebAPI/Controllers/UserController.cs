using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Models;
using QuizAPI.Database;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace QuizAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("corsapp")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserDbContext _dbContext;

        public UserController(IConfiguration configuration, UserDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            if (_dbContext?.Users?.Where(u => u.Email == user.Email).FirstOrDefault() != null)
            {
                return Ok("Already exists");
            }
            else
            {
                user.MemberSince = DateTime.Now;
                _dbContext?.Users?.Add(user);
                _dbContext?.SaveChanges();
                return Ok("Success");
            }
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var availableUser = _dbContext?.Users?.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if(availableUser != null)
            {
                var token = GenerateToken(availableUser.FirstName, availableUser.LastName, availableUser.Email, availableUser.Mobile, availableUser.Gender);
                return Ok(token);
            }
            else
            {
                return Ok("Failure");
            }
        }
        private string GenerateToken(string? firstname,string? lastname,string? email,string? mobile, string? gender){
            if(email is null || firstname is null || lastname is null || mobile is null || gender is null){
                return "";
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:key"]));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var claims = new[]{
                new Claim("Email", email),
                new Claim("FirstName", firstname),
                new Claim("Lastname", lastname),
                new Claim("Mobile", mobile),
                new Claim("Gender", gender)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:Issuer"],
                audience: _configuration["JwtConfig:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("UploadScore")]
        public IActionResult UploadScore(Scoreboard scoreboard){
            _dbContext?.Scoreboards?.Add(scoreboard);
            _dbContext?.SaveChanges();
            return Ok("Score uploaded");
        }
    }
}