using System;
using Xunit;
using Xunit.Abstractions;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTeste: IDisposable
    {

        private Veiculo veiculo;
        public ITestOutputHelper saidaConseloTeste; 

        public VeiculoTeste(ITestOutputHelper _saidaConseloTeste)
        {
            saidaConseloTeste = _saidaConseloTeste;
            saidaConseloTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]
        [Trait("Funcionalidade","Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculoMotocicleta()
        {
            //Arrange
            //Act
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Motocicleta;
            //Assert
            Assert.Equal(Alura.Estacionamento.Modelos.TipoVeiculo.Motocicleta, veiculo.Tipo);
        }

        [Fact]
        public void TestaTipoVeiculoSemAtribuirTipo()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal(Alura.Estacionamento.Modelos.TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaTipoVeiculoAutomovel()
        {
            //Arrange
            //Act
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            //Assert
            Assert.Equal(Alura.Estacionamento.Modelos.TipoVeiculo.Automovel, veiculo.Tipo);
        }
        
        [Fact(Skip ="Ainda não implementado", DisplayName ="Teste ignorado")]
        public void ValidaNomeProprietario()
        {
            
        }

        [Fact]
        public void ValidarDadosDoVeiculo()
        {
            //Arrange
            veiculo.Proprietario = "Dennie Cannon";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            string nomeProprietario = "Ab";

            Assert.Throws<System.FormatException>(
                () => new Veiculo(nomeProprietario)
            );
        }

        [Theory]
        [InlineData("ABC1234", "A placa deve possuir 8 caracteres")]
        [InlineData("ABC12340", "O 4° caractere deve ser um hífen")]
        [InlineData("A2C-2340", "Os 3 primeiros caracteres devem ser letras!")]
        [InlineData("ABC-1C34", "Do 5º ao 8º caractere deve-se ter um número!")]
        public void TestarExcecoesDePlaca(string placa, string mensagem)
        {
            var msgRetorno = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            Assert.Equal(msgRetorno.Message, mensagem);
        }

        public void Dispose()
    {
        saidaConseloTeste.WriteLine("Dispose invocado.");
    }
}
}
