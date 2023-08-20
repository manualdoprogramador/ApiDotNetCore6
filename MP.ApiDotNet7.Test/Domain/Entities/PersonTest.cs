using System;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet7.Test.Domain.Entities
{
    public class PersonTest
    {
        [Fact(DisplayName = "Não deve criar pessoa sem documento")]
        public void CriaPessoa_Person_NaoCriarPessoaSemDocumento()
        {
            var ex = Assert.Throws<DomainValidationException>(() => new Person(null, "Test", "999999999"));
            Assert.Equal("Documento deve ser informado!", ex.Message);   
        }

        [Fact(DisplayName = "Não deve criar pessoa sem nome")]
        public void CriaPessoa_Person_NaoCriarPessoaSemNome()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                new Person("67676767676", "", "999999999"));

            Assert.Equal("Nome deve ser informado!", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar pessoa id")]
        public void CriarPessoa_Person_NaoCriarPessoaSemID()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                new Person(0,"67676767676", "Teste", "999999999"));

            Assert.Equal("Id invalido", ex.Message);
        }

        [Fact(DisplayName = "Criar pessoa sem id")]
        public void CriarPessoa_Person_CriarPessoaSemID()
        {
           var person = new Person("67676767676", "Teste", "999999999");
            Assert.NotNull(person);
        }

        [Fact(DisplayName = "Criar pessoa com id")]
        public void CriarPessoa_Person_CriarPessoaComID()
        {
            var person = new Person(2,"67676767676", "Teste", "999999999");
            Assert.NotNull(person);
        }
    }
}

