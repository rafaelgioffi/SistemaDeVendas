using Microsoft.EntityFrameworkCore;

namespace SistemaDeVendas.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Salles> Salles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>().HasData(
                new Clients
                {
                    ClientID = 1,
                    Name = "Maiara Maraísa",
                    CPF = "111.111.111-11"
                },
            new Clients
            {
                ClientID = 2,
                Name = "Jorge Matheus",
                CPF = "111.111.111-12"
            });

            modelBuilder.Entity<Categories>().HasData(
                new Categories
                {
                    CategoryId = 1,
                    Name = "Celulares"
                },
                new Categories
                {
                    CategoryId = 2,
                    Name = "Perfumes"
                });

            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductID = 1,
                    Name = "Redmi Note 12 Pro",
                    UnitPrice = 1599.90M,
                    CategoryId = 1
                },
                new Products
                {
                    ProductID = 2,
                    Name = "Issey Miyake Masculino 100ml",
                    UnitPrice = 159.90M,
                    CategoryId = 2
                });

            modelBuilder.Entity<Salles>().HasData(
                new Salles
                {
                    SalleId = 1,
                    SalleDate = DateTime.Now,
                    PaymentMethod = "Crédito",
                    ClientId = 1,
                    ProductId = 1
                },
                new Salles
                {
                    SalleId = 2,
                    SalleDate = DateTime.Now,
                    PaymentMethod = "PIX",
                    ClientId = 2,
                    ProductId = 2
                });
        }

    }
}
