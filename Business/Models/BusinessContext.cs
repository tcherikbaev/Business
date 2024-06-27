using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Business.Models
{
    public partial class BusinessContext : DbContext
    {
        public BusinessContext()
        {
        }

        public BusinessContext(DbContextOptions<BusinessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Budget> Budget { get; set; }
        public virtual DbSet<Doljnost> Doljnost { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<FinishedProducts> FinishedProducts { get; set; }
        public virtual DbSet<Ingridients> Ingridients { get; set; }
        public virtual DbSet<Month> Month { get; set; }
        public virtual DbSet<PR> PR { get; set; }
        public virtual DbSet<Pp> Pp { get; set; }
        public virtual DbSet<ProdajaProduction> ProdajaProduction { get; set; }
        public virtual DbSet<Proizvodstvo> Proizvodstvo { get; set; }
        public virtual DbSet<R> R { get; set; }
        public virtual DbSet<RawMaterials> RawMaterials { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Vyplata> Vyplata { get; set; }
        public virtual DbSet<Year> Year { get; set; }
        public virtual DbSet<ZakupkaRawMaterial> ZakupkaRawMaterial { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=WIN-FTJ1J5HGOHN\\SQLEXPRESS;Database=Business;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProcentPenya).HasColumnName("Procent_Penya");

                entity.Property(e => e.SrokInMonths).HasColumnName("Srok_In_Months");
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.ToTable("budget");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PremiaProcent).HasColumnName("Premia_procent");

                entity.Property(e => e.SumOfBudget)
                    .HasColumnName("Sum_of_budget")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Doljnost>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Doljnost1)
                    .HasColumnName("Doljnost")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.DoljnostNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Doljnost)
                    .HasConstraintName("FK_Employees:doljnost");
            });

            modelBuilder.Entity<FinishedProducts>(entity =>
            {
                entity.ToTable("Finished_products:");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.FinishedProducts)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_Finished_products:Unit");
            });

            modelBuilder.Entity<Ingridients>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RawProduct).HasColumnName("Raw_product");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Ingridients)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Ingridients_finished product");

                entity.HasOne(d => d.RawProductNavigation)
                    .WithMany(p => p.Ingridients)
                    .HasForeignKey(d => d.RawProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingridients_raw_material");
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.Property(e => e.Month1)
                    .HasColumnName("Month")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PR>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("P_R");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Production).HasColumnName("production");

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Pp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PP");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Product).HasColumnName("product");
            });

            modelBuilder.Entity<ProdajaProduction>(entity =>
            {
                entity.ToTable("prodaja_production");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Production).HasColumnName("production");

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasColumnType("money");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.ProdajaProduction)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prodaja_production_Employees");

                entity.HasOne(d => d.ProductionNavigation)
                    .WithMany(p => p.ProdajaProduction)
                    .HasForeignKey(d => d.Production)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prodaja_production_Finished_products:");
            });

            modelBuilder.Entity<Proizvodstvo>(entity =>
            {
                entity.ToTable("proizvodstvo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Proizvodstvo)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_proizvodstvo_Employees");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Proizvodstvo)
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_proizvodstvo_Finished_products:");
            });

            modelBuilder.Entity<R>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RawMaterial).HasColumnName("raw_material");

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<RawMaterials>(entity =>
            {
                entity.ToTable("raw_materials");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.RawMaterials)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_raw_materials_unit");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.MonthNavigation)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.Month)
                    .HasConstraintName("FK_Salary_Month");

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.SalaryNavigation)
                    .HasForeignKey(d => d.Name)
                    .HasConstraintName("FK_Salary_Employee");

                entity.HasOne(d => d.YearNavigation)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.Year)
                    .HasConstraintName("FK_Salary_Year");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vyplata>(entity =>
            {
                entity.Property(e => e.Oplachivaetsya).HasColumnType("date");

                entity.Property(e => e.Srok).HasColumnType("date");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ZakupkaRawMaterial>(entity =>
            {
                entity.ToTable("zakupka_raw_material");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.RawMaterial).HasColumnName("raw_material");

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasColumnType("money");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.ZakupkaRawMaterial)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_zakupka_raw_material_Employees");

                entity.HasOne(d => d.RawMaterialNavigation)
                    .WithMany(p => p.ZakupkaRawMaterial)
                    .HasForeignKey(d => d.RawMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_zakupka_raw_material_");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
