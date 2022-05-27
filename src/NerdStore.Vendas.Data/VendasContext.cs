using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Core.Mensagens;
using NerdStore.Vendas.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Data
{
    public class VendasContext : DbContext, IUnitOfWork
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        public VendasContext(DbContextOptions<VendasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var propriedade in modelBuilder.Model.GetEntityTypes().SelectMany(entidade => entidade.GetProperties().Where(p => p.ClrType == typeof(string))))
                propriedade.SetColumnType("VARCHAR(200)");

            modelBuilder.Ignore<Evento>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendasContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.HasSequence<long>("MinhaSequencia").StartsAt(1000).IncrementsBy(1);
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
