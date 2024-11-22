using Microsoft.AspNetCore.Mvc;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace netgs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DicaController : ControllerBase
    {
        private readonly IDicaRepository _dicaRepository;

        public DicaController(IDicaRepository dicaRepository)
        {
            _dicaRepository = dicaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dicas = await _dicaRepository.GetAllAsync();
            return Ok(dicas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var dica = await _dicaRepository.GetByIdAsync(id);
            if (dica is null)
                return NotFound();

            return Ok(dica);
        }

        [HttpGet("categoria/{categoriaId}")]
        public async Task<IActionResult> GetByCategoria(string categoriaId)
        {
            var dicas = await _dicaRepository.BuscarPorCategoria(categoriaId);
            return Ok(dicas);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dica dica)
        {
            await _dicaRepository.CreateAsync(dica);
            return CreatedAtAction(nameof(GetById), new { id = dica.Id }, dica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Dica dicaAtualizada)
        {
            var dicaExistente = await _dicaRepository.GetByIdAsync(id);
            if (dicaExistente is null)
                return NotFound();

            dicaAtualizada.Id = id;
            await _dicaRepository.UpdateAsync(id, dicaAtualizada);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var dicaExistente = await _dicaRepository.GetByIdAsync(id);
            if (dicaExistente is null)
                return NotFound();

            await _dicaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
