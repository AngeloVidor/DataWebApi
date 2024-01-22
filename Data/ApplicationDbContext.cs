using Microsoft.EntityFrameworkCore;

namespace WebAPI;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<FuncionarioModel> apiDatabase {get; set;}
}
