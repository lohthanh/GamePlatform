using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamePlatform.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly Logger<GameController> _logger;

        public GameController(DataContext context, Logger<GameController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            _logger.LogInformation("Getting games");
            var games = await _context.Games.Include(g => g.GamePlatforms).ToListAsync();
            return Ok(games);
        }

        [HttpGet("platforms")]
        public async Task<ActionResult<List<Platform>>> GetPlatforms()
        {
            var platforms = await _context.Platforms.ToListAsync();
            return Ok(platforms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetSingleGame(int id)
        {
            var game = await _context.Games
                .Include(g => g.GamePlatforms)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (game == null)
            {
                return NotFound("Sorry, no game here. :/");
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<List<Game>>> CreateGame(Game game)
        {
            game.GamePlatforms = null;
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGames());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Game>>> UpdateGame(Game game, int id)
        {
            var dbGame = await _context.Games
                .Include(g => g.GamePlatforms)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (dbGame == null)
                return NotFound("Sorry, but no game for you. :/");

            dbGame.Name = game.Name;

            await _context.SaveChangesAsync();

            return Ok(await GetDbGames());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Game>>> DeleteGame(int id)
        {
            var dbGame = await _context.Games
                .Include(g => g.GamePlatforms)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbGame == null)
                return NotFound("Sorry, but no hero for you. :/");

            _context.Games.Remove(dbGame);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGames());
        }

        private async Task<List<Game>> GetDbGames()
        {
            return await _context.Games.Include(g => g.GamePlatforms).ToListAsync();
        }
    }
}
