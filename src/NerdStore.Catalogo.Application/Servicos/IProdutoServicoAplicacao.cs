using NerdStore.Catalogo.Application.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Servicos
{
    public interface IProdutoServicoAplicacao : IDisposable
    {
        Task<IEnumerable<ProdutoDto>> ObterPorCategoria(int codigo);
        Task<ProdutoDto> ObterPorID(Guid id);
        Task<IEnumerable<ProdutoDto>> ObterTodos();
        Task<IEnumerable<CategoriaDto>> ObterCategorias();
        Task AdicionarProduto(ProdutoDto produtoDto);
        Task AtualizarProduto(ProdutoDto produtoDto);
        Task<ProdutoDto> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDto> ReporEstoque(Guid id, int quantidade);
    }
}
