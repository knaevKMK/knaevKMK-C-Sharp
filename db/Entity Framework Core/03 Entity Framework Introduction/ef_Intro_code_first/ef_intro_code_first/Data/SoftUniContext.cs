using System;
using ef_intro_code_first.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable
namespace ef_intro_code_first.Data
{

    public partial class SoftUniContext : DbContext
    {

        public SoftUniContext()
        {
        }

        public SoftUniContext(DbContextOptions<SoftUniContext> options)
                        : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeesProjects> EmployeesProjects { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Town> Towns { get; set; }

        private static string SERVER_CONNECTION = "Server=.\\SQLEXPRESS;Database=SoftUni;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SERVER_CONNECTION);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity => {

                entity.Property(e => e.AddressId).HasColumnName("AddressID");
                entity.Property(e => e.AddressText)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.TownID).HasColumnName("TownID");
                entity.HasOne(d => d.Town)
                .WithMany(p => p.Addresses)
                .HasForeignKey(d => d.TownID)
                .HasConstraintName("FK_Addresses_Towns");
            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentID).HasColumnName("DepartmentID");
                entity.Property(e => e.ManagerID).HasColumnName("ManagerID");

                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.HasOne(d => d.Manager).WithMany(p => p.Departments).HasForeignKey(d => d.ManagerID).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Departments_Employees");
            });
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectID).HasColumnName("ProjectID");
                entity.Property(e => e.Description).HasColumnType("ntext");
                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);

            });
            modelBuilder.Entity<Employee>(entity => {
                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
                entity.Property(e => e.AddressID).HasColumnName("AddressID");
                entity.Property(e => e.DepartmentID).HasColumnName("DepartmentID");
                entity.Property(e => e.ManagerID).HasColumnName("ManagerID");

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.MiddleName).HasMaxLength(50).IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(15,4)");
                entity.Property(e => e.HireDate).HasColumnType("smalldatetime");
                entity.Property(e => e.JobTitle).IsRequired().HasMaxLength(50).IsUnicode(false);

                entity.HasOne(d => d.Address).WithMany(p => p.Employees).HasForeignKey(d => d.AddressID)
                .HasConstraintName("FK+Employees_Addresses");
                entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasForeignKey(d => d.ManagerID)
                .HasConstraintName("FK_Employees_Employees");
                entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasForeignKey(d => d.DepartmentID)
                .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Emplyees_Departments");

            });
            modelBuilder.Entity<EmployeesProjects>(entity => {
                entity.HasKey(e => new { e.EmployeeID, e.ProjectID });
                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
                entity.Property(e => e.ProjectID).HasColumnName("ProjectID");

                entity.HasOne(d => d.Employee).WithMany(p => p.EmployeesProjects).HasForeignKey(d => d.EmployeeID)
                .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeesProjects_Emplohyees");
                entity.HasOne(d => d.Project).WithMany(p => p.EmployeesProjects).HasForeignKey(d => d.ProjectID)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeesProjects_Projects");
            });
            modelBuilder.Entity<Town>(entity =>
            {
                entity.Property(e => e.TownID).HasColumnName("TownID");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}