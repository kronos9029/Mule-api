using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuleWebAPIPhatPT19.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    fldAccount = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    fldPassword = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    fldRole = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.fldAccount, x.fldPassword })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    UnitPrice = table.Column<double>(type: "double", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    Unit = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    QuantityInStock = table.Column<double>(type: "double", nullable: true, defaultValueSql: "'0'"),
                    CreatedByDate = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "'2024-01-01'"),
                    CreatedBy = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ProductCode, x.UnitPrice })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "purchaseorderdetails",
                columns: table => new
                {
                    OrderNo = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ProductCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    PurchasePrice = table.Column<double>(type: "double", nullable: false),
                    Quantity = table.Column<double>(type: "double", nullable: true, defaultValueSql: "'0'"),
                    Tax = table.Column<double>(type: "double", nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.OrderNo, x.ProductCode, x.PurchasePrice })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "purchaseorders",
                columns: table => new
                {
                    OrderNo = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'2024-01-01'"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    CreatedByDate = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "'2024-01-01'"),
                    CreatedBy = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.OrderNo, x.OrderDate })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "salesorderdetails",
                columns: table => new
                {
                    OrderNo = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ProductCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    SalesPrice = table.Column<double>(type: "double", nullable: false),
                    Quantity = table.Column<double>(type: "double", nullable: true, defaultValueSql: "'0'"),
                    Tax = table.Column<double>(type: "double", nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.OrderNo, x.ProductCode, x.SalesPrice })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "salesorders",
                columns: table => new
                {
                    OrderNo = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'2024-01-01'"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    CreatedByDate = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "'2024-01-01'"),
                    CreatedBy = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, defaultValueSql: "''", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.OrderNo, x.OrderDate })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "purchaseorderdetails");

            migrationBuilder.DropTable(
                name: "purchaseorders");

            migrationBuilder.DropTable(
                name: "salesorderdetails");

            migrationBuilder.DropTable(
                name: "salesorders");
        }
    }
}
