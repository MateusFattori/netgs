using Microsoft.AspNetCore.Mvc;
using Moq;
using netgs.Controllers;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace netgs.Tests.Controllers
{
    public class DicaControllerTests
    {
        private readonly Mock<IDicaRepository> _mockRepo;
        private readonly DicaController _controller;

        public DicaControllerTests()
        {
            _mockRepo = new Mock<IDicaRepository>();
            _controller = new DicaController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarListaDeDicas()
        {
            var dicasMock = new List<Dica> { new Dica { Titulo = "Dica 1" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(dicasMock);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var dicas = Assert.IsType<List<Dica>>(okResult.Value);
            Assert.Single(dicas);
        }

        [Fact]
        public async Task GetById_DeveRetornarDica_QuandoEncontrada()
        {
            var dicaId = "1";
            var dicaMock = new Dica { Id = dicaId, Titulo = "Dica 1" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(dicaId)).ReturnsAsync(dicaMock);

            var result = await _controller.GetById(dicaId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var dica = Assert.IsType<Dica>(okResult.Value);
            Assert.Equal(dicaId, dica.Id);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoNaoEncontrada()
        {
            var dicaId = "1";
            _mockRepo.Setup(repo => repo.GetByIdAsync(dicaId)).ReturnsAsync((Dica?)null);

            var result = await _controller.GetById(dicaId);

            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
