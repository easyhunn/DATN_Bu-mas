using CoreBL.Interface;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace bumas_api.Controllers
{
    public class LoginCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static readonly SigningCredentials SigningCreds = new SigningCredentials(Startup.SecurityKey, SecurityAlgorithms.HmacSha256);
        private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
        private IAccountBL _AccountBL;
        public AccountController(IAccountBL AccountBL)
        {
            this._AccountBL = AccountBL;
        }
        [HttpPost("login")]
        public async Task Login([FromBody] LoginCredentials creds)
        {

        }

        [HttpPost("token")]
        public Object Token([FromBody] LoginCredentials creds)
        {
            // We will typically move the validation of credentials
            // and return of matched principal into its own AuthenticationService
            // Leaving it here for convenience of the sample project/article
            if (!ValidateLogin(creds))
            {
                return new
                {
                    error = "Login failed"
                };
            }
            var principal = GetPrincipal(creds, Startup.JWTAuthScheme);
            var token = new JwtSecurityToken(
                "soSignalR",
                "soSignalR",
                principal.Claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: SigningCreds);

            return new
            {
                token = _tokenHandler.WriteToken(token),
                name = principal.Identity.Name,
                email = principal.FindFirstValue(ClaimTypes.Email),
                role = principal.FindFirstValue(ClaimTypes.Role),
                orgId = AuthUtil.orgId,
                userName = AuthUtil.userName,
                orgGrade = AuthUtil.orgGrade
            };
        }
        private bool ValidateLogin(LoginCredentials creds)
        {
            var res = false;
            var user = _AccountBL.getUserInfo(creds.Email, creds.Password);
            if (user != null && user.id != null && user.id != Guid.Empty)
            {
                AuthUtil.userName = user.user_name;
                AuthUtil.orgId = user.org_id;
                AuthUtil.parentOrgId = user.parent_org_id;
                AuthUtil.userId = user.id;
                AuthUtil.orgGrade = user.org_grade;
                res = true;
            } else
            {
                res = false;
            }
            // For our sample app, all logins are successful!
            return res;
        }
        private ClaimsPrincipal GetPrincipal(LoginCredentials creds, string authScheme)
        {
            // Here we are just creating a Principal for any user, 
            // using its email and a hardcoded “User” role
            var claims = new List<Claim>
              {
                  new Claim(ClaimTypes.Name, creds.Email),
                  new Claim(ClaimTypes.Email, creds.Email),
                  new Claim(ClaimTypes.Role,"User"),
              };
            return new ClaimsPrincipal(new ClaimsIdentity(claims, authScheme));
        }
    }

}
