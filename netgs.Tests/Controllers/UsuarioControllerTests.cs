using Microsoft.AspNetCore.Mvc;
using Moq;
using netgs.Controllers;
using netgs.Models;
using netgs.Repository.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace netgs.Tests.Controllers
{
    public class UsuarioControllerTests
    {
        private readonly Mock<IUsuarioRepository> _mockRepo;
        private readonly UsuarioController _controller;

        public UsuarioControllerTests()
        {
            _mockRepo = new Mock<IUsuarioRepository>();
            _controller = new UsuarioController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetById_DeveRetornarUsuario_QuandoEncontrado()
        {
            var usuarioId = "1";
            var usuarioMock = new Usuario { Id = usuarioId, Nome = "João" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(usuarioId)).ReturnsAsync(usuarioMock);

            var result = await _controller.GetById(usuarioId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var usuario = Assert.IsType<Usuario>(okResult.Value);
            Assert.Equal(usuarioId, usuario.Id);
        }

        [Fact]
        public async Task Create_DeveAdicionarUsuarioERetornarCreated()
        {
            var novoUsuario = new Usuario { Nome = "Maria", Email = "maria@email.com" };
            _mockRepo.Setup(repo => repo.CreateAsync(novoUsuario)).Returns(Task.CompletedTask);

            var result = await _controller.Create(novoUsuario);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var usuarioCriado = Assert.IsType<Usuario>(createdAtActionResult.Value);
            Assert.Equal("Maria", usuarioCriado.Nome);
        }
    }
}
