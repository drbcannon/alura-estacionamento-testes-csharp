﻿using Xunit;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Tests
{
    public class PatioTeste
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = "Dennie Cannon",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Modelo = "Fusca",
                Placa = "asd-9999",
            };

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
            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Cor = cor,
                Modelo = modelo,
                Placa = placa,
            };

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
            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Cor = cor,
                Modelo = modelo,
                Placa = placa,
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = "Dennie Cannon",
                Cor = "Verde",
                Modelo = "Fusca",
                Placa = "asd-9999",
            };
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
    }
}
