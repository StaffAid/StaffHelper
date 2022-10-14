using Microsoft.EntityFrameworkCore;
using StaffHelper.Model.Entities;

namespace StaffHelper.Migrations
{
    public class StaffHelperDbContext: DbContext
    {
        public StaffHelperDbContext(DbContextOptions<StaffHelperDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CompanyRole> CompanyRoles { get; set; }
        public DbSet<CompanyUnit> CompanyUnits { get; set; }
        public DbSet<CompanyDesignation> CompanyDesignations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Company>().ToTable("Companies");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<CompanyRole>().ToTable("CompanyRoles");
            modelBuilder.Entity<CompanyUnit>().ToTable("CompanyUnits");
            modelBuilder.Entity<CompanyDesignation>().ToTable("CompanyDesignations");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<EmploymentHistory>().ToTable("EmploymentHistories");
        }
    }
}
