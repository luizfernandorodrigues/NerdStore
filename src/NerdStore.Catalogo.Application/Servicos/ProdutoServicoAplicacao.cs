using NerdStore.Catalogo.Application.Converter;
using NerdStore.Catalogo.Application.Dto;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.ObjetosDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Servicos
{
    public class ProdutoServicoAplicacao : IProdutoServicoAplicacao
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IEstoqueServico _estoqueServico;

        public ProdutoServicoAplicacao(IProdutoRepositorio produtoRepositorio, IEstoqueServico estoqueServico)
        {
            _produtoRepositorio = produtoRepositorio;
            _estoqueServico = estoqueServico;
        }

        public async Task AdicionarProduto(ProdutoDto produtoDto)
        {
            _produtoRepositorio.Adicionar(produtoDto.Converter());

            await _produtoRepositorio.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoDto produtoDto)
        {
            _produtoRepositorio.Atualizar(produtoDto.Converter());

            await _produtoRepositorio.UnitOfWork.Commit();
        }

        public async Task<ProdutoDto> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueServico.DebitarEstoque(id, quantidade).Result)
                throw new ExcecaoDominio("Falha ao debitar estoque");

            var produto = await _produtoRepositorio.ObterPorId(id);

            return produto.Converter();
        }

        public async Task<IEnumerable<CategoriaDto>> ObterCategorias()
        {
            var categorias = await _produtoRepositorio.ObterCategorias();

            return categorias.ToList().Converter();
        }

        public async Task<IEnumerable<ProdutoDto>> ObterPorCategoria(int codigo)
        {
            var listaProduto = await _produtoRepositorio.ObterPorCategoria(codigo);

            return listaProduto.ToList().Converter();
        }

        public async Task<ProdutoDto> ObterPorId(Guid id)
        {
            var produto = await _produtoRepositorio.ObterPorId(id);

            return produto.Converter();
        }

        public async Task<IEnumerable<ProdutoDto>> ObterTodos()
        {
            var listaProdutos = await _produtoRepositorio.ObterTodos();

            return listaProdutos.ToList().Converter();
        }

        public async Task<ProdutoDto> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueServico.ReporEstoque(id, quantidade).Result)
                throw new ExcecaoDominio("Falha ao repor estoque");

            var produto = await _produtoRepositorio.ObterPorId(id);

            return produto.Converter();
        }

        public void Dispose()
        {
            _produtoRepositorio?.Dispose();
            _estoqueServico?.Dispose();
        }
    }
}
