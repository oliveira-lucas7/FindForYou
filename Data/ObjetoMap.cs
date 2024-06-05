using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ObjetoMap : IEntityTypeConfiguration<ObjetoModel>
    {
        public void Configure(EntityTypeBuilder<ObjetoModel> builder)
        {
            builder.HasKey(x => x.ObjetoId);
            builder.Property(x => x.ObjetoNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObjetoCor).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObjetoObservacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObjetoLocalDesaparecimento).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObjetoFoto).HasMaxLength(255);
            builder.Property(x => x.ObjetoDtDesaparecimento).IsRequired();
            builder.Property(x => x.ObjetoDtEncontro).HasMaxLength(255);
            builder.Property(x => x.ObjetoStatus).IsRequired();
        }
    }
}
