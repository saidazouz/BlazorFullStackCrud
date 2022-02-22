using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;
        public NavigationManager _NavigationManager { get; }


        public SuperHeroService(HttpClient http,NavigationManager navigationManager)
        {
            _http = http;
            _NavigationManager = navigationManager;
        }
        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get ; set; } = new List<Comic> { };

        public async Task CreateHero(SuperHero newHero)
        {
            var result = await _http.PostAsJsonAsync("api/superhero", newHero);
            await SetHeroes(result);
        }

        private async Task SetHeroes(HttpResponseMessage result)
        {
            var respone = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            Heroes = respone;
            _NavigationManager.NavigateTo("superheroes");
        }

        public async Task DeleteHero(int id)
        {
            var result = await _http.DeleteAsync($"api/superhero/{id}");
            await SetHeroes(result);
        }

        public async Task<List<Comic>> GetComics()
        {
            var result = await _http.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
            if (result != null)
            {
                Comics = result;
                return Comics;
            }

            throw new Exception("Comics not found !!");
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
            if (result != null)
                return result;

            throw new Exception("Hero not found !!");
        }

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync <List<SuperHero>>("api/superhero");
            if(result != null)
            {
                Heroes = result;
                return Heroes;
            }

            throw new Exception("Heros not found !!");


        }

        public async Task UpdateHero(SuperHero hero)
        {
            var result = await _http.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
            await SetHeroes(result);
        }
    }
}
