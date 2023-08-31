using CrudCautus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudCautus.Data.Map
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.IdFornecedor);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(130);
        }
    }
}
