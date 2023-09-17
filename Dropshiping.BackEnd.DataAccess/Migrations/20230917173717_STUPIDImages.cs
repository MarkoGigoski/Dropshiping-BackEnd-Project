using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dropshiping.BackEnd.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class STUPIDImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Images_CategoryImageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_ProductImageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Images_SubcategoryImageId",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Subcategories_SubcategoryImageId",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductImageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryImageId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "SubcategoryImageId",
                table: "Subcategories",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "ProductImageId",
                table: "Products",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "CategoryImageId",
                table: "Categories",
                newName: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_ImageId",
                table: "Subcategories",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageId",
                table: "Products",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_ImageId",
                table: "Products",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Images_ImageId",
                table: "Subcategories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_ImageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Images_ImageId",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Subcategories_ImageId",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ImageId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Subcategories",
                newName: "SubcategoryImageId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Products",
                newName: "ProductImageId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Categories",
                newName: "CategoryImageId");

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
                name: "FK_Subcategories_Images_SubcategoryImageId",
                table: "Subcategories",
                column: "SubcategoryImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
