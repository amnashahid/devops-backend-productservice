using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Models;
using System.Net.Http.Headers;

namespace ProductMicroservice
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Product>? Products { get; set; }
    }
}
