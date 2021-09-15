using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContexto : DbContext, IUnitOfWork
    {
        public CatalogoContexto(DbContextOptions<CatalogoContexto> opcoes) : base(opcoes) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var propriedade in modelBuilder.Model.GetEntityTypes().SelectMany(entidade => entidade.GetProperties().Where(p => p.ClrType == typeof(string))))
                propriedade.SetColumnType("VARCHAR(200)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContexto).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entidade in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entidade.State == EntityState.Added)
                    entidade.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entidade.State == EntityState.Modified)
                    entidade.Property("DataCadastro").IsModified = false;
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
