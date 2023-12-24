using Microsoft.EntityFrameworkCore;

namespace SistemaDeVendas.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {      
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    ClienteID = 1,
                    Nome = "Jão",
                    CPF = "111.111.111-11"
                });

            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    ProdutoID = 1,
                    Nome = "Redmi Note 12 Pro",
                    PrecoUnit = 1599.90M
                });

            modelBuilder.Entity<Compra>().HasData(
                new Compra
                {
                    CompraId = 1,
                    DataCompra = new DateTime(2023 - 12 - 22),
                    FormaPagamento = "Crédito",
                    ClienteId = 1,
                    ProdutoId = 1
                });
        }

    }
}
