using MediatR;
using System;

namespace NerdStore.Core.Mensagens
{
    public abstract class Evento: Mensagem, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Evento()
        {
            Timestamp = DateTime.Now;
        }
    }
}
