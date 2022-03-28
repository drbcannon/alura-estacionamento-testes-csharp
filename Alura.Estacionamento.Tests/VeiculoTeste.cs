using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTeste
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculoMotocicleta()
        {
            //Arrange
            var veiculo = new Veiculo
            {
                //Act
                Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Motocicleta
            };
            //Assert
            Assert.Equal(Alura.Estacionamento.Modelos.TipoVeiculo.Motocicleta, veiculo.Tipo);
        }

        [Fact]
        public void TestaTipoVeiculoNulo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal(Alura.Estacionamento.Modelos.TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaTipoVeiculoAutomovel()
        {
            //Arrange
            var veiculo = new Veiculo
            {
                //Act
                Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel
            };
            //Assert
            Assert.Equal(Alura.Estacionamento.Modelos.TipoVeiculo.Automovel, veiculo.Tipo);
        }
    }
}
