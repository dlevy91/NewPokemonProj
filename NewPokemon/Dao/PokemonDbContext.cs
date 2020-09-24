using Microsoft.EntityFrameworkCore;
using NewPokemon.Models;

namespace NewPokemon.Dao
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base (options)
        {            
        }

        public DbSet<PokemonModel> pokemon {get; set;}
    }
}