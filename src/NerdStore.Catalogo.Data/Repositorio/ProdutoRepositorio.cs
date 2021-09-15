using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly CatalogoContexto _catalogoContexto;

        public ProdutoRepositorio(CatalogoContexto catalogoContexto)
        {
            _catalogoContexto = catalogoContexto;
        }

        public IUnitOfWork UnitOfWork => _catalogoContexto;

        public void Adicionar(Produto produto)
        {
            _catalogoContexto.Produtos.Add(produto);
        }

        public void Adicionar(Categoria categoria)
        {
            _catalogoContexto.Categorias.Add(categoria);
        }

        public void Atualizar(Produto produto)
        {
            _catalogoContexto.Produtos.Update(produto);
        }

        public void Atualizar(Categoria categoria)
        {
            _catalogoContexto.Categorias.Update(categoria);
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _catalogoContexto.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            return await _catalogoContexto.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _catalogoContexto.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _catalogoContexto.Produtos.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _catalogoContexto?.Dispose();
        }
    }
}
