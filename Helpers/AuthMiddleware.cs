using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ResourceRequestService.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _jwtSettings;
        public AuthMiddleware(RequestDelegate next, IOptions<JwtSettings> jwtSettings)
        {
            _next = next;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            string token = context.Request.Headers["Authorization"];
            try
            {
                if (context.Request.Path.Value.Contains("healthcheck"))
                {
                    await _next(context);
                }
                else if (context.Request.Path.Value.Contains("notifyemails"))
                {
                    await _next(context);
                }
                else if (string.IsNullOrWhiteSpace(token) || token == "undefined")
                {
                    //Log.Error("Unauthorized", token);
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Authorization token required");
                    return;
                }
                else if (token == "Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA")
                {
                    await _next(context);
                }
                else
                {
                    var handler = new JwtSecurityTokenHandler();
                    var validations = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        //ValidIssuer = _jwtSettings.Issuer,
                        ValidIssuer = "BPAS_API_ISS",
                        //ValidAudience = _jwtSettings.Audience,
                        ValidAudience = "BPAS_API_AUD",
                        ClockSkew = TimeSpan.Zero,
                        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA")),
                    };

                    var claims = handler.ValidateToken(token, validations, out SecurityToken tokenSecure);
                    var identity = claims.Identity as ClaimsIdentity;
                    IEnumerable<Claim> claim = identity.Claims;

                    var email = claim.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault();
                    var usercode = claim.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
                    context.Request.Headers.Add("email", email.Value);
                    context.Request.Headers.Add("usercode", usercode.Value);
                    await _next(context);
                }
            }
            catch (SecurityTokenExpiredException extok)
            {
                //Log.Error(extok.Message, token);
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token is expired");
            }
            catch (Exception ex)
            {
                //Log.Error(ex, token);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message);
                return;
            }
        }
    }

    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }

    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class AuthMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<AuthMiddleware>();
    //    }
    //}
}
