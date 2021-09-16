using NerdStore.Catalogo.Application.Dto;
using NerdStore.Catalogo.Domain;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Application.Converter
{
    public static class CategoriaDominioParaCategoriaDto
    {
        public static CategoriaDto Converter(this Categoria categoria)
        {
            return new CategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Codigo = categoria.Codigo
            };
        }

        public static IList<CategoriaDto> Converter(this IList<Categoria> listaCategoria)
        {
            if(listaCategoria != null)
            {
                var listaCategoriaDto = new List<CategoriaDto>(listaCategoria.Count);

                foreach (var categoria in listaCategoria)
                    listaCategoriaDto.Add(categoria.Converter());

                return listaCategoriaDto;
            }

            return null;
        }
    }
}
