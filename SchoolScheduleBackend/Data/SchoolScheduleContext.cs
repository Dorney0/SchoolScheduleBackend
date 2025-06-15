using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Models;

namespace SchoolScheduleBackend.Data
{
    public class SchoolScheduleContext : DbContext
    {
        public SchoolScheduleContext(DbContextOptions<SchoolScheduleContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<SubjectEmployee> SubjectEmployees { get; set; }
        public DbSet<SubjectCabinet> SubjectCabinets { get; set; }
        public DbSet<Curriculum> Curricula { get; set; }
        public DbSet<ChangeLog> ChangeLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Class>().ToTable("classes");
            modelBuilder.Entity<Subject>().ToTable("subjects");
            modelBuilder.Entity<Cabinet>().ToTable("cabinets");
            modelBuilder.Entity<Schedule>().ToTable("schedules");
            modelBuilder.Entity<Preference>().ToTable("preferences");
            modelBuilder.Entity<SubjectEmployee>().ToTable("subjectemployees");
            modelBuilder.Entity<SubjectCabinet>().ToTable("subjectcabinets");
            modelBuilder.Entity<Curriculum>().ToTable("curricula");
            modelBuilder.Entity<ChangeLog>().ToTable("changelogs");

            // Composite keys
            modelBuilder.Entity<SubjectEmployee>()
                .HasKey(se => new { se.SubjectId, se.EmployeeId });

            modelBuilder.Entity<SubjectCabinet>()
                .HasKey(sc => new { sc.SubjectId, sc.CabinetId });

            // Relationships
            modelBuilder.Entity<SubjectEmployee>()
                .HasOne(se => se.Subject)
                .WithMany(s => s.SubjectEmployees)
                .HasForeignKey(se => se.SubjectId);

            modelBuilder.Entity<SubjectEmployee>()
                .HasOne(se => se.Employee)
                .WithMany(e => e.SubjectEmployees)
                .HasForeignKey(se => se.EmployeeId);
            
            modelBuilder.Entity<Class>()
                .HasOne(se => se.Employee)
                .WithMany(s => s.Classes)
                .HasForeignKey(se => se.EmployeeId);

            modelBuilder.Entity<SubjectCabinet>()
                .HasOne(sc => sc.Subject)
                .WithMany(s => s.SubjectCabinets)
                .HasForeignKey(sc => sc.SubjectId);

            modelBuilder.Entity<SubjectCabinet>()
                .HasOne(sc => sc.Cabinet)
                .WithMany(c => c.SubjectCabinets)
                .HasForeignKey(sc => sc.CabinetId);
        }
    }
}
