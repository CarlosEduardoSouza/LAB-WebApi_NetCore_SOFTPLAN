using NUnit.Framework;
using Softplayer.API.Controllers;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net.Http;
using Newtonsoft.Json;
using Moq.Contrib.HttpClient;

namespace Softplayer.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TaxaJurosTemDeSerZeroPontoZeroUm()
        {
            //Arrange
            var controller = new Api1Controller();
            var resultadoExperado = (decimal)0.01;

            //Action
            var retorno = controller.Get().Value;

            //Assert
            Assert.AreEqual(resultadoExperado, retorno);
        }

        [Test]
        public void CalculaJurosParametroValorInicialETempoNaoPodemSerNegativoOuZero()
        {
            //Arrange            
            var controller = new Api2Controller();
            
            var valorInicial = -1;
            var tempo = 0;

            //Action
            var response = controller.Get(valorInicial,tempo).Result;

            //Assert
            Assert.IsInstanceOf<BadRequestResult>(response);
        }

        [Test]
        public void CalculaJuros_TestaValores()
        {
            // Arrange
            var controller = new Api2Controller();
            decimal valorInicial = 15;
            int tempo = 5;

            var retornoEsperado = (decimal)798110.76;

            // Act
            var response = controller.Get(valorInicial, tempo);

            // Assert
            Assert.AreEqual(retornoEsperado, response.Value);
        }

        [Test]
        public void RetornaEnderecoGithubDiferenteDeNull()
        {
            //Arrange
            var controller = new Api2Controller();
            var resultadoExperado = "https://github.com/CarlosEduardoSouza/LAB-WebApi_NetCore_SOFTPLAN";

            //Action
            var retorno = controller.Get().Value;

            //Assert
            Assert.AreEqual(resultadoExperado, retorno);
        }
    }
}