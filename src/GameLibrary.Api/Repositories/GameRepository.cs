using GameLibrary.Api.Data;
using GameLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GameLibraryDbContext _context;

    public GameRepository(GameLibraryDbContext context)
    {
        _context = context;
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        return await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<Game> AddGameAsync(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<bool> DeleteGameAsync(int id)
    {
        var game = await GetGameByIdAsync(id);
        if (game == null)
            return false;

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}