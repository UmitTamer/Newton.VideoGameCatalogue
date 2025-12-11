using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newton.VideoGameCatalogue.Server;
using Newton.VideoGameCatalogue.Server.Controllers;

namespace Newton.VideoGameCatalogue.NTests
{
    [TestFixture]
    public class GamesControllerTests
    {
        static Game[] CreateSampleGames() => [
            new() { Title = "Sample Game 1", Genre = "Action", ReleaseYear = 2021, Rating = 9 },
            new() { Title = "Sample Game 2", Genre = "RPG", ReleaseYear = 2021, Rating = 8 },
            new() { Title = "Sample Game 3", Genre = "FPS", ReleaseYear = 2000, Rating = 9 },
            new() { Title = "Sample Game 4", Genre = "MMORPG", ReleaseYear = 1999, Rating = 8 },
            new() { Title = "Sample Game 5", Genre = "Puzzle", ReleaseYear = 2026, Rating = 5 },
            new() { Title = "Sample Game 6", Genre = "Story", ReleaseYear = 2021, Rating = 8 },
            new() { Title = "Sample Game 7", Genre = "Arcade", ReleaseYear = 2021, Rating = 7 },
            new() { Title = "Sample Game 8", Genre = "RPG", ReleaseYear = 2021, Rating = 8 }
        ];

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public async Task GetGames_ReturnsListOfGames(int count)
        {
            // Arrange
            var controller = GetControllerWithGameCount(count);

            // Act
            var result = await controller.GetGames();

            // Assert
            result.Value.Should().NotBeNull();
            result.Value.Should().HaveCount(count);
        }

        [Test]
        public async Task GetGame_ReturnGame_ForValidId()
        {
            const int id = 1;

            // Arrange
            var controller = GetControllerWithData(CreateSampleGames());

            // Act
            var result = await controller.GetGame(id);

            // Assert
            result.Value.Should().NotBeNull();
            result.Value.Id.Should().Be(id);
        }

