using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inventory.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Count", "Name", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("07626fad-9ce0-4d63-b1db-88fea9c76cb6"), 250, "Пельмени", 200m, new Guid("13941b7c-1ceb-4d02-96b1-ba2571c6671a") },
                    { new Guid("31115785-e806-44e5-8929-6426652d4913"), 300, "Хлеб чёрный", 50m, new Guid("c339a5e3-bcc9-4cad-b128-96016fccf794") },
                    { new Guid("74809422-51c1-4898-8dd9-e23c9f07edc2"), 200, "Картошка", 40m, new Guid("3aa8cc33-47da-4b19-bf36-6a6429244e7e") },
                    { new Guid("be940514-8207-4041-9dd6-f17b98c7aa8c"), 500, "Вода", 80m, new Guid("23cb36d8-ea5f-42f8-badd-ffa6ce6d62c2") },
                    { new Guid("d2c56805-ac08-48c6-bd99-ea53e14d6a7e"), 600, "Хлеб белый", 50m, new Guid("733d1ce3-cb68-441c-8640-31bfca4a6c50") },
                    { new Guid("d5ee9a45-c2f2-471e-bf45-bf38fde3d8aa"), 300, "Марковка", 35m, new Guid("ef798709-fc38-41fd-a262-61117b1ab91f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
