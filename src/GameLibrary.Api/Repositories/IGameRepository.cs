using GameLibrary.Api.Models;

namespace GameLibrary.Api.Repositories;

public interface IGameRepository
{
    Task<Game?> GetGameByIdAsync(int id);
    Task<IEnumerable<Game>> GetAllGamesAsync();
    Task<Game> AddGameAsync(Game game);
    Task<bool> DeleteGameAsync(int id);
    Task SaveChangesAsync();
}