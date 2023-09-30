using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Infra.Data.Context;
using MP.ApiDotNet6.Infra.Data.Repositories;
using MP.ApiDotNet7.Test.Application.Context;
using Xunit;

namespace MP.ApiDotNet7.Test.Application.Repositories
{
    public class ProductRepositoryTest
    {
        private ApplicationDbContext _context;

        [Fact(DisplayName = "Deve criar uma Produto")]
        public async Task SalvaProdutoDB_ProductRepository_DeveSalvarUmaProdutoNoBancoDeDados()
        {
            var product = new Product("Produto teste","78676",56m);
            _context = TestDatabaseInMemory.GetDatabase();

            var productRepository = new ProductRepository(_context);
            await productRepository.CreateAsync(product);

            var productResult = _context.Products.FirstOrDefault();
            Assert.Equal(product.Name,productResult.Name);
        }

        [Fact(DisplayName = "Deve listar um produto pelo seu ID")]
        public async Task ListaProduto_ProductRepository_DeveListarUmProdutoPeloSeuId()
        {
            var product = new Product("Produto teste","78676",56m);
            _context = TestDatabaseInMemory.GetDatabase();
            _context.Add(product);
            _context.SaveChanges();    

            var productRepository = new ProductRepository(_context);
            var productResult = await productRepository.GetByIdAsync(product.Id);

            Assert.Equal(product.Name,productResult.Name);
        }

        [Fact(DisplayName = "Deve editar produto")]
        public async Task Edita_ProductRepository_DeveEditarProduto()
        {
            var product = new Product("Produto teste","78676",56m);
            _context = TestDatabaseInMemory.GetDatabase();
            _context.Add(product);
            _context.SaveChanges(); 

            product.Edit("Teste 2", "78676",56m);

            var productRepository = new ProductRepository(_context);
            await productRepository.EditAsync(product);
 
            var productResult = _context.Products.FirstOrDefault();
            Assert.Equal("Teste 2",productResult.Name);
        }

         [Fact(DisplayName = "Deve listar um produto pelo seu ID")]
        public async Task Deletar_ProductRepository_DeveDeletarProduto()
        {
            var product = new Product("Produto teste","78676",56m);
            _context = TestDatabaseInMemory.GetDatabase();
            _context.Add(product);
            _context.SaveChanges();    

            var productRepository = new ProductRepository(_context);
            await productRepository.DeleteAsync(product);

            Assert.Equal(0,_context.Products.Count());
        }
    }
}