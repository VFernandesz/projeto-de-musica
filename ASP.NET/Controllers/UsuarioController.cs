// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity;
// using System.Security.Claims;
// using System.IdentityModel.Tokens.Jwt;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using System.Security.Principal;

// using Api.Data;

// namespace Api.Models
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class UsuarioController : ControllerBase
//     {
//         private readonly AppDbContext _context;
//         private readonly IConfiguration _configuration;

//         public UsuarioController(AppDbContext context, IConfiguration configuration)
//         {
//             _context = context;
//             _configuration = configuration;
//         }

//         [HttpGet]
//         public async Task<IEnumerable<Usuario>> Get()
//         {
//             return await _context.Usuarios.ToListAsync();
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<Usuario>> GetById(int id)
//         {
//             var usuario = await _context.Usuarios.FindAsync(id);

//             if (usuario == null) return NotFound();
//             return usuario;
//         }

//         [HttpPost]
//         public async Task<ActionResult> Post(Usuario usuario)
//         {
//             // Aqui você deve implementar uma maneira de criptografar/salvar a senha.
//             // Por exemplo, usando BCrypt ou outro método de hashing
//             _context.Usuarios.Add(usuario);
//             await _context.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
//         }

//         [HttpPut("{id}")]
//         public async Task<ActionResult> Put(int id, Usuario usuario)
//         {
//             if (id != usuario.Id) return BadRequest();
//             _context.Entry(usuario).State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<ActionResult> Delete(int id)
//         {
//             var usuario = await _context.Usuarios.FindAsync(id);
//             if (usuario == null) return NotFound();
//             _context.Usuarios.Remove(usuario);
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }

//         [HttpPost("login")]
//         public async Task<ActionResult<string>> Login([FromBody] LoginDto loginDto)
//         {
//             var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == loginDto.Email);
            
//             // Aqui você deve verificar a senha corretamente.
//             // Não se esqueça de usar a mesma lógica que você usou para criar o hash da senha.
//             if (usuario == null || usuario.Senha != loginDto.Senha) 
//                 return Unauthorized();

//             var tokenHandler = new JwtSecurityTokenHandler();
//             var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = new ClaimsIdentity(new[]
//                 {
//                     new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
//                     new Claim(ClaimTypes.Name, usuario.Nome)
//                 }),
//                 Expires = DateTime.UtcNow.AddHours(1),
//                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//             };

//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             return Ok(new { Token = tokenHandler.WriteToken(token) });
//         }
//     }

//     public class LoginDto
//     {
//         public string Email { get; set; }
//         public string Senha { get; set; }
//     }
// }