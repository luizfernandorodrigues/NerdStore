using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalogo.Application.Servicos;
using NerdStore.Catalogo.Data;
using NerdStore.Catalogo.Data.Repositorio;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Eventos;
using NerdStore.Core.Bus;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Data;
using NerdStore.Vendas.Data.Repository;
using NerdStore.Vendas.Domain;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class InjecaoDependencia
    {
        public static void RegistrarServicos(this IServiceCollection servicos)
        {
            servicos.AddScoped<IMediatrHandler, MediatrHandler>();
            servicos.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            servicos.AddScoped<IPedidoRepositorio, PedidoRepository>();
            servicos.AddScoped<IProdutoServicoAplicacao, ProdutoServicoAplicacao>();
            servicos.AddScoped<IEstoqueServico, EstoqueServico>();
            servicos.AddScoped<CatalogoContexto>();
            servicos.AddScoped<VendasContext>();
            servicos.AddScoped<INotificationHandler<EventoProdutoAbaixoEstoque>, EventoProdutoHandler>();
            servicos.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
        }
    }
}
