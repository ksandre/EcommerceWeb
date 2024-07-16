using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategorySlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorySlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxQuantity = table.Column<int>(type: "int", nullable: false),
                    InitialPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceId);
                    table.ForeignKey(
                        name: "FK_Prices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                    table.ForeignKey(
                        name: "FK_Sizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                    table.ForeignKey(
                        name: "FK_Colors_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId");
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.MediaId);
                    table.ForeignKey(
                        name: "FK_Medias_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategorySlug", "CreatedBy", "DateCreated", "DateModified", "Description", "Id", "ModifiedBy", "Name", "Slug", "SubCategorySlug" },
                values: new object[,]
                {
                    { 260, "makeup", null, null, null, "ეს ტუჩსაცხი გამორჩეულია დამატენიანებელი მოქმედებით და მდგრადობით.", 0, null, "შემავსებელი ტუჩსაცხი", "peptalk-lipstick-bullet-refill", "lips" },
                    { 261, "makeup", null, null, null, "ეს ბალზამი შექმნილია 95%  დამატენიანებელი ინგრედიენტებით, მათ შორის შის კარაქით, განადან.", 0, null, "Swipe It ტუჩის დამატენიანებელი ბალზამი", "swipe-it-moisturising-lip-balm", "lips" }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "PriceId", "DiscountPrice", "InitialPrice", "MaxQuantity", "ProductId" },
                values: new object[,]
                {
                    { 7, 8.75m, 12.25m, 2, 260 },
                    { 8, 7.75m, 32.25m, 5, 261 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "ProductId", "SizeUnit", "SizeValue" },
                values: new object[,]
                {
                    { 1, 260, "გრ", "4.0" },
                    { 2, 261, "გრ", "15.0" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "Hex", "Name", "SizeId" },
                values: new object[,]
                {
                    { 13, "#ff0000", "Cherry", 1 },
                    { 14, "#cc7700", "Violet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "MediaId", "ColorId", "Priority", "Type", "Url" },
                values: new object[,]
                {
                    { 11, 13, 1, 0, "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32396/49845_1_thumb.png" },
                    { 12, 13, 2, 0, "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32398/49845_2_thumb.png" },
                    { 13, 13, 3, 0, "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32400/49845_3_thumb.png" },
                    { 14, 14, 4, 0, "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32402/49845_4_thumb.png" },
                    { 15, 14, 5, 0, "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32404/49845_5_thumb.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_SizeId",
                table: "Colors",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ColorId",
                table: "Medias",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ProductId",
                table: "Prices",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ProductId",
                table: "Sizes",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
