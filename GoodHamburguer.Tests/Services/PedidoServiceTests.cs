using Xunit;
using Moq;
using FluentAssertions;
using GoodHamburguer.Application.Services;
using GoodHamburguer.Domain.Entidades;
using GoodHamburguer.Domain.Enums;
using GoodHamburguer.Domain.Interfaces;

namespace GoodHamburguer.Tests.Services
{
    public class PedidoServiceTests
    {
        private readonly Mock<IPedidoRepository> _mockRepo;
        private readonly PedidoService _service;

        public PedidoServiceTests()
        {
            _mockRepo = new Mock<IPedidoRepository>();
            _service = new PedidoService(_mockRepo.Object);
        }

        #region Testes de Validação (Regras de Negócio)

        [Fact]
        public async Task CriarPedido_SemSanduiche_DeveLancarExcecao()
        {
            // Arrange - Pedido sem sanduíche
            Sanduiche? sanduiche = null;
            Acompanhamento? acompanhamento = Acompanhamento.BatataFrita;
            Bebida? bebida = Bebida.Refrigerante;

            // Act
            Func<Task> act = () => _service.CriarAsync(sanduiche, acompanhamento, bebida);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("*sanduíche*");
        }

        [Fact]
        public async Task CriarPedido_ComSanduicheInvalido_DeveLancarExcecao()
        {
            // Arrange - Usando um valor de enum inválido
            Sanduiche? sanduiche = (Sanduiche)999;

            // Act
            Func<Task> act = () => _service.CriarAsync(sanduiche, null, null);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("*Sanduíche inválido*");
        }

        [Fact]
        public async Task CriarPedido_ComAcompanhamentoInvalido_DeveLancarExcecao()
        {
            // Arrange
            Sanduiche? sanduiche = Sanduiche.XBurger;
            Acompanhamento? acompanhamento = (Acompanhamento)999;

            // Act
            Func<Task> act = () => _service.CriarAsync(sanduiche, acompanhamento, null);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("*Acompanhamento inválido*");
        }

        [Fact]
        public async Task CriarPedido_ComBebidaInvalida_DeveLancarExcecao()
        {
            // Arrange
            Sanduiche? sanduiche = Sanduiche.XBurger;
            Bebida? bebida = (Bebida)999;

            // Act
            Func<Task> act = () => _service.CriarAsync(sanduiche, null, bebida);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("*Bebida inválida*");
        }

        #endregion

        #region Testes de Cálculo de Descontos

        [Theory]
        [InlineData(Sanduiche.XBurger, Acompanhamento.BatataFrita, Bebida.Refrigerante, 20)]
        [InlineData(Sanduiche.XEgg, Acompanhamento.BatataFrita, Bebida.Refrigerante, 20)]
        [InlineData(Sanduiche.XBacon, Acompanhamento.BatataFrita, Bebida.Refrigerante, 20)]
        public async Task CriarPedido_Completo_DeveAplicar20PorcentoDeDesconto(
            Sanduiche sanduiche, Acompanhamento acompanhamento, Bebida bebida, int percentualEsperado)
        {
            // Arrange
            _mockRepo.Setup(r => r.AdicionarAsync(It.IsAny<Pedido>()))
                     .Returns(Task.CompletedTask);

            // Act
            var pedido = await _service.CriarAsync(sanduiche, acompanhamento, bebida);

            // Assert
            pedido.Desconto.Should().Be(pedido.Subtotal * 0.20m);
            pedido.Total.Should().Be(pedido.Subtotal - pedido.Desconto);
        }

