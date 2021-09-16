using NerdStore.Catalogo.Application.Dto;
using NerdStore.Catalogo.Domain;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Application.Converter
{
    public static class ProdutoDominioParaProdutoDto
    {
        public static ProdutoDto Converter(this Produto produto)
        {
            var produtoDto = new ProdutoDto
            {
                Id = produto.Id,
                CategoriaId = produto.CategoriaId,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Ativo = produto.Ativo,
                Valor = produto.Valor,
                DataCadastro = produto.DataCadastro,
                Imagem = produto.Imagem,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                Altura = produto.Dimensoes.Altura,
                Largura = produto.Dimensoes.Largura,
                Profundidade = produto.Dimensoes.Profundidade,
                CategoriaDto = new CategoriaDto
                {
                    Id = produto.Categoria.Id,
                    Codigo = produto.Categoria.Codigo,
                    Nome = produto.Categoria.Nome
                }
            };

            return produtoDto;
        }

        public static IList<ProdutoDto> Converter(this IList<Produto> listaProdutos)
        {
            if (listaProdutos != null)
            {
                var listaProdutoDto = new List<ProdutoDto>(listaProdutos.Count);

                foreach (var produto in listaProdutos)
                    listaProdutoDto.Add(produto.Converter());

                return listaProdutoDto;
            }

            return null;
        }
    }
}
