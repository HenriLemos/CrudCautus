using CrudCautus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudCautus.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.IdEndereco);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NumeroEndereco).HasMaxLength(3);
            builder.Property(x => x.Cidade).HasMaxLength(100);
            builder.Property(x => x.Estado).HasMaxLength(2);
        }
    }
}
