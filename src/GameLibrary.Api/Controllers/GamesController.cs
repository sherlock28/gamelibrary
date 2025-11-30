using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    [HttpGet(Name = "GetGames")]
    public IActionResult GetGames()
    {
        return Ok();
    }
}
