using NerdStore.Catalogo.Application.Dto;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.Converter
{
    public static class CategoriaDtoParaCategoriaDominio
    {
        public static Categoria Converter(this CategoriaDto categoriaDto)
        {
            return new Categoria(categoriaDto.Nome, categoriaDto.Codigo);
        }
    }
}
