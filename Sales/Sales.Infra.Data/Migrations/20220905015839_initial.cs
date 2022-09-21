using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Infra.Data.Migrations
{
	public partial class initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Salesman",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
					Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
					Email = table.Column<string>(type: "varchar(100)", nullable: false),
					Phone = table.Column<string>(type: "varchar(20)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Salesman", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Sale",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					SalesManId = table.Column<int>(type: "int", nullable: false),
					SaleDate = table.Column<DateTime>(type: "DateTime", nullable: false),
					Status = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Sale", x => x.Id);
					table.ForeignKey(
						name: "FK_Sale_Salesman_SalesManId",
						column: x => x.SalesManId,
						principalTable: "Salesman",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "SaleItems",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Quantity = table.Column<int>(type: "int", nullable: false),
					UnitValue = table.Column<int>(type: "int", nullable: false),
					SaleId = table.Column<int>(type: "int", nullable: false),
					ProductId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SaleItems", x => x.Id);
					table.ForeignKey(
						name: "FK_SaleItems_Products_ProductId",
						column: x => x.ProductId,
						principalTable: "Products",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_SaleItems_Sale_SaleId",
						column: x => x.SaleId,
						principalTable: "Sale",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Sale_SalesManId",
				table: "Sale",
				column: "SalesManId");

			migrationBuilder.CreateIndex(
				name: "IX_SaleItems_ProductId",
				table: "SaleItems",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_SaleItems_SaleId",
				table: "SaleItems",
				column: "SaleId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "SaleItems");

			migrationBuilder.DropTable(
				name: "Products");

			migrationBuilder.DropTable(
				name: "Sale");

			migrationBuilder.DropTable(
				name: "Salesman");
		}
	}
}
