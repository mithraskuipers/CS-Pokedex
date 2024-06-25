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

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon.Models.Pokemon>> GetPokemon(int id)
        {
            var pokemon = await _context.pokemon.FirstOrDefaultAsync(p => p.id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }
    }
}
