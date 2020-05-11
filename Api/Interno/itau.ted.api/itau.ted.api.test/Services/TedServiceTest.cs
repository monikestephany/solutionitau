using FluentValidation;
using FluentValidation.Results;
using itau.ted.api.core.Contracts.Repositories;
using itau.ted.api.core.Entities;
using itau.ted.api.core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static itau.ted.api.core.Entities.Enum.TedEnum;

namespace itau.ted.api.test.Services
{
    public class TedServiceTest
    {
        private readonly TedService tedService;
        private Ted ted1;
        public TedServiceTest()
        {
            ted1 = new Ted
            {
                Id = "1",
                Data = DateTime.Now,
                Valor = 200,
                Meio = MeioTranferencia.Internet,
                Destinatario = new Destinatario 
                {
                    Agencia = "0085",
                    Banco = "341",
                    Conta = "421512",
                    CPF = "73682426051",
                    Nome = "Monike"
                },
                Remetente = new Remetente
                {
                    Agencia = "0652",
                    Banco = "237",
                    Conta = "0065232",
                    CPF = "12873385006",
                    Nome = "Rodrigo"
                }
            };

            var mockRepository = new Mock<ITedRepository>();
            mockRepository.Setup(p => p.Get()).Returns(new List<Ted> { ted1 });
            mockRepository.Setup(p => p.Create(ted1)).Returns(ted1);
            mockRepository.Setup(p => p.Remove(ted1));
            var mockValitor = new Mock<IValidator<Ted>>();
            mockValitor.Setup(x => x.Validate(It.IsAny<Ted>()))
            .Returns(new ValidationResult());
            tedService = new TedService(mockRepository.Object, mockValitor.Object);
        }
        [Fact]
        public void CreateTest()
        {
            var result = tedService.Create(ted1);
            Assert.Equal(result.Destinatario.CPF, ted1.Destinatario.CPF);
        }
        [Fact]
        public void DeleteTest()
        {
            try
            {
                tedService.Delete("1");
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
        [Fact]
        public void GetAllTest()
        {
            var result = tedService.GetAll();
            Assert.NotEmpty(result);
        }
    }
}
