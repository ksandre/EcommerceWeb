using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneSizeColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Prices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Prices",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "PriceId",
                keyValue: 7,
                columns: new[] { "ColorId", "SizeId" },
                values: new object[] { 13, 1 });

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "PriceId",
                keyValue: 8,
                columns: new[] { "ColorId", "SizeId" },
                values: new object[] { 14, null });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ColorId",
                table: "Prices",
                column: "ColorId",
                unique: true,
                filter: "[ColorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_SizeId",
                table: "Prices",
                column: "SizeId",
                unique: true,
                filter: "[SizeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Colors_ColorId",
                table: "Prices",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Sizes_SizeId",
                table: "Prices",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Colors_ColorId",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Sizes_SizeId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_ColorId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_SizeId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Prices");
        }
    }
}
