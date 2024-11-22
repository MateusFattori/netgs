using Microsoft.AspNetCore.Mvc;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Threading.Tasks;

namespace netgs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstatisticaController : ControllerBase
    {
        private readonly IEstatisticaRepository _estatisticaRepository;

        public EstatisticaController(IEstatisticaRepository estatisticaRepository)
        {
            _estatisticaRepository = estatisticaRepository;
        }

        [HttpGet("geral")]
        public async Task<IActionResult> ObterEstatisticasGerais()
        {
            var estatisticas = await _estatisticaRepository.ObterEstatisticasGeraisAsync();
            return Ok(estatisticas);
        }
    }
}
