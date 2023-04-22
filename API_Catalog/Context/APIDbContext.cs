using API_Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Catalog.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options)
            : base(options) { }

       
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
    }
}
