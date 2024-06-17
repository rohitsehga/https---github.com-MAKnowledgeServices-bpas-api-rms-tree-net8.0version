using Microsoft.AspNetCore.Mvc;
using ResourceRequestService.Configuration;
using ResourceRequestService.Helpers;
using ResourceRequestService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ResourceRequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OktaController : Controller
    {
        private readonly JwtSettings _jwtSettings;
        private readonly OktaSettings _oktaSettings;
        public OktaController(IOptionsSnapshot<JwtSettings> jwtSettings, IOptionsSnapshot<OktaSettings> oktaSettings)
        {
            _jwtSettings = jwtSettings.Value;
            _oktaSettings = oktaSettings.Value;
        }

        [HttpGet("login")]
        public ActionResult Login()
        {
            AuthRequest request = new AuthRequest(_oktaSettings.Issuer, _oktaSettings.AssertionConsumerServiceUrl);
            string redirecturl = request.GetRedirectUrl(_oktaSettings.SamlEndPoint);
            return Ok(new { data = redirecturl, status = true, message = "Success" });
        }

        [HttpPost("samlconsume")]
        public void SamlConsume()
        {
            SamlResponse samlResponse = new SamlResponse();
            samlResponse.LoadXmlFromBase64(Request.Form["SAMLResponse"]);
            string token = GenerateJwt(samlResponse.GetNameID());
            Response.Cookies.Append("jwt", token);
            Response.Redirect(String.Format("{0}?token={1}", _oktaSettings.RedirectUrl, token));
        }

        [HttpGet("logout")]
        public ActionResult Logout()
        {
            return Redirect(_oktaSettings.SamlEndPoint);
        }

        private string GenerateJwt(string Email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, Email.ToLower()),
                new Claim(ClaimTypes.Name, Email.ToLower()),
                new Claim(ClaimTypes.NameIdentifier, Email.ToLower()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble("60"));
            //var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.ExpirationInMinutes));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    
    //public IActionResult Index()
    //{
    //    return View();
    //}
}
}
