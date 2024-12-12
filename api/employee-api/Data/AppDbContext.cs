using Microsoft.EntityFrameworkCore;
using EmployeeApi.Entities;

namespace EmployeeApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<JobTitle>().ToTable("job_titles");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.EmailAddress).HasColumnName("email_address");
                entity.Property(e => e.Salary).HasColumnName("salary");
                entity.Property(e => e.JobTitleId).HasColumnName("job_title_id");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.Property(j => j.Id).HasColumnName("id");
                entity.Property(j => j.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobTitle)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobTitleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
