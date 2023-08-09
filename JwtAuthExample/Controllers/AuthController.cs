using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JwtAuthExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController:ControllerBase
{
    private Product[] Products = Product.GetArrayProducts();
    private User[] Users = Models.User.GetArrayUsers();
    private readonly IConfiguration _configuration;
    private readonly ISecurityKey _securityKey;

    public AuthController( IConfiguration configuration, ISecurityKey securityKey)
    {
       
        _configuration = configuration;
        _securityKey = securityKey;
    }

    [HttpGet]
    [Route("/getproducts")]
    public IActionResult GetProducts()
    {
        return Ok(Products);
    }

    [HttpGet]
    [Route("/getsecretkey")]
    public IActionResult GetTokenSecretKey()
    {
        return Ok(_securityKey.Key);
    }

    [HttpPost]
    [Route("/gettoken")]
    public IActionResult GetToken([FromBody] User user)
    {
        if (!Users.Any(x=>x.Login==user.Login&&x.Password==user.Password)) {
            return NotFound("user not found");
        }
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_securityKey.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Login)
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(tokenHandler.WriteToken(token));
    }

    [HttpGet]
    [Route("/login")]
    [Authorize]
    public IActionResult Login()
    {
        return Ok(Products);
    }

}
