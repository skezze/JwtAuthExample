using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConnectController: ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly UsersDbContext _context;

     public ConnectController(IConfiguration configuration, UsersDbContext context)
     {
         //todo: fix context code 500 System.InvalidOperationException: Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbContext' while attempting to activate 'WebApiExample.Controllers.ConnectController'.
         _context = context;
         _configuration = configuration;
     }

    [HttpGet]
    [Authorize]
    [Route("/connect")]
    public IActionResult getAuthorizedConnect()
    {
        return Ok("autorized");
    }


}