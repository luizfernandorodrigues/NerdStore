using System;

namespace NerdStore.Core.ObjetosDominio
{
    public class ExcecaoDominio : Exception
    {
        public ExcecaoDominio()
        {

        }

        public ExcecaoDominio(string mensagem) : base(mensagem) { }

        public ExcecaoDominio (string mensagem, Exception innerException): base(mensagem, innerException) { }
    }
}
