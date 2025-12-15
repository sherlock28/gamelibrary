using GameLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.Data;

public class GameLibraryDbContext : DbContext
{
    public GameLibraryDbContext(DbContextOptions<GameLibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Game>();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.UpdatedAt).IsRequired();
        });

        // Seed data with hardcoded static dates
        modelBuilder.Entity<Game>().HasData(
            new Game
            {
                Id = 1,
                Title = "The Legend of Zelda: Tears of the Kingdom",
                Description = "An epic adventure in the kingdom of Hyrule",
                Price = 69.99m,
                CreatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc)
            },
            new Game
            {
                Id = 2,
                Title = "Elden Ring",
                Description = "A challenging action role-playing game",
                Price = 59.99m,
                CreatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc)
            },
            new Game
            {
                Id = 3,
                Title = "Baldur's Gate 3",
                Description = "A mind-flaying adventure of epic proportions",
                Price = 59.99m,
                CreatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc)
            },
            new Game
            {
                Id = 4,
                Title = "Cyberpunk 2077",
                Description = "An open-world action role-playing game set in the future",
                Price = 49.99m,
                CreatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc)
            },
            new Game
            {
                Id = 5,
                Title = "Starfield",
                Description = "Bethesda's ambitious space exploration RPG",
                Price = 69.99m,
                CreatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 12, 9, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}