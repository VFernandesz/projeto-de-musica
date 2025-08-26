using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicaController : ControllerBase
{
    private readonly AppDbContext _context;
    public MusicaController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ICollection<Musica>> Get()
    {
        return await _context.Musicas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Musica>> GetById(int id)
    {
        var musica = await _context.Musicas.FirstOrDefaultAsync(m => m.Id == id);
        if (musica == null) return NotFound();
        return musica;
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Musica>>> Search(string nome)
    {
        if (string.IsNullOrEmpty(nome)) return BadRequest("O nome da música deve ser fornecido.");

        var musicas = await _context.Musicas
            .Include(m => m.Artista)
            .Where(m => m.Nome.Contains(nome))
            .ToListAsync();

        if (musicas == null || !musicas.Any()) return NotFound();

        return musicas;
    }

    [HttpPost]
    public async Task<ActionResult> Post(Musica musica)
    {
        _context.Musicas.Add(musica);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetHashCode), new { id = musica.Id }, musica);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Musica musica)
    {
        if (id != musica.Id) return BadRequest();
        _context.Entry(musica).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var musica = await _context.Musicas.FindAsync(id);
        if (musica == null) return NotFound();
        await _context.SaveChangesAsync();
        return NoContent();
    }
}