using FluentValidation;
using FluentValidation.Results;
using itau.pos.api.core.Contracts.Repositories;
using itau.pos.api.core.Entities;
using itau.pos.api.core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static itau.pos.api.core.Entities.Enum.PosEnum;

namespace itau.pos.api.test.Services
{
    public class PosServiceTest
    {
        private readonly PosService posService;
        private Pos pos1;
        public PosServiceTest()
        {
            pos1 = new Pos
            {
                Id = "1",
                Bandeira = Bandeira.VISA,
                CodigoSeguranca = "630",
                NumeroCartao = "4485489265338195",
                Validade = DateTime.Parse("09/11/2021"),
                CPF = "11659328063",
                Nome = "Monike",
                Transacao = TipoTransacao.Debito,
                TotalVezes = 0,
                Valor = 500,
                ValorLimite = 1500,
                Data = DateTime.Now
            };
          
            var mockRepository = new Mock<IPosRepository>();
            mockRepository.Setup(p => p.Get()).Returns(new List<Pos> { pos1 });
            mockRepository.Setup(p => p.Create(pos1)).Returns(pos1);
            mockRepository.Setup(p => p.Remove(pos1));
            var mockValitor = new Mock<IValidator<Pos>>();
            mockValitor.Setup(x => x.Validate(It.IsAny<Pos>()))
            .Returns(new ValidationResult());
            posService = new PosService(mockRepository.Object, mockValitor.Object);
        }
        [Fact]
        public void CreateTest()
        {
            var result = posService.Create(pos1);
            Assert.Equal(result.CPF, pos1.CPF);
        }
        [Fact]
        public void DeleteTest()
        {
            try
            {
                posService.Delete("1");
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
            var result = posService.GetAll();
            Assert.NotEmpty(result);
        }
    }
}