        [Theory]
        [InlineData(Sanduiche.XBurger, Acompanhamento.BatataFrita, null, 10)]
        [InlineData(Sanduiche.XEgg, Acompanhamento.BatataFrita, null, 10)]
        [InlineData(Sanduiche.XBacon, Acompanhamento.BatataFrita, null, 10)]
        public async Task CriarPedido_SanduicheEBatata_DeveAplicar10Porcento(
            Sanduiche sanduiche, Acompanhamento acompanhamento, Bebida? bebida, int percentualEsperado)
        {
            // Arrange
            _mockRepo.Setup(r => r.AdicionarAsync(It.IsAny<Pedido>()))
                     .Returns(Task.CompletedTask);

            // Act
            var pedido = await _service.CriarAsync(sanduiche, acompanhamento, bebida);

            // Assert
            pedido.Desconto.Should().Be(pedido.Subtotal * 0.10m);
            pedido.Total.Should().Be(pedido.Subtotal - pedido.Desconto);
        }

        [Theory]
        [InlineData(Sanduiche.XBurger, null, Bebida.Refrigerante, 15)]
        [InlineData(Sanduiche.XEgg, null, Bebida.Refrigerante, 15)]
        [InlineData(Sanduiche.XBacon, null, Bebida.Refrigerante, 15)]
        public async Task CriarPedido_SanduicheERefrigerante_DeveAplicar15Porcento(
            Sanduiche sanduiche, Acompanhamento? acompanhamento, Bebida bebida, int percentualEsperado)
        {
            // Arrange
            _mockRepo.Setup(r => r.AdicionarAsync(It.IsAny<Pedido>()))
                     .Returns(Task.CompletedTask);

            // Act
            var pedido = await _service.CriarAsync(sanduiche, acompanhamento, bebida);

            // Assert
            pedido.Desconto.Should().Be(pedido.Subtotal * 0.15m);
            pedido.Total.Should().Be(pedido.Subtotal - pedido.Desconto);
        }

        [Theory]
        [InlineData(Sanduiche.XBurger, null, null, 0)]
        [InlineData(Sanduiche.XEgg, null, null, 0)]
        [InlineData(Sanduiche.XBacon, null, null, 0)]
        public async Task CriarPedido_ApenasSanduiche_DescontoDeveSerZero(
            Sanduiche sanduiche, Acompanhamento? acompanhamento, Bebida? bebida, int descontoEsperado)
        {
            // Arrange
            _mockRepo.Setup(r => r.AdicionarAsync(It.IsAny<Pedido>()))
                     .Returns(Task.CompletedTask);

            // Act
            var pedido = await _service.CriarAsync(sanduiche, acompanhamento, bebida);

            // Assert
            pedido.Desconto.Should().Be(0m);
            pedido.Total.Should().Be(pedido.Subtotal);
        }

        #endregion

        #region Testes de Valores Monetários

        [Fact]
        public async Task CriarPedido_XBaconCompleto_DeveCalcularValoresCorretos()
        {
            // Arrange - Conforme cardápio: X-Bacon (7,00) + Batata (2,00) + Refri (2,50)
            _mockRepo.Setup(r => r.AdicionarAsync(It.IsAny<Pedido>()))
                     .Returns(Task.CompletedTask);

            // Act
            var pedido = await _service.CriarAsync(
                Sanduiche.XBacon,
                Acompanhamento.BatataFrita,
                Bebida.Refrigerante);

            // Assert
            pedido.Subtotal.Should().Be(11.50m);  // 7.00 + 2.00 + 2.50
            pedido.Desconto.Should().Be(2.30m);    // 11.50 * 0.20
            pedido.Total.Should().Be(9.20m);       // 11.50 - 2.30
        }

        [Fact]
        public async Task CriarPedido_XBurgerComRefrigerante_DeveCalcularValoresCorretos()
        {
            // Arrange - X-Burger (5,00) + Refrigerante (2,50)
            _mockRepo.Setup(r => r.AdicionarAsync(It.IsAny<Pedido>()))
                     .Returns(Task.CompletedTask);

            // Act
            var pedido = await _service.CriarAsync(
                Sanduiche.XBurger,
                null,
                Bebida.Refrigerante);

            // Assert
            pedido.Subtotal.Should().Be(7.50m);    // 5.00 + 2.50
            pedido.Desconto.Should().Be(1.125m);    // 7.50 * 0.15
            pedido.Total.Should().Be(6.375m);       // 7.50 - 1.125
        }

