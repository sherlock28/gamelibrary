using GameLibrary.Api.DTOs;
using GameLibrary.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;

    public GamesController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet(Name = "GetGames")]
    public async Task<IActionResult> GetGames()
    {
        var games = await _gameService.GetAllGamesAsync();
        return Ok(games);
    }

    [HttpGet("{id}", Name = "GetGameById")]
    public async Task<IActionResult> GetGameById(int id)
    {
        var game = await _gameService.GetGameByIdAsync(id);
        if (game == null)
            return NotFound();

        return Ok(game);
    }

    [HttpPost(Name = "CreateGame")]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            return BadRequest("Title is required");

        var game = await _gameService.CreateGameAsync(request.Title, request.Description, request.Price);
        return CreatedAtRoute("GetGameById", new { id = game.Id }, game);
    }

    [HttpDelete("{id}", Name = "DeleteGame")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        var success = await _gameService.DeleteGameAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}
