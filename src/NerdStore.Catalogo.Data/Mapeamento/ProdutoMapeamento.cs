using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mapeamento
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("Nome")
                .IsRequired(true);

            builder.Property(p => p.Imagem)
                .HasColumnType("VARCHAR(250)")
                .HasColumnName("Imagem")
                .IsRequired(true);

            builder.Property(p => p.Descricao)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("Descricao")
                .IsRequired(true);

            builder.Property(p => p.Valor)
                .HasColumnName("Valor")
                .HasColumnType("DECIMAL(19,5)")
                .HasDefaultValue(0)
                .IsRequired(true);

            builder.Property(p => p.Ativo)
                .HasColumnType("BIT")
                .HasColumnName("Ativo")
                .IsRequired(true);

            builder.OwnsOne(p => p.Dimensoes, dimensao =>
              {
                  dimensao.Property(d => d.Altura)
                  .HasColumnType("INT")
                  .HasColumnName("Altura");

                  dimensao.Property(d => d.Largura)
                  .HasColumnType("INT")
                  .HasColumnName("Largura");

                  dimensao.Property(d => d.Profundidade)
                  .HasColumnType("INT")
                  .HasColumnName("Profundidade");
              });
        }
    }
}
