using NerdStore.Core.ObjetosDominio;
using System;

namespace NerdStore.Core.Data
{
    public interface IRepositorio<T> : IDisposable where T : IRaizAgregacao
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
