using Ecommerce.ProductService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.ProductService.Infrastructure.DatabaseContext;

public class PersonDbContext(DbContextOptions<PersonDbContext> dbContext) : DbContext(dbContext)
{
    public DbSet<Product> Products { get; set; }
}
