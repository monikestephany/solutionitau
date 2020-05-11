using FluentValidation;
using FluentValidation.Results;
using itau.conta.api.core.Contracts.Repositories;
using itau.conta.api.core.Entities;
using itau.conta.api.core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace itau.conta.api.test.Services
{
    public class ContaServiceTest
    {
        private readonly ContaService contaService;
        private Conta conta1;
        public ContaServiceTest()
        {
            conta1 = new Conta
            {
                Id = "1",
                CPF = "39124368865",
                DataNascimento = DateTime.Parse("1996-05-21"),
                Email = "monikestephany@gmail.com",
                Nome = "Monike Stephany Santana"
            };
            conta1.UpdateSenha(123456);
            var mockRepository = new Mock<IContaRepository>();
            mockRepository.Setup(p => p.Get()).Returns(new List<Conta> { conta1 });
            mockRepository.Setup(p => p.GetId("1")).Returns(conta1);
            mockRepository.Setup(p => p.Create(conta1)).Returns(conta1);
            mockRepository.Setup(p => p.Update("1", conta1)).Returns(conta1);
            mockRepository.Setup(p => p.Remove(conta1));
            var mockValitor = new Mock<IValidator<Conta>>();
            mockValitor.Setup(x => x.Validate(It.IsAny<Conta>()))
            .Returns(new ValidationResult());
            contaService = new ContaService(mockRepository.Object, mockValitor.Object);
        }
        [Fact]
        public void CreateTest()
        {
            var result = contaService.Create(conta1);
            Assert.Equal(result.CPF, conta1.CPF);
        }
        [Fact]
        public void DeleteTest()
        {
            try
            {
                contaService.Delete("1");
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
            var result = contaService.GetAll();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void UpdateTest()
        {
            var result = contaService.Update("1", conta1);
            Assert.NotNull(result);
        }
        [Fact]
        public void UpdateSenhaTest()
        {
            var result = contaService.UpdateSenha("1", 123456);
            Assert.Equal(result.Senha, conta1.Senha);
        }
    }
}
