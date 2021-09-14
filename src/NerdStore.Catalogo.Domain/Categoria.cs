using NerdStore.Core.ObjetosDominio;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entidade
    {
        #region Propriedades

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        #endregion

        #region Construtor

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        #endregion

        #region Métodos Públicos

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo código da categoria não pode ser zero");
        }

        #endregion
    }
}
