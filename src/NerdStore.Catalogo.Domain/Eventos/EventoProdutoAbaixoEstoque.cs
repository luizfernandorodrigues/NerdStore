using NerdStore.Core.ObjetosDominio;
using System;

namespace NerdStore.Catalogo.Domain.Eventos
{
    public class EventoProdutoAbaixoEstoque : EventoDominio
    {
        public int QuantidadeRestante { get; private set; }

        public EventoProdutoAbaixoEstoque(Guid idAgregado, int quantidadeRestante) : base(idAgregado)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