        [Test]
        public async Task GetGame_ReturnsNotFound_ForInvalidId()
        {
            // Arrange
            var games = CreateSampleGames();

            // Act
            var controller = GetControllerWithData(games);

            // Assert
            var result = await controller.GetGame(games.Length + 10);
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public async Task CreateGame_ReturnsCreatedAt()
        {
            // Arrange
            var controller = GetControllerWithData();
            var newGame = CreateSampleGames()[0];

            // Act
            var result = await controller.CreateGame(newGame);

            // Assert
            result.Result.Should().BeOfType<CreatedAtActionResult>().And.NotBeNull();
            var createdResult = result.Result as CreatedAtActionResult;
            createdResult!.Value.Should().BeOfType<Game>().And.NotBeNull();
            var createdGame = createdResult?.Value as Game;
            createdGame!.Id.Should().BeGreaterThan(0);
            createdGame.Title.Should().Be(newGame.Title);
            createdGame.Genre.Should().Be(newGame.Genre);
            createdGame.Rating.Should().Be(newGame.Rating);
            createdGame.ReleaseYear.Should().Be(newGame.ReleaseYear);
        }

        [Test]
        public async Task UpdateGame_ReturnsOkResult()
        {
            // Arrange
            Game game = new() { Title = "Sample Game 1", Genre = "Action", ReleaseYear = 2021, Rating = 9 };
            var controller = GetControllerWithData(game);
            var games = await controller.GetGames();
            game = games.Value![0];
            Game updatedGame = new()
            {
                Id = game.Id,
                Title = "Sample Game 1 Remastered",
                Genre = "Card Game",
                ReleaseYear = 2025,
                Rating = 1
            };

            // Act
            var result = await controller.UpdateGame(game.Id, updatedGame);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>().And.NotBeNull();
            var okObjectResult = result.Result as OkObjectResult;
            okObjectResult!.Value.Should().BeOfType<Game>().And.NotBeNull();
            var resultOfUpdate = okObjectResult.Value as Game;
            resultOfUpdate!.Id.Should().Be(updatedGame.Id);
            resultOfUpdate.Title.Should().Be(updatedGame.Title);
            resultOfUpdate.Genre.Should().Be(updatedGame.Genre);
            resultOfUpdate.Rating.Should().Be(updatedGame.Rating);
            resultOfUpdate.ReleaseYear.Should().Be(updatedGame.ReleaseYear);
        }

        [Test]
        public async Task UpdateGame_UpdatesTheRecord()
        {
            // Arrange
            Game game = new() { Title = "Sample Game 1", Genre = "Action", ReleaseYear = 2021, Rating = 9 };
            var controller = GetControllerWithData(game);
            var games = await controller.GetGames();
            game = games.Value![0];
            Game updatedGame = new()
            {
                Id = game.Id,
                Title = "Sample Game 1 Remastered",
                Genre = "Card Game",
                ReleaseYear = 2025,
                Rating = 1
            };

            // Act
            await controller.UpdateGame(game.Id, updatedGame);
            var result = await controller.GetGame(game.Id);

            // Arrange
            result.Value.Should().NotBeNull();
            result.Value.Id.Should().Be(game.Id);
            result.Value.Title.Should().Be(updatedGame.Title);
            result.Value.Genre.Should().Be(updatedGame.Genre);
            result.Value.Rating.Should().Be(updatedGame.Rating);
            result.Value.ReleaseYear.Should().Be(updatedGame.ReleaseYear);
        }

        [Test]
        public async Task UpdateGame_ReturnsNotFound_ForUnexistingGame()
        {
            // Arrange
            var controller = GetControllerWithData();
            Game updatedGame = new()
            {
                Id = 999,
                Title = "Non-existing Game",
                Genre = "Card Game",
                ReleaseYear = 2025,
                Rating = 1
            };

            // Act
            var result = await controller.UpdateGame(updatedGame.Id, updatedGame);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public async Task DeleteGame_ReturnsNotFound_ForUnexistingGame()
        {
            // Arrange
            var controller = GetControllerWithData();

            // Act
            var result = await controller.DeleteGame(999);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public async Task DeleteGame_ReturnsOkResult_ForExistingGame()
        {
            // Arrange
            Game game = new() { Title = "Sample Game 1", Genre = "Action", ReleaseYear = 2021, Rating = 9 };
            var controller = GetControllerWithData(game);
            var games = await controller.GetGames();
            int gameId = games.Value![0].Id;

            // Act
            var result = await controller.DeleteGame(gameId);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>().And.NotBeNull();
            var okObjectResult = result.Result as OkObjectResult;
            okObjectResult!.Value.Should().BeOfType<Game>().And.NotBeNull();
            var deletedGame = okObjectResult.Value as Game;
            deletedGame!.Id.Should().Be(gameId);
        }

        [Test]
        public async Task DeleteGame_RemovesTheRecord()
        {
            // Arrange
            var games = CreateSampleGames();
            var controller = GetControllerWithData(games);
            var getGamesResult = await controller.GetGames();
            int gameId = getGamesResult.Value![0].Id;

            // Act
            await controller.DeleteGame(gameId);
            var result = await controller.GetGame(gameId);
            getGamesResult = await controller.GetGames();

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
            getGamesResult.Value!.Select(g => g.Id).Should().NotContain(gameId);
        }

        static GamesController GetControllerWithGameCount(int count)
        {
            Game[] games;
            if (count > 0)
            {
                games = CreateSampleGames();
                count = Math.Min(count, games.Length);
                games = games[..count];
            }
            else
            {
                games = [];
            }

            return GetControllerWithData(games);
        }

        static GamesController GetControllerWithData(params IEnumerable<Game> games)
        {
            var options = new DbContextOptionsBuilder<GameContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new GameContext(options);
            context.Games.AddRange(games);
            context.SaveChanges();

            return new GamesController(context);
        }
    }
}
