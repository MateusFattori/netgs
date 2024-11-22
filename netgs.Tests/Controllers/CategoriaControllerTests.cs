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
    public class CategoriaControllerTests
    {
        private readonly Mock<ICategoriaRepository> _mockRepo;
        private readonly CategoriaController _controller;

        public CategoriaControllerTests()
        {
            _mockRepo = new Mock<ICategoriaRepository>();
            _controller = new CategoriaController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarListaDeCategorias()
        {
            var categoriasMock = new List<Categoria> { new Categoria { Nome = "Residencial" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categoriasMock);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var categorias = Assert.IsType<List<Categoria>>(okResult.Value);
            Assert.Single(categorias);
        }

        [Fact]
        public async Task GetById_DeveRetornarCategoria_QuandoEncontrada()
        {
            var categoriaId = "1";
            var categoriaMock = new Categoria { Id = categoriaId, Nome = "Comercial" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(categoriaId)).ReturnsAsync(categoriaMock);

            var result = await _controller.GetById(categoriaId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var categoria = Assert.IsType<Categoria>(okResult.Value);
            Assert.Equal(categoriaId, categoria.Id);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoNaoEncontrada()
        {
            var categoriaId = "1";
            _mockRepo.Setup(repo => repo.GetByIdAsync(categoriaId)).ReturnsAsync((Categoria?)null);

            var result = await _controller.GetById(categoriaId);

            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
