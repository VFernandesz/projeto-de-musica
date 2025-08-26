using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtistaController : ControllerBase
{
    private readonly AppDbContext _context;

    public ArtistaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Artista>> Get()
    {
        return await _context.Artistas.Include(a => a.Musicas).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Artista>> GetById(int id)
    {
        var artista = await _context.Artistas.Include(a => a.Musicas).FirstOrDefaultAsync(a => a.Id == id);
        if (artista == null) return NotFound();
        return artista;
    }

    [HttpPost]
    public async Task<ActionResult> Post(Artista artista)
    {
        _context.Artistas.Add(artista);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = artista.Id }, artista);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Artista artista)
    {
        if (id != artista.Id) return BadRequest();
        _context.Entry(artista).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var artista = await _context.Artistas.FindAsync(id);
        if (artista == null) return NotFound();
        _context.Artistas.Remove(artista);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}