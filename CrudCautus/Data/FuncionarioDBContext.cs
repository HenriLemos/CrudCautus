using CrudCautus.Data.Map;
using CrudCautus.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudCautus.Data
{
    public class FuncionarioDBContext : DbContext
    {
        public FuncionarioDBContext(DbContextOptions<FuncionarioDBContext> options)
            : base(options)
        {   
        }

        public DbSet<Fornecedor> Tb_Fornecedor { get; set;}
        public DbSet<Endereco> Tb_Endereco { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
