using GameLibrary.Api.Models;
using GameLibrary.Api.Repositories;

namespace GameLibrary.Api.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        return await _gameRepository.GetGameByIdAsync(id);
    }

    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        return await _gameRepository.GetAllGamesAsync();
    }

    public async Task<Game> CreateGameAsync(string title, string description, decimal price)
    {
        var game = new Game
        {
            Title = title,
            Description = description,
            Price = price,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return await _gameRepository.AddGameAsync(game);
    }

    public async Task<bool> DeleteGameAsync(int id)
    {
        return await _gameRepository.DeleteGameAsync(id);
    }
}