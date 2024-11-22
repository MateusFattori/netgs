using Microsoft.AspNetCore.Mvc;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Threading.Tasks;

namespace netgs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Avaliar(Avaliacao avaliacao)
        {
            if (avaliacao.Nota < 1 || avaliacao.Nota > 5)
                return BadRequest("A nota deve ser entre 1 e 5.");

            await _avaliacaoRepository.CreateAsync(avaliacao);
            return CreatedAtAction(nameof(ObterMediaPorDica), new { dicaId = avaliacao.DicaId }, avaliacao);
        }

        [HttpGet("dica/{dicaId}/media")]
        public async Task<IActionResult> ObterMediaPorDica(string dicaId)
        {
            var media = await _avaliacaoRepository.ObterMediaPorDicaAsync(dicaId);
            return Ok(new { DicaId = dicaId, Media = media });
        }
    }
}
