using NerdStore.Catalogo.Application.Dto;
using NerdStore.Catalogo.Domain;
using System;

namespace NerdStore.Catalogo.Application.Converter
{
    public static class ProdutoDtoParaProdutoDominio
    {
        public static Produto Converter(this ProdutoDto produtoDto)
        {
            var produto = new Produto(
                produtoDto.Nome,
                produtoDto.Descricao,
                produtoDto.Ativo,
                produtoDto.Valor,
                produtoDto.CategoriaId,
                produtoDto.DataCadastro,
                produtoDto.Imagem,
                new Dimensoes(
                    produtoDto.Altura,
                    produtoDto.Largura,
                    produtoDto.Profundidade)
                );

            if (produtoDto.Id != Guid.Empty)
                produto.Id = produtoDto.Id;

            return produto;
        }
    }
}
