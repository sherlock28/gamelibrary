using GameLibrary.Api.Models;

namespace GameLibrary.Api.Services;

public interface IGameService
{
    Task<Game?> GetGameByIdAsync(int id);
    Task<IEnumerable<Game>> GetAllGamesAsync();
    Task<Game> CreateGameAsync(string title, string description, decimal price);
    Task<bool> DeleteGameAsync(int id);
}