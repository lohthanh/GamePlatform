using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace GamePlatform.Client.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public GameService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Game> Games { get; set; } = new List<Game>();
        public List<Platform> Platforms { get; set; } = new List<Platform>();

        public async Task CreateGame(Game game)
        {
            var result = await _http.PostAsJsonAsync("api/games", game);
            await SetGames(result);
        }

        private async Task SetGames(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Game>>();
            Games = response;
            _navigationManager.NavigateTo("games");
        }

        public async Task DeleteGame(int id)
        {
            var result = await _http.DeleteAsync($"api/games/{id}");
            await SetGames(result);
        }

        public async Task GetPlatforms()
        {
            var result = await _http.GetFromJsonAsync<List<Platform>>("api/games/platforms");
            if (result != null)
                Platforms = result;
        }

        public async Task<Game> GetSingleGame(int id)
        {
            var result = await _http.GetFromJsonAsync<Game>($"api/games/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task GetGames()
        {
            var result = await _http.GetFromJsonAsync<List<Game>>("api/games");
            if (result != null)
                Games = result;
        }

        public async Task UpdateGame(Game game)
        {
            var result = await _http.PutAsJsonAsync($"api/games/{game.Id}", game);
            await SetGames(result);
        }
    }
}
