using Microsoft.AspNetCore.Mvc;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Threading.Tasks;

namespace netgs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario is null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            var usuarioExistente = await _usuarioRepository.BuscarPorEmailAsync(usuario.Email);
            if (usuarioExistente != null)
                return BadRequest("Já existe um usuário com este e-mail.");

            await _usuarioRepository.CreateAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }
    }
}
