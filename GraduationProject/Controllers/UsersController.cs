using GraduationProject.API.Data.Models;
using GraduationProject.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GraduationProject.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public UsersController(JwtOptions jwtOptions, UserManager<ApplicationUser> userManager)
        {
            _jwtOptions = jwtOptions;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<AutheModel>> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
                return new AutheModel { Massage = "Not Found !" };

            var checkPassowrd = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!checkPassowrd)
                return new AutheModel { Massage = "Invaled Data !" };

            return new AutheModel
            {
                IsAuthenticated = true,
                Token =  GetJwtToken(user),
                UserId = user.Id,
                Email = user.Email,
                UserName = user.Name
            };
        }
        [HttpPost]
        public async Task<ActionResult<AutheModel>> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var isExest = await _userManager.Users.AnyAsync(a => a.NormalizedEmail == model.Email.ToUpper());

            if (isExest)
                return new AutheModel { Massage = "User is already Registered !" };

            var user = new ApplicationUser
            {
                Email = model.Email,
                Name = model.UserName,
                UserName = model.Email,
            };
            var result =await  _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return new AutheModel
                {
                    Massage = string.Join(" , ", result.Errors.Select(a => a.Description))
                };



            return new AutheModel
            {
                IsAuthenticated = true,
                Token =  GetJwtToken(user),
                UserId = user.Id,
                UserName = user.Name,
                Email = user.Email,
            };
        }
        private string GetJwtToken(ApplicationUser user)
        {

            var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new Claim(JwtRegisteredClaimNames.Name, user.Name!),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Expires = DateTime.Now.AddHours(_jwtOptions.DurationInHours),
                SigningCredentials = new SigningCredentials
                (
                    key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)),
                    algorithm: SecurityAlgorithms.HmacSha256
                ),
                Subject = new ClaimsIdentity(claims)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accesstoken = tokenHandler.WriteToken(securityToken);
            return accesstoken;
        }

    }
}
