using Microsoft.AspNetCore.Mvc;
using Moq;
using netgs.Controllers;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace netgs.Tests.Controllers
{
    public class AvaliacaoControllerTests
    {
        private readonly Mock<IAvaliacaoRepository> _mockRepo;
        private readonly AvaliacaoController _controller;

        public AvaliacaoControllerTests()
        {
            _mockRepo = new Mock<IAvaliacaoRepository>();
            _controller = new AvaliacaoController(_mockRepo.Object);
        }

        [Fact]
        public async Task Avaliar_DeveAdicionarAvaliacaoERetornarCreated()
        {
            var novaAvaliacao = new Avaliacao { DicaId = "1", Nota = 5, Comentario = "Muito útil" };
            _mockRepo.Setup(repo => repo.CreateAsync(novaAvaliacao)).Returns(Task.CompletedTask);

            var result = await _controller.Avaliar(novaAvaliacao);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var avaliacaoCriada = Assert.IsType<Avaliacao>(createdAtActionResult.Value);
            Assert.Equal(5, avaliacaoCriada.Nota);
        }

        [Fact]
        public async Task ObterMediaPorDica_DeveRetornarMediaDasAvaliacoes()
        {
            var dicaId = "1";
            _mockRepo.Setup(repo => repo.ObterMediaPorDicaAsync(dicaId)).ReturnsAsync(4.5);

            var result = await _controller.ObterMediaPorDica(dicaId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var media = Assert.IsType<double>(okResult.Value);
            Assert.Equal(4.5, media);
        }
    }
}
