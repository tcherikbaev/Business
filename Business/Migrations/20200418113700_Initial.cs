using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sum = table.Column<double>(nullable: true),
                    Srok_In_Months = table.Column<short>(nullable: true),
                    Procent_Penya = table.Column<short>(nullable: true),
                    Ostatok = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "budget",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sum_of_budget = table.Column<decimal>(type: "money", nullable: true),
                    Premia_procent = table.Column<double>(nullable: true),
                    Nadbavka = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_budget", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Doljnost",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doljnost = table.Column<string>(fixedLength: true, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doljnost", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "P_R",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false),
                    production = table.Column<short>(nullable: false),
                    amount = table.Column<double>(nullable: true),
                    sum = table.Column<decimal>(type: "money", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    employee = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PP",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false),
                    product = table.Column<short>(nullable: false),
                    amount = table.Column<double>(nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    employee = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "R",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false),
                    raw_material = table.Column<short>(nullable: false),
                    amount = table.Column<double>(nullable: true),
                    sum = table.Column<decimal>(type: "money", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    employee = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vyplata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Srok = table.Column<DateTime>(type: "date", nullable: true),
                    Oplachivaetsya = table.Column<DateTime>(type: "date", nullable: true),
                    Sum = table.Column<double>(nullable: true),
                    Procent = table.Column<double>(nullable: true),
                    Procts = table.Column<double>(nullable: true),
                    Penya = table.Column<double>(nullable: true),
                    Total = table.Column<double>(nullable: true),
                    Ostatok = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vyplata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(fixedLength: true, maxLength: 20, nullable: true),
                    Doljnost = table.Column<byte>(nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    Address = table.Column<string>(fixedLength: true, maxLength: 40, nullable: true),
                    Telephone = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees:doljnost",
                        column: x => x.Doljnost,
                        principalTable: "Doljnost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Finished_products:",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    Unit = table.Column<byte>(nullable: true),
                    Sum = table.Column<decimal>(type: "money", nullable: true),
                    Quantity = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finished_products:", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Finished_products:Unit",
                        column: x => x.Unit,
                        principalTable: "Unit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "raw_materials",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false),
                    Name = table.Column<string>(fixedLength: true, maxLength: 30, nullable: true),
                    Unit = table.Column<byte>(nullable: true),
                    Sum = table.Column<double>(nullable: true),
                    Quantity = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raw_materials", x => x.ID);
                    table.ForeignKey(
                        name: "FK_raw_materials_unit",
                        column: x => x.Unit,
                        principalTable: "Unit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<byte>(nullable: true),
                    Year = table.Column<short>(nullable: true),
                    Month = table.Column<short>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Oklad = table.Column<int>(nullable: true),
                    CountStake = table.Column<int>(nullable: true),
                    Bonus = table.Column<int>(nullable: true),
                    Premia = table.Column<int>(nullable: true),
                    Total = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Salary_Month",
                        column: x => x.Month,
                        principalTable: "Month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salary_Employee",
                        column: x => x.Name,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salary_Year",
                        column: x => x.Year,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "prodaja_production",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false),
                    production = table.Column<short>(nullable: false),
                    amount = table.Column<double>(nullable: true),
                    sum = table.Column<decimal>(type: "money", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    employee = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prodaja_production", x => x.ID);
                    table.ForeignKey(
                        name: "FK_prodaja_production_Employees",
                        column: x => x.employee,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prodaja_production_Finished_products:",
                        column: x => x.production,
                        principalTable: "Finished_products:",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proizvodstvo",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false),
                    product = table.Column<short>(nullable: false),
                    amount = table.Column<double>(nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    employee = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proizvodstvo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_proizvodstvo_Employees",
                        column: x => x.employee,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proizvodstvo_Finished_products:",
                        column: x => x.product,
                        principalTable: "Finished_products:",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false),
                    Product = table.Column<short>(nullable: true),
                    Raw_product = table.Column<short>(nullable: false),
                    Quntatity = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingridients_finished product",
                        column: x => x.Product,
                        principalTable: "Finished_products:",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingridients_raw_material",
                        column: x => x.Raw_product,
                        principalTable: "raw_materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "zakupka_raw_material",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false),
                    raw_material = table.Column<short>(nullable: false),
                    amount = table.Column<double>(nullable: true),
                    sum = table.Column<decimal>(type: "money", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    employee = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zakupka_raw_material", x => x.ID);
                    table.ForeignKey(
                        name: "FK_zakupka_raw_material_Employees",
                        column: x => x.employee,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_zakupka_raw_material_",
                        column: x => x.raw_material,
                        principalTable: "raw_materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Doljnost",
                table: "Employees",
                column: "Doljnost");

            migrationBuilder.CreateIndex(
                name: "IX_Finished_products:_Unit",
                table: "Finished_products:",
                column: "Unit");

            migrationBuilder.CreateIndex(
                name: "IX_Ingridients_Product",
                table: "Ingridients",
                column: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Ingridients_Raw_product",
                table: "Ingridients",
                column: "Raw_product");

            migrationBuilder.CreateIndex(
                name: "IX_prodaja_production_employee",
                table: "prodaja_production",
                column: "employee");

            migrationBuilder.CreateIndex(
                name: "IX_prodaja_production_production",
                table: "prodaja_production",
                column: "production");

            migrationBuilder.CreateIndex(
                name: "IX_proizvodstvo_employee",
                table: "proizvodstvo",
                column: "employee");

            migrationBuilder.CreateIndex(
                name: "IX_proizvodstvo_product",
                table: "proizvodstvo",
                column: "product");

            migrationBuilder.CreateIndex(
                name: "IX_raw_materials_Unit",
                table: "raw_materials",
                column: "Unit");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Month",
                table: "Salary",
                column: "Month");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Name",
                table: "Salary",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Year",
                table: "Salary",
                column: "Year");

            migrationBuilder.CreateIndex(
                name: "IX_zakupka_raw_material_employee",
                table: "zakupka_raw_material",
                column: "employee");

            migrationBuilder.CreateIndex(
                name: "IX_zakupka_raw_material_raw_material",
                table: "zakupka_raw_material",
                column: "raw_material");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "budget");

            migrationBuilder.DropTable(
                name: "Ingridients");

            migrationBuilder.DropTable(
                name: "P_R");

            migrationBuilder.DropTable(
                name: "PP");

            migrationBuilder.DropTable(
                name: "prodaja_production");

            migrationBuilder.DropTable(
                name: "proizvodstvo");

            migrationBuilder.DropTable(
                name: "R");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "Vyplata");

            migrationBuilder.DropTable(
                name: "zakupka_raw_material");

            migrationBuilder.DropTable(
                name: "Finished_products:");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "raw_materials");

            migrationBuilder.DropTable(
                name: "Doljnost");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
