using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Eventos
{
    public class EventoProdutoHandler : INotificationHandler<EventoProdutoAbaixoEstoque>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public EventoProdutoHandler(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task Handle(EventoProdutoAbaixoEstoque mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepositorio.ObterPorId(mensagem.IdAgregado);

            // Enviar um email para aquisição de mais produtos.

        }
    }
}
