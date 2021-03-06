using MediatR;
using NerdStore.Core.Mensagens;
using NerdStore.Vendas.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Commands
{
    public class PedidoCommandHandler : IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoCommandHandler(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message))
                return false;

            var pedido = await _pedidoRepositorio.ObterPedidoRascunhoPorClienteId(message.ClienteId);
            var pedidoItem = new PedidoItem(message.ProdutoId, message.Nome, message.Quantidade, message.ValorUnitario);

            if (pedido == null)
            {
                pedido = Pedido.PedidoFactory.NovoPedidoRascunho(message.ClienteId);
                pedido.AdicionarItem(pedidoItem);

                _pedidoRepositorio.Adicionar(pedido);
            }
            else
            {
                var pedidoExistente = pedido.PedidoItemExistente(pedidoItem);
                pedido.AdicionarItem(pedidoItem);

                if (pedidoExistente)
                    _pedidoRepositorio.AtualizarItem(pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId));
                else
                    _pedidoRepositorio.AdicionarItem(pedidoItem);
            }

            return await _pedidoRepositorio.UnitOfWork.Commit();
        }

        private bool ValidarComando(Comando message)
        {
            if (message.EhValido())
                return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                // lanmçar evento de erro
            }


            return false;
        }
    }
}
