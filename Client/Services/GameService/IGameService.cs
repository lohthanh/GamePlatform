namespace GamePlatform.Client.Services.GameService
{
    public interface IGameService
    {
        List<Game> Games { get; set; }
        List<Platform> Platforms { get; set; }
        Task GetPlatforms();
        Task GetGames();
        Task<Game> GetSingleGame(int id);
        Task CreateGame(Game game);
        Task UpdateGame(Game game);
        Task DeleteGame(int id);
    }
}
