using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using System.Threading.Tasks;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PokemonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/pokemon/{id}
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Pokemon.Models.Pokemon>> GetPokemon(int id)
        {
            var pokemon = await _context.pokemon.FirstOrDefaultAsync(p => p.id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }

        // GET api/pokemon/byname/{name}
        [HttpGet("name/{name}")]
        public async Task<ActionResult<Pokemon.Models.Pokemon>> GetPokemonByName(string name)
        {
            var pokemon = await _context.pokemon.FirstOrDefaultAsync(p => p.name == name);
            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }
    }
}
