namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> Heroes { get; set; }
        List<Comic> Comics { get; set; }
        Task<List<Comic>> GetComics();
        Task<List<SuperHero>> GetSuperHeroes();
        Task<SuperHero> GetSingleHero(int id);
        Task CreateHero(SuperHero newHero);
        Task UpdateHero(SuperHero hero);
        Task DeleteHero(int id);

    }
}
