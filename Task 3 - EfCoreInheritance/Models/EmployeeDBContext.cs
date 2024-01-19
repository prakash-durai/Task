using Microsoft.EntityFrameworkCore;
namespace EfCoreInheritance
{
    public class EmployeeDbContext : DbContext{
    public DbSet<EmployeeModel> Employees { get; set; }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeModel>().HasKey(e => e.EmployeeId);
        modelBuilder.Entity<Manager>().HasBaseType<EmployeeModel>();
        modelBuilder.Entity<RegularEmployee>().HasBaseType<EmployeeModel>();
    }
}
}