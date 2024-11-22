using Microsoft.AspNetCore.Mvc;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace netgs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            return Ok(categorias);
        }

        // GET: api/Categoria/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria is null)
                return NotFound("Categoria não encontrada.");

            return Ok(categoria);
        }

        // GET: api/Categoria/buscar-por-nome/{nome}
        [HttpGet("buscar-por-nome/{nome}")]
        public async Task<IActionResult> BuscarPorNome(string nome)
        {
            var categoria = await _categoriaRepository.BuscarPorNomeAsync(nome);
            if (categoria is null)
                return NotFound("Categoria não encontrada.");

            return Ok(categoria);
        }

        // GET: api/Categoria/existe/{nome}
        [HttpGet("existe/{nome}")]
        public async Task<IActionResult> ExisteCategoria(string nome)
        {
            var existe = await _categoriaRepository.ExisteCategoriaAsync(nome);
            return Ok(new { Existe = existe });
        }

        // GET: api/Categoria/categorias-com-dicas
        [HttpGet("categorias-com-dicas")]
        public async Task<IActionResult> ListarCategoriasComDicas()
        {
            var categoriasComDicas = await _categoriaRepository.ListarCategoriasComContagemDicasAsync();
            return Ok(categoriasComDicas.Select(c => new
            {
                Categoria = c.Categoria,
                ContagemDicas = c.ContagemDicas
            }));
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            // Verifica se a categoria já existe
            var existe = await _categoriaRepository.ExisteCategoriaAsync(categoria.Nome);
            if (existe)
                return BadRequest("Uma categoria com este nome já existe.");

            await _categoriaRepository.CreateAsync(categoria);
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        // PUT: api/Categoria/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Categoria categoriaAtualizada)
        {
            var categoriaExistente = await _categoriaRepository.GetByIdAsync(id);
            if (categoriaExistente is null)
                return NotFound("Categoria não encontrada.");

            // Verifica se o nome da categoria está sendo atualizado para um já existente
            if (categoriaAtualizada.Nome != categoriaExistente.Nome)
            {
                var existe = await _categoriaRepository.ExisteCategoriaAsync(categoriaAtualizada.Nome);
                if (existe)
                    return BadRequest("Uma categoria com este nome já existe.");
            }

            categoriaAtualizada.Id = id; // Garante que o ID não será alterado
            await _categoriaRepository.UpdateAsync(id, categoriaAtualizada);
            return NoContent();
        }

        // DELETE: api/Categoria/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var categoriaExistente = await _categoriaRepository.GetByIdAsync(id);
            if (categoriaExistente is null)
                return NotFound("Categoria não encontrada.");

            await _categoriaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
