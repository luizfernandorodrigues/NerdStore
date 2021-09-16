using NerdStore.Core.Mensagens;
using System;

namespace NerdStore.Core.ObjetosDominio
{
    public class EventoDominio : Evento
    {
        public EventoDominio(Guid idAgregado)
        {
            IdAgregado = idAgregado;
        }
    }
}
