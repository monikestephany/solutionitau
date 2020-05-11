using FluentValidation;
using FluentValidation.Results;
using itau.doc.api.core.Contracts.Repositories;
using itau.doc.api.core.Entities;
using itau.doc.api.core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static itau.doc.api.core.Entities.Enum.DocEnum;

namespace itau.doc.api.test.Services
{
    public class DocServiceTest
    {
        private readonly DocService docService;
        private Doc doc1;
        public DocServiceTest()
        {
            doc1 = new Doc
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

            var mockRepository = new Mock<IDocRepository>();
            mockRepository.Setup(p => p.Get()).Returns(new List<Doc> { doc1 });
            mockRepository.Setup(p => p.Create(doc1)).Returns(doc1);
            mockRepository.Setup(p => p.Remove(doc1));
            var mockValitor = new Mock<IValidator<Doc>>();
            mockValitor.Setup(x => x.Validate(It.IsAny<Doc>()))
            .Returns(new ValidationResult());
            docService = new DocService(mockRepository.Object, mockValitor.Object);
        }
        [Fact]
        public void CreateTest()
        {
            var result = docService.Create(doc1);
            Assert.Equal(result.Destinatario.CPF, doc1.Destinatario.CPF);
        }
        [Fact]
        public void DeleteTest()
        {
            try
            {
                docService.Delete("1");
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
            var result = docService.GetAll();
            Assert.NotEmpty(result);
        }
    }
}
