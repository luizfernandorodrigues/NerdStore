using NerdStore.Core.ObjetosDominio;
using System;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceprions()
        {
            var ex = Assert.Throws<ExcecaoDominio>(() => new Produto(string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));
            Assert.Equal("O Campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<ExcecaoDominio>(()=> new Produto("Nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));
            Assert.Equal("O Campo Descrição do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<ExcecaoDominio>(() => new Produto("Nome", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));
            Assert.Equal("O Campo Valor do produto não pode ser menor ou igual a zero", ex.Message);

            ex = Assert.Throws<ExcecaoDominio>(() => new Produto("Nome", "Descricao", false, 100, Guid.Empty, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));
            Assert.Equal("O Campo CategoriaId do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<ExcecaoDominio>(() => new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(1, 1, 1)));
            Assert.Equal("O Campo Imagem do produto não pode estar vazio", ex.Message);
        }
    }
}