        #endregion

        #region Testes de CRUD

        [Fact]
        public async Task CriarPedido_Valido_DeveSalvarERetornarPedido()
        {
            // Arrange
            _mockRepo.Setup(r => r.AdicionarAsync(It.IsAny<Pedido>()))
                     .Returns(Task.CompletedTask);

            // Act
            var pedido = await _service.CriarAsync(
                Sanduiche.XBurger,
                Acompanhamento.BatataFrita,
                Bebida.Refrigerante);

            // Assert
            pedido.Should().NotBeNull();
            pedido.Sanduiche.Should().Be(Sanduiche.XBurger);
            _mockRepo.Verify(r => r.AdicionarAsync(It.IsAny<Pedido>()), Times.Once);
        }

        [Fact]
        public async Task AtualizarPedido_Existente_DeveRecalcularDesconto()
        {
            // Arrange
            var pedidoId = Guid.NewGuid();
            var pedidoExistente = new Pedido(Sanduiche.XBurger, null, null);

            _mockRepo.Setup(r => r.ObterPorIdAsync(pedidoId))
                     .ReturnsAsync(pedidoExistente);
            _mockRepo.Setup(r => r.AtualizarAsync(It.IsAny<Pedido>()))
                     .Returns(Task.CompletedTask);

            // Act - Adicionar batata e refrigerante
            await _service.AtualizarAsync(
                pedidoId,
                Sanduiche.XBurger,
                Acompanhamento.BatataFrita,
                Bebida.Refrigerante);

            // Assert
            pedidoExistente.Desconto.Should().BeGreaterThan(0); // Deve ter desconto agora
            _mockRepo.Verify(r => r.AtualizarAsync(It.Is<Pedido>(
                p => p.Desconto > 0)), Times.Once);
        }

        [Fact]
        public async Task AtualizarPedido_Inexistente_DeveLancarExcecao()
        {
            // Arrange
            var idInexistente = Guid.NewGuid();
            _mockRepo.Setup(r => r.ObterPorIdAsync(idInexistente))
                     .ReturnsAsync((Pedido?)null);

            // Act
            Func<Task> act = () => _service.AtualizarAsync(
                idInexistente, Sanduiche.XBurger, null, null);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>()
                .WithMessage($"*{idInexistente}*");
        }

        [Fact]
        public async Task RemoverPedido_Existente_DeveChamarRepositorio()
        {
            // Arrange
            var pedidoId = Guid.NewGuid();
            var pedido = new Pedido(Sanduiche.XBurger, null, null);

            _mockRepo.Setup(r => r.ObterPorIdAsync(pedidoId))
                     .ReturnsAsync(pedido);
            _mockRepo.Setup(r => r.RemoverAsync(pedido))
                     .Returns(Task.CompletedTask);

            // Act
            await _service.RemoverAsync(pedidoId);

            // Assert
            _mockRepo.Verify(r => r.RemoverAsync(pedido), Times.Once);
        }

        [Fact]
        public async Task ObterTodos_DeveRetornarListaDoRepositorio()
        {
            // Arrange
            var pedidosEsperados = new List<Pedido>
            {
                new Pedido(Sanduiche.XBurger, null, null),
                new Pedido(Sanduiche.XBacon, Acompanhamento.BatataFrita, null)
            };
            _mockRepo.Setup(r => r.ObterTodosAsync())
                     .ReturnsAsync(pedidosEsperados);

            // Act
            var resultado = await _service.ObterTodosAsync();

            // Assert
            resultado.Should().BeEquivalentTo(pedidosEsperados);
            resultado.Should().HaveCount(2);
        }

        #endregion
    }
}