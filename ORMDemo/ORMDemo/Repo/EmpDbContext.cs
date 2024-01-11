namespace Repo;
using Microsoft.EntityFrameworkCore;
using Models;
public class EmpDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public EmpDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("MyDatabase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

    }

    public DbSet<Employee> Employee { get; set; }
}