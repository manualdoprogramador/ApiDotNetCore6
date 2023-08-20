using System;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet7.Test.Domain.Entities
{
    public class ProductTest
    {
        [Fact(DisplayName = "Não deve criar produto sem nome")]
        public void CriaProduto_Product_NaoCriarProdutoSemNome()
        {
            var ex = Assert.Throws<DomainValidationException>(() => new Product(null, "16876", 10));
            Assert.Equal("Nome deve ser informado!", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar produto sem codErp")]
        public void CriaProduto_Product_NaoCriarProdutoSemCodErp()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                new Product("Teste", "", 10));

            Assert.Equal("Codigo Erp deve ser informado!", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar produto id")]
        public void CriarProduto_Product_NaoCriarProdutoSemID()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                new Product(0, "Teste", "1234", 10));

            Assert.Equal("Id deve ser informado!", ex.Message);
        }

        [Fact(DisplayName = "Criar produto sem id")]
        public void CriarProduct_Product_CriarProductSemID()
        {
            var product = new Product("teste", "1234", 10);
            Assert.NotNull(product);
        }

        [Fact(DisplayName = "Criar produto com id")]
        public void CriarProduct_Product_CriarProductComID()
        {
            var product = new Product(2, "Test", "1234", 10);
            Assert.NotNull(product);
        }
    }
}

