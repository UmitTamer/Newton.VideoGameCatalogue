using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Newton.VideoGameCatalogue.Server.Controllers
{
    /// <summary>
    /// Provides HTTP API endpoints for managing game records, including retrieval, creation, update, and deletion
    /// operations.
    /// </summary>
    /// <remarks>This controller implements standard RESTful operations for the Game resource. All endpoints
    /// return appropriate HTTP status codes based on the outcome of the operation. The controller is registered at the
    /// route 'api/games'.</remarks>
    /// <param name="context">The database context used to access and manage game entities within the data store. Cannot be null.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(GameContext context) : ControllerBase
    {
        /// <summary>
        /// Gets all the games.
        /// </summary>
        /// <returns>An <see cref="ActionResult{T}"/> containing a <see cref="List{T}"/> of <see cref="Game"/> records in the data store.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            return await context.Games
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves the game with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the game to retrieve.</param>
        /// <returns>An <see cref="ActionResult{T}"/> containing the requested <see cref="Game"/> if found; otherwise, a 404 Not
        /// Found response.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await context.Games.FindAsync(id);
            return game is null ? NotFound() : game;
        }

        /// <summary>
        /// Creates a new game and adds it to the data store.
        /// </summary>
        /// <param name="game">The game entity to create. The Id property is ignored and will be set automatically.</param>
        /// <returns>
        /// A 201 Created response containing the created game and a Location header with the URI of the new resource,
        /// or a 400 Bad Request response if the request payload is invalid.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            game.Id = 0; // Avoids overwriting and let the auto-id work.
            context.Games.Add(game);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        /// <summary>
        /// Updates the specified game entity in the data store.
        /// </summary>
        /// <remarks>If a concurrency conflict occurs and the specified game does not exist, a 404 Not
        /// Found response is returned. Otherwise, the exception is propagated.</remarks>
        /// <param name="id">The unique identifier of the game to update. It must correspond to an existing game.</param>
        /// <param name="game">The game entity containing the updated values.</param>
        /// <returns>
        /// A 200 OK response containing the updated game if successful;
        /// a 400 Bad Request response if validation fails;
        /// a 404 Not Found response if the game does not exist.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> UpdateGame(int id, Game game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await context.Games.FindAsync(id);
            if (existing is null)
                return NotFound();

            existing.Title = game.Title;
            existing.Genre = game.Genre;
            existing.ReleaseYear = game.ReleaseYear;
            existing.Rating = game.Rating;

            context.Entry(existing).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await context.Games.AnyAsync(e => e.Id == id))
                {
                    throw;
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(existing);
        }

        /// <summary>
        /// Deletes the game with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the game to delete.</param>
        /// <returns>A 200 OK response containing the deleted game if successful; a 404 Not Found response if the game did not exist.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await context.Games.FindAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            context.Games.Remove(game);
            await context.SaveChangesAsync();
            return Ok(game);
        }
    }
}
