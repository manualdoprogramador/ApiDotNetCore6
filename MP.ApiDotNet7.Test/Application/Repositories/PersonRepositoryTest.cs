using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Validations;
using MP.ApiDotNet6.Infra.Data.Context;
using MP.ApiDotNet6.Infra.Data.Repositories;
using MP.ApiDotNet7.Test.Application.Context;

namespace MP.ApiDotNet7.Test.Application.Repositories
{
    public class PersonRepositoryTesty
    {

        private ApplicationDbContext _context;

        [Fact(DisplayName = "Deve criar uma pessoa")]
        public async Task SalvaPessoaDB_PersonRepository_DeveSalvarUmaPessoaNoBancoDeDados()
        {
            var person = new Person("7677676767","Pessoa Teste unidade","9585983");
            _context = TestDatabaseInMemory.GetDatabase();

            var personRepository = new PersonRepository(_context);
            await personRepository.CreateAsync(person);

            var personResult = _context.People.FirstOrDefault();
            Assert.Equal(person.Document,personResult.Document);
            
        }

        [Fact(DisplayName = "Deve deletar uma pessoa")]
        public async Task DeletaPessoaDB_PersonRepository_DeveDeletarUmaPessoaNoBancoDeDados()
        {
            var person = new Person("7677676767","Pessoa Teste unidade","9585983");
            _context = TestDatabaseInMemory.GetDatabase();
            _context.People.Add(person);
            _context.SaveChanges();

            var personRepository = new PersonRepository(_context);
            await personRepository.DeleteAsync(person);

            var personResult = _context.People.FirstOrDefault();
            Assert.Null(personResult);
            
        }

        [Fact(DisplayName = "Deve retornar pessoa pelo seu ID")]
        public async Task ListaPessoa_PersonRepository_DeveRetornarPessoaPeloSeuId()
        {
            var person = new Person("7677676767","Pessoa Teste unidade","9585983");
            _context = TestDatabaseInMemory.GetDatabase();
            _context.People.Add(person);
            _context.SaveChanges();

            var personRepository = new PersonRepository(_context);
            var personResult = await personRepository.GetByIdAsync(1);
            Assert.Equal(person.Document,personResult.Document);
            
        }

        [Fact(DisplayName = "Deve retornar pessoa pelo seu Documento")]
        public async Task ListaPessoa_PersonRepository_DeveRetornarPessoaPeloSeuDocumento()
        {
            var person = new Person("7677676767","Pessoa Teste unidade","9585983");
            _context = TestDatabaseInMemory.GetDatabase();
            _context.People.Add(person);
            _context.SaveChanges();

            var personRepository = new PersonRepository(_context);
            var personId = await personRepository.GetIdByDocumentAsync(person.Document);
            Assert.Equal(1,personId);
            
        }

    }
}