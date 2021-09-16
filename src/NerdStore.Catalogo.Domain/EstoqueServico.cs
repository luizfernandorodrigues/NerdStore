using NerdStore.Catalogo.Domain.Eventos;
using NerdStore.Core.Bus;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueServico : IEstoqueServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMediatrHandler _bus;

        public EstoqueServico(IProdutoRepositorio produtoRepositorio, IMediatrHandler bus)
        {
            _produtoRepositorio = produtoRepositorio;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepositorio.ObterPorId(produtoId);

            if (produto == null)
                return false;

            if (!produto.PossuiEstoque(quantidade))
                return false;

            produto.DebitarEstoque(quantidade);

            if (produto.QuantidadeEstoque < 10)
                await _bus.PublicarEvento(new EventoProdutoAbaixoEstoque(produto.Id, produto.QuantidadeEstoque));

            _produtoRepositorio.Atualizar(produto);

            return await _produtoRepositorio.UnitOfWork.Commit();
        }
        
        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepositorio.ObterPorId(produtoId);

            if (produto == null)
                return false;

            produto.ReporEstoque(quantidade);

            _produtoRepositorio.Atualizar(produto);

            return await _produtoRepositorio.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepositorio.Dispose();
        }
    }
}
