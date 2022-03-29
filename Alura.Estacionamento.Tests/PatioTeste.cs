using System;
using Xunit;
using Xunit.Abstractions;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Tests
{
    public class PatioTeste: IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConseloTeste;

        public PatioTeste(ITestOutputHelper _saidaConseloTeste)
        {
            saidaConseloTeste = _saidaConseloTeste;
            saidaConseloTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = "Dennie Cannon";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Dennie Cannon","ASD-9999","Preto", "Fusca")]
        [InlineData("José Silva","XSA-4567","Azul", "Xsara")]
        [InlineData("Maria Silva","POI-7454","Cinza", "Pointer")]
        [InlineData("Zé Mario","WEQ-8444","Amarelo", "Camaro")]
        public void ValidaFaturamentoVariosVeiculos(string proprietario,
                                                    string placa,
                                                    string cor,
                                                    string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Dennie Cannon", "ASD-9999", "Branco", "Corolla")]
        public void LocalizaVeiculoNoPatio(string proprietario,
                                                    string placa,
                                                    string cor,
                                                    string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarModeloVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = "Dennie Cannon";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo
            {
                Proprietario = "Dennie Cannon",
                Cor = "Verde",
                Modelo = "Corolla",
                Placa = "asd-9999",
            };

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Modelo, veiculoAlterado.Modelo);
        }

        public void Dispose()
        {
            saidaConseloTeste.WriteLine("Dispose invocado.");
        }
    }
}
