﻿// <auto-generated />
using System;
using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Business.Migrations
{
    [DbContext(typeof(BusinessContext))]
    partial class BusinessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Business.Models.Bank", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Ostatok")
                        .HasColumnType("float");

                    b.Property<short?>("ProcentPenya")
                        .HasColumnName("Procent_Penya")
                        .HasColumnType("smallint");

                    b.Property<short?>("SrokInMonths")
                        .HasColumnName("Srok_In_Months")
                        .HasColumnType("smallint");

                    b.Property<double?>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("Business.Models.Budget", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Nadbavka")
                        .HasColumnType("float");

                    b.Property<double?>("PremiaProcent")
                        .HasColumnName("Premia_procent")
                        .HasColumnType("float");

                    b.Property<decimal?>("SumOfBudget")
                        .HasColumnName("Sum_of_budget")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("budget");
                });

            modelBuilder.Entity("Business.Models.Doljnost", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Doljnost1")
                        .HasColumnName("Doljnost")
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true)
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Doljnost");
                });

            modelBuilder.Entity("Business.Models.Employees", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nchar(40)")
                        .IsFixedLength(true)
                        .HasMaxLength(40);

                    b.Property<byte?>("Doljnost")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true)
                        .HasMaxLength(20);

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<int?>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Doljnost");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Business.Models.FinishedProducts", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<double?>("Quantity")
                        .HasColumnType("float");

                    b.Property<decimal?>("Sum")
                        .HasColumnType("money");

                    b.Property<byte?>("Unit")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("Unit");

                    b.ToTable("Finished_products:");
                });

            modelBuilder.Entity("Business.Models.Ingridients", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("smallint");

                    b.Property<short?>("Product")
                        .HasColumnType("smallint");

                    b.Property<double?>("Quntatity")
                        .HasColumnType("float");

                    b.Property<short>("RawProduct")
                        .HasColumnName("Raw_product")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Product");

                    b.HasIndex("RawProduct");

                    b.ToTable("Ingridients");
                });

            modelBuilder.Entity("Business.Models.Month", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Month1")
                        .HasColumnName("Month")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Month");
                });

            modelBuilder.Entity("Business.Models.PR", b =>
                {
                    b.Property<double?>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<byte>("Employee")
                        .HasColumnName("employee")
                        .HasColumnType("tinyint");

                    b.Property<short>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("smallint");

                    b.Property<short>("Production")
                        .HasColumnName("production")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("Sum")
                        .HasColumnName("sum")
                        .HasColumnType("money");

                    b.ToTable("P_R");
                });

            modelBuilder.Entity("Business.Models.Pp", b =>
                {
                    b.Property<double?>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<byte>("Employee")
                        .HasColumnName("employee")
                        .HasColumnType("tinyint");

                    b.Property<short>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("smallint");

                    b.Property<short>("Product")
                        .HasColumnName("product")
                        .HasColumnType("smallint");

                    b.ToTable("PP");
                });

            modelBuilder.Entity("Business.Models.ProdajaProduction", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("smallint");

                    b.Property<double?>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<byte>("Employee")
                        .HasColumnName("employee")
                        .HasColumnType("tinyint");

                    b.Property<short>("Production")
                        .HasColumnName("production")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("Sum")
                        .HasColumnName("sum")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("Employee");

                    b.HasIndex("Production");

                    b.ToTable("prodaja_production");
                });

            modelBuilder.Entity("Business.Models.Proizvodstvo", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("smallint");

                    b.Property<double?>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<byte>("Employee")
                        .HasColumnName("employee")
                        .HasColumnType("tinyint");

                    b.Property<short>("Product")
                        .HasColumnName("product")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Employee");

                    b.HasIndex("Product");

                    b.ToTable("proizvodstvo");
                });

            modelBuilder.Entity("Business.Models.R", b =>
                {
                    b.Property<double?>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<byte>("Employee")
                        .HasColumnName("employee")
                        .HasColumnType("tinyint");

                    b.Property<short>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("smallint");

                    b.Property<short>("RawMaterial")
                        .HasColumnName("raw_material")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("Sum")
                        .HasColumnName("sum")
                        .HasColumnType("money");

                    b.ToTable("R");
                });

            modelBuilder.Entity("Business.Models.RawMaterials", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<double?>("Quantity")
                        .HasColumnType("float");

                    b.Property<double?>("Sum")
                        .HasColumnType("float");

                    b.Property<byte?>("Unit")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("Unit");

                    b.ToTable("raw_materials");
                });

            modelBuilder.Entity("Business.Models.Salary", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bonus")
                        .HasColumnType("int");

                    b.Property<int?>("CountStake")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<short?>("Month")
                        .HasColumnType("smallint");

                    b.Property<byte?>("Name")
                        .HasColumnType("tinyint");

                    b.Property<int?>("Oklad")
                        .HasColumnType("int");

                    b.Property<int?>("Premia")
                        .HasColumnType("int");

                    b.Property<int?>("Total")
                        .HasColumnType("int");

                    b.Property<short?>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Month");

                    b.HasIndex("Name");

                    b.HasIndex("Year");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("Business.Models.Unit", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("Business.Models.Vyplata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Oplachivaetsya")
                        .HasColumnType("date");

                    b.Property<double?>("Ostatok")
                        .HasColumnType("float");

                    b.Property<double?>("Penya")
                        .HasColumnType("float");

                    b.Property<double?>("Procent")
                        .HasColumnType("float");

                    b.Property<double?>("Procts")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Srok")
                        .HasColumnType("date");

                    b.Property<double?>("Sum")
                        .HasColumnType("float");

                    b.Property<double?>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Vyplata");
                });

            modelBuilder.Entity("Business.Models.Year", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Year");
                });

            modelBuilder.Entity("Business.Models.ZakupkaRawMaterial", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("smallint");

                    b.Property<double?>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<byte>("Employee")
                        .HasColumnName("employee")
                        .HasColumnType("tinyint");

                    b.Property<short>("RawMaterial")
                        .HasColumnName("raw_material")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("Sum")
                        .HasColumnName("sum")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("Employee");

                    b.HasIndex("RawMaterial");

                    b.ToTable("zakupka_raw_material");
                });

            modelBuilder.Entity("Business.Models.Employees", b =>
                {
                    b.HasOne("Business.Models.Doljnost", "DoljnostNavigation")
                        .WithMany("Employees")
                        .HasForeignKey("Doljnost")
                        .HasConstraintName("FK_Employees:doljnost");
                });

            modelBuilder.Entity("Business.Models.FinishedProducts", b =>
                {
                    b.HasOne("Business.Models.Unit", "UnitNavigation")
                        .WithMany("FinishedProducts")
                        .HasForeignKey("Unit")
                        .HasConstraintName("FK_Finished_products:Unit");
                });

            modelBuilder.Entity("Business.Models.Ingridients", b =>
                {
                    b.HasOne("Business.Models.FinishedProducts", "ProductNavigation")
                        .WithMany("Ingridients")
                        .HasForeignKey("Product")
                        .HasConstraintName("FK_Ingridients_finished product");

                    b.HasOne("Business.Models.RawMaterials", "RawProductNavigation")
                        .WithMany("Ingridients")
                        .HasForeignKey("RawProduct")
                        .HasConstraintName("FK_Ingridients_raw_material")
                        .IsRequired();
                });

            modelBuilder.Entity("Business.Models.ProdajaProduction", b =>
                {
                    b.HasOne("Business.Models.Employees", "EmployeeNavigation")
                        .WithMany("ProdajaProduction")
                        .HasForeignKey("Employee")
                        .HasConstraintName("FK_prodaja_production_Employees")
                        .IsRequired();

                    b.HasOne("Business.Models.FinishedProducts", "ProductionNavigation")
                        .WithMany("ProdajaProduction")
                        .HasForeignKey("Production")
                        .HasConstraintName("FK_prodaja_production_Finished_products:")
                        .IsRequired();
                });

            modelBuilder.Entity("Business.Models.Proizvodstvo", b =>
                {
                    b.HasOne("Business.Models.Employees", "EmployeeNavigation")
                        .WithMany("Proizvodstvo")
                        .HasForeignKey("Employee")
                        .HasConstraintName("FK_proizvodstvo_Employees")
                        .IsRequired();

                    b.HasOne("Business.Models.FinishedProducts", "ProductNavigation")
                        .WithMany("Proizvodstvo")
                        .HasForeignKey("Product")
                        .HasConstraintName("FK_proizvodstvo_Finished_products:")
                        .IsRequired();
                });

            modelBuilder.Entity("Business.Models.RawMaterials", b =>
                {
                    b.HasOne("Business.Models.Unit", "UnitNavigation")
                        .WithMany("RawMaterials")
                        .HasForeignKey("Unit")
                        .HasConstraintName("FK_raw_materials_unit");
                });

            modelBuilder.Entity("Business.Models.Salary", b =>
                {
                    b.HasOne("Business.Models.Month", "MonthNavigation")
                        .WithMany("Salary")
                        .HasForeignKey("Month")
                        .HasConstraintName("FK_Salary_Month");

                    b.HasOne("Business.Models.Employees", "NameNavigation")
                        .WithMany("SalaryNavigation")
                        .HasForeignKey("Name")
                        .HasConstraintName("FK_Salary_Employee");

                    b.HasOne("Business.Models.Year", "YearNavigation")
                        .WithMany("Salary")
                        .HasForeignKey("Year")
                        .HasConstraintName("FK_Salary_Year");
                });

            modelBuilder.Entity("Business.Models.ZakupkaRawMaterial", b =>
                {
                    b.HasOne("Business.Models.Employees", "EmployeeNavigation")
                        .WithMany("ZakupkaRawMaterial")
                        .HasForeignKey("Employee")
                        .HasConstraintName("FK_zakupka_raw_material_Employees")
                        .IsRequired();

                    b.HasOne("Business.Models.RawMaterials", "RawMaterialNavigation")
                        .WithMany("ZakupkaRawMaterial")
                        .HasForeignKey("RawMaterial")
                        .HasConstraintName("FK_zakupka_raw_material_")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
