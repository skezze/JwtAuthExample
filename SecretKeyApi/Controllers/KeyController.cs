using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SecretKeyApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class KeyController:ControllerBase
{
    private readonly IConfiguration _configuration;

    public KeyController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet]
    [Route("/getkey")]

    public IActionResult GetKey()
    {
        return Ok(_configuration["Key"]);
    }
}