using ListagemDeFornecedores.API.Models;
using Microsoft.EntityFrameworkCore;



namespace ListagemDeFornecedores.API.Data
{
     public class FornecedoresContext : DbContext
      {

        public FornecedoresContext(DbContextOptions<FornecedoresContext> options) : base (options) { }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      

             modelBuilder.Entity<Empresa>()
               .Property(e => e.EmpresaId)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Empresa>()
                .HasOne(e => e.fornecedorPJ)
                .WithOne(pj => pj.EmpresaFornecedor)
                .HasForeignKey<FornecedorPJ>(pj => pj.EmpresaFornecedorId);
                //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Fornecedor>()            
                .HasOne(f => f.Empresa)
                .WithMany(e => e.Fornecedores);
                //.HasForeignKey(f => f.EmpresaId);

            modelBuilder.Entity<Fornecedor>()
                .HasDiscriminator<string>("Tipo")  
                .HasValue<FornecedorPJ>("PJ")
                .HasValue<FornecedorPF>("PF");

            modelBuilder.Entity<FornecedorPF>()
               .Property(pf =>pf.DataNascimento)
               .HasColumnType("datetime2");

            // modelBuilder.Entity<FornecedorPJ>()
            //     .HasOne(pj => pj.EmpresaFornecedor)
            //     .WithOne(e => e.fornecedorPJ)
            //     .HasForeignKey<>("Empresa");
            //.OnDelete(DeleteBehavior.Cascade);
                


    }
        
        
    }
}