using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalogo.Application.Servicos;
using NerdStore.Catalogo.Data;
using NerdStore.Catalogo.Data.Repositorio;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Eventos;
using NerdStore.Core.Bus;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class InjecaoDependencia
    {
        public static void RegistrarServicos(this IServiceCollection servicos)
        {
            servicos.AddScoped<IMediatrHandler, MediatrHandler>();
            servicos.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            servicos.AddScoped<IProdutoServicoAplicacao, ProdutoServicoAplicacao>();
            servicos.AddScoped<IEstoqueServico, EstoqueServico>();
            servicos.AddScoped<CatalogoContexto>();
            servicos.AddScoped<INotificationHandler<EventoProdutoAbaixoEstoque>, EventoProdutoHandler>();
        }
    }
}
