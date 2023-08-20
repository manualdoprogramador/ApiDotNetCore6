using System;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet7.Test.Domain.Entities
{
    public class PurchaseTest
    {
        [Fact(DisplayName = "Não deve criar compra sem idProduto")]
        public void CriaCompra_Purchase_NaoCriarCompraSemIdProduto()
        {
            var ex = Assert.Throws<DomainValidationException>(() => new Purchase(0, 2));
            Assert.Equal("Id produto deve ser maior que zero", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar compra id")]    
        public void CriarCompra_Purchase_NaoCriarCompraSemID()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                new Purchase(0, 1,2));

            Assert.Equal("Id deve ser informado!", ex.Message);
        }

        [Fact(DisplayName = "Criar compra sem id")]
        public void CriarCompra_Purchase_CriarCompraSemID()
        {
            var purchase = new Purchase(1, 2);
            Assert.NotNull(purchase);
        }

        [Fact(DisplayName = "Criar compra com id")]
        public void CriarCompra_Purchase_CriarCompraComID()
        {
            var purchase = new Purchase(2,1,2);
            Assert.NotNull(purchase);
        }

        [Fact(DisplayName = "Deve edita compra")]
        public void EditarCompra_Editar_EditarCompra()
        {
            var purchase = new Purchase(1, 2);
            purchase.Edit(1, 1, 2);
            Assert.Equal(1,purchase.Id);
        }
    }
}

