using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Newton.VideoGameCatalogue.Server;

/// <summary>
/// Represents the Entity Framework database context for managing game data.
/// </summary>
/// <remarks> The context seeds the Games table with a predefined set of game data for demonstration purposes when the model is created.</remarks>
/// <param name="options">The options to configure the database context, such as the database provider and connection settings.</param>
public class GameContext(DbContextOptions<GameContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the collection of games tracked by the context.
    /// </summary>
    /// <remarks>This property provides access to query, add, update, or remove <see cref="Game"/> entities in
    /// the database. Changes made to the collection are tracked and persisted when <c>SaveChanges</c> is called on the
    /// context.</remarks>
    public DbSet<Game> Games { get; set; }

    /// <summary>
    /// Seeds the Games table for demonstration purposes.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // I got the ratings from metacritic.com and partly from Steam. No offense to any game developers out there!
        // Explicit Ids are needed for seeding data.
        modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, Title = "Total War: MEDIEVAL II", Genre = "Strategy", ReleaseYear = 2006, Rating = 8.8 },
            new Game { Id = 2, Title = "Age of Empires II: Definitive Edition", Genre = "Strategy", ReleaseYear = 2019, Rating = 8.4 },
            new Game { Id = 3, Title = "Ancestors: The Humankind Odyssey", Genre = "Survival", ReleaseYear = 2020, Rating = 6.4 },
            new Game { Id = 4, Title = "Assassin's Creed Revelations", Genre = "RPG", ReleaseYear = 2011, Rating = 8.0 },
            new Game { Id = 5, Title = "Assassin's Creed III Remastered", Genre = "RPG", ReleaseYear = 2019, Rating = 7.2 },
            new Game { Id = 6, Title = "Assassin's Creed Odyssey", Genre = "RPG", ReleaseYear = 2018, Rating = 8.3 },
            new Game { Id = 7, Title = "Assassin's Creed Origins", Genre = "RPG", ReleaseYear = 2017, Rating = 8.3 },
            new Game { Id = 8, Title = "Call of Duty (2003)", Genre = "FPS", ReleaseYear = 2003, Rating = 9.8 },
            new Game { Id = 9, Title = "Catan Universe", Genre = "Board Game", ReleaseYear = 2017, Rating = 6.1 },
            new Game { Id = 10, Title = "Cities Skylines", Genre = "Strategy", ReleaseYear = 2015, Rating = 8.5 },
            new Game { Id = 11, Title = "Cyberpunk 2077", Genre = "RPG", ReleaseYear = 2020, Rating = 8.6 },
            new Game { Id = 12, Title = "Detroit: Become Human", Genre = "Story", ReleaseYear = 2018, Rating = 7.8 },
            new Game { Id = 13, Title = "The Elder Scrolls V: Skyrim Special Edition", Genre = "RPG", ReleaseYear = 2016, Rating = 8.4 },
            new Game { Id = 14, Title = "Europa Universalis IV", Genre = "Strategy", ReleaseYear = 2013, Rating = 8.7 },
            new Game { Id = 15, Title = "FOR HONOR", Genre = "Fighting", ReleaseYear = 2017, Rating = 7.8 },
            new Game { Id = 16, Title = "Grand Theft Auto III", Genre = "Open World", ReleaseYear = 2001, Rating = 9.7 },
            new Game { Id = 17, Title = "Grand Theft Auto: San Andreas", Genre = "Open World", ReleaseYear = 2004, Rating = 9.5 },
            new Game { Id = 18, Title = "Grand Theft Auto: Vice City", Genre = "Open World", ReleaseYear = 2002, Rating = 9.5 },
            new Game { Id = 19, Title = "Kingdom: Classic", Genre = "Strategy", ReleaseYear = 2015, Rating = 8.3 },
            new Game { Id = 20, Title = "Kingdom Come: Deliverance II", Genre = "RPG", ReleaseYear = 2025, Rating = 8.8 },
            new Game { Id = 21, Title = "Mini Metro", Genre = "Puzzle", ReleaseYear = 2015, Rating = 8.6 },
            new Game { Id = 22, Title = "Mini Motorways", Genre = "Puzzle", ReleaseYear = 2021, Rating = 8.7 },
            new Game { Id = 23, Title = "Mount & Blade II: Bannerlord", Genre = "Strategy", ReleaseYear = 2022, Rating = 7.7 },
            new Game { Id = 24, Title = "Oxygen Not Included", Genre = "Strategy", ReleaseYear = 2019, Rating = 8.5 },
            new Game { Id = 25, Title = "Portal", Genre = "Puzzle", ReleaseYear = 2007, Rating = 9.0 },
            new Game { Id = 26, Title = "Portal 2", Genre = "Puzzle", ReleaseYear = 2011, Rating = 9.5 },
            new Game { Id = 27, Title = "Raji: An Ancient Epic", Genre = "Action", ReleaseYear = 2020, Rating = 6.9 },
            new Game { Id = 28, Title = "Sekiro: Shadows Die Twice", Genre = "Souls-like", ReleaseYear = 2019, Rating = 9.0 },
            new Game { Id = 29, Title = "Sid Meier's Civilization VI", Genre = "Strategy", ReleaseYear = 2016, Rating = 8.8 },
            new Game { Id = 30, Title = "Stray", Genre = "Puzzle", ReleaseYear = 2022, Rating = 8.3 },
            new Game { Id = 31, Title = "Totally Accurate Battlegrounds", Genre = "FPS", ReleaseYear = 2018, Rating = 9.2 },
            new Game { Id = 32, Title = "The Witcher 3: Wild Hunt", Genre = "RPG", ReleaseYear = 2015, Rating = 9.2 },
            new Game { Id = 33, Title = "Zeus: Master of Olympus", Genre = "Strategy", ReleaseYear = 2000, Rating = 8.7 });
    }
}

public class Game
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Title { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Genre { get; set; }

    [Range(1950, 2100)]
    public int ReleaseYear { get; set; }

    [Range(0, 10)]
    public double Rating { get; set; }
}
