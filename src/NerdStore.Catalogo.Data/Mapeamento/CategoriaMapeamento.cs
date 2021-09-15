using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mapeamento
{
    public class CategoriaMapeamento : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("Nome")
                .IsRequired(true);

            builder.Property(p => p.Codigo)
                .HasColumnType("INT")
                .HasColumnName("Codigo")
                .IsRequired(true);

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId)
                .HasConstraintName("FK_Produto_CategoriaId");
        }
    }
}
