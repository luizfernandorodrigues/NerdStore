using NerdStore.Core.Mensagens;
using System.Threading.Tasks;

namespace NerdStore.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Evento;
        Task<bool> EnviarComando<T>(T comando) where T : Comando;
    }
}
