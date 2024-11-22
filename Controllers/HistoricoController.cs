using Microsoft.AspNetCore.Mvc;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Threading.Tasks;

namespace netgs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoRepository _historicoRepository;

        public HistoricoController(IHistoricoRepository historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        [HttpGet("dica/{dicaId}")]
        public async Task<IActionResult> ObterPorDica(string dicaId)
        {
            var historicos = await _historicoRepository.ObterPorDicaAsync(dicaId);
            return Ok(historicos);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarAcesso(Historico historico)
        {
            await _historicoRepository.CreateAsync(historico);
            return CreatedAtAction(nameof(ObterPorDica), new { dicaId = historico.DicaId }, historico);
        }
    }
}
