using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dropshiping.BackEnd.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModelsChangUpWithProperRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "RegoinId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_RegoinId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubcategoryImageId",
                table: "Subcategories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Products",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductImageId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryImageId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    CardHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecurityCode = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raitings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raitings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raitings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Raitings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shipping = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SizeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orderitems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductSizeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orderitems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orderitems_ProductSizes_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "ProductSizes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_SubcategoryImageId",
                table: "Subcategories",
                column: "SubcategoryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductImageId",
                table: "Products",
                column: "ProductImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryImageId",
                table: "Categories",
                column: "CategoryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_UserId",
                table: "Card",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderitems_OrderId",
                table: "Orderitems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderitems_ProductSizeId",
                table: "Orderitems",
                column: "ProductSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizeId",
                table: "ProductSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Raitings_ProductId",
                table: "Raitings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Raitings_UserId",
                table: "Raitings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_OrderId",
                table: "UserOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_UserId",
                table: "UserOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Images_CategoryImageId",
                table: "Categories",
                column: "CategoryImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_ProductImageId",
                table: "Products",
                column: "ProductImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Regions_RegoinId",
                table: "Products",
                column: "RegoinId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Images_SubcategoryImageId",
                table: "Subcategories",
                column: "SubcategoryImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Images_CategoryImageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_ProductImageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Regions_RegoinId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Images_SubcategoryImageId",
                table: "Subcategories");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Orderitems");

            migrationBuilder.DropTable(
                name: "Raitings");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Subcategories_SubcategoryImageId",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductImageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryImageId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SubcategoryImageId",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductImageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryImageId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "RegoinId",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_RegoinId",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
