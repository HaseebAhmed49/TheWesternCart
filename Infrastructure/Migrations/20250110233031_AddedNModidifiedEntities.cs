using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNModidifiedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Wishlists_WishlistId",
                table: "WishlistItems");

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("03026585-2188-4aac-8002-92c171821133"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("146b3cdf-3114-4499-bf63-1732a8b7e29c"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("724d065a-9aa1-42b5-a24e-339843e964e9"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("a3f7f378-e0ac-4687-89aa-95527c916c4c"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("e4bf18c2-d7d8-40ed-91b4-46124308449b"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("f7ade5d9-4bd0-4f63-9119-458adaa73071"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("18beee8d-0859-48a9-9f98-a117b2abed2b"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("4d4828a9-05e9-450f-a064-09b10855dc45"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("56f70807-9719-45ce-98a3-cb6df907ee0d"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("7073833a-1dc1-4a2e-bfb9-61c4bb1cfd02"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "WishlistId",
                table: "WishlistItems",
                newName: "WishListId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_WishlistId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_WishListId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhotos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ClothingItems",
                columns: new[] { "Id", "Category", "ClothingBrandId", "CreatedAt", "Description", "Discount", "Gender", "IsInStock", "LastUpdatedAt", "Name", "PictureUrl", "Price", "Size" },
                values: new object[,]
                {
                    { new Guid("0fb81dc0-6fc6-491e-a49d-ede408abe55a"), 5, new Guid("e96c60b6-09df-4e1a-9d6c-617bdd48eaf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Dior Saddle Bag in blue oblique canvas.", null, 1, true, null, "Dior Saddle Bag", "images/clothing/dior_saddle_bag.jpg", 2900.00m, 2 },
                    { new Guid("16a780d2-13f2-435f-9dd4-06da87a725aa"), 3, new Guid("c981db82-b2f1-48c3-9864-efc6c56a5b0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black leather belt with double G buckle from Gucci.", null, 0, true, null, "Gucci GG Belt", "images/clothing/gucci_belt.jpg", 450.00m, 3 },
                    { new Guid("30eac977-73e9-46ae-8a1f-bfcfe74d018a"), 2, new Guid("3d6f79a2-c462-4c28-ae5f-0ec93b7f4e01"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Chanel tweed jacket in black and white.", null, 1, true, null, "Chanel Tweed Jacket", "images/clothing/chanel_tweed_jacket.jpg", 5000.00m, 2 },
                    { new Guid("354adb99-4de5-4484-a162-2ab449cf70d6"), 0, new Guid("5d24a48b-6c72-4e2a-9ef2-64d0f657bfc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Versace silk shirt with baroque print in gold and black.", null, 0, true, null, "Versace Silk Shirt", "images/clothing/versace_silk_shirt.jpg", 1200.00m, 3 },
                    { new Guid("7a68125c-5a2c-4c29-8548-e763db5ac5e5"), 5, new Guid("a2c5c305-f2c2-45e7-8f7d-c489bb7f7e8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic black nylon backpack with leather trim.", null, 1, true, null, "Prada Nylon Backpack", "images/clothing/prada_backpack.jpg", 950.00m, 2 },
                    { new Guid("eafb77a2-e173-49a8-b52e-504213c82dee"), 5, new Guid("b5d6b8f8-dad4-4f2f-8c52-2911d856b3ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iconic Louis Vuitton bag with monogram canvas.", null, 1, true, null, "Louis Vuitton Monogram Bag", "images/clothing/lv_monogram_bag.jpg", 3200.00m, 2 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "CreatedAt", "DeliveryTime", "Description", "LastUpdatedAt", "Price", "ShortName" },
                values: new object[,]
                {
                    { new Guid("3e71a7ec-d61a-43d0-a6f4-99060a7c84ef"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Days", "Fastest delivery time", null, 10m, "UPS1" },
                    { new Guid("5de7b5b2-f812-4224-8004-55f5de247504"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Weeks", "Free! You get what you pay for", null, 0m, "FREE" },
                    { new Guid("ab1f36a2-a026-4f89-b043-5025ffaa8d9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 Days", "Get it within 5 days", null, 5m, "UPS2" },
                    { new Guid("d89d77ed-b918-4023-ba81-87d0da2a2d3b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-10 Days", "Slower but cheap", null, 2m, "UPS3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPhotos_UserId",
                table: "UserPhotos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Wishlists_WishListId",
                table: "WishlistItems",
                column: "WishListId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Wishlists_WishListId",
                table: "WishlistItems");

            migrationBuilder.DropTable(
                name: "UserPhotos");

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("0fb81dc0-6fc6-491e-a49d-ede408abe55a"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("16a780d2-13f2-435f-9dd4-06da87a725aa"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("30eac977-73e9-46ae-8a1f-bfcfe74d018a"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("354adb99-4de5-4484-a162-2ab449cf70d6"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("7a68125c-5a2c-4c29-8548-e763db5ac5e5"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("eafb77a2-e173-49a8-b52e-504213c82dee"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("3e71a7ec-d61a-43d0-a6f4-99060a7c84ef"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("5de7b5b2-f812-4224-8004-55f5de247504"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("ab1f36a2-a026-4f89-b043-5025ffaa8d9c"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("d89d77ed-b918-4023-ba81-87d0da2a2d3b"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "WishListId",
                table: "WishlistItems",
                newName: "WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_WishListId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_WishlistId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ClothingItems",
                columns: new[] { "Id", "Category", "ClothingBrandId", "CreatedAt", "Description", "Discount", "Gender", "IsInStock", "LastUpdatedAt", "Name", "PictureUrl", "Price", "Size" },
                values: new object[,]
                {
                    { new Guid("03026585-2188-4aac-8002-92c171821133"), 2, new Guid("3d6f79a2-c462-4c28-ae5f-0ec93b7f4e01"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Chanel tweed jacket in black and white.", null, 1, true, null, "Chanel Tweed Jacket", "images/clothing/chanel_tweed_jacket.jpg", 5000.00m, 2 },
                    { new Guid("146b3cdf-3114-4499-bf63-1732a8b7e29c"), 0, new Guid("5d24a48b-6c72-4e2a-9ef2-64d0f657bfc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Versace silk shirt with baroque print in gold and black.", null, 0, true, null, "Versace Silk Shirt", "images/clothing/versace_silk_shirt.jpg", 1200.00m, 3 },
                    { new Guid("724d065a-9aa1-42b5-a24e-339843e964e9"), 5, new Guid("e96c60b6-09df-4e1a-9d6c-617bdd48eaf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Dior Saddle Bag in blue oblique canvas.", null, 1, true, null, "Dior Saddle Bag", "images/clothing/dior_saddle_bag.jpg", 2900.00m, 2 },
                    { new Guid("a3f7f378-e0ac-4687-89aa-95527c916c4c"), 5, new Guid("a2c5c305-f2c2-45e7-8f7d-c489bb7f7e8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic black nylon backpack with leather trim.", null, 1, true, null, "Prada Nylon Backpack", "images/clothing/prada_backpack.jpg", 950.00m, 2 },
                    { new Guid("e4bf18c2-d7d8-40ed-91b4-46124308449b"), 5, new Guid("b5d6b8f8-dad4-4f2f-8c52-2911d856b3ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iconic Louis Vuitton bag with monogram canvas.", null, 1, true, null, "Louis Vuitton Monogram Bag", "images/clothing/lv_monogram_bag.jpg", 3200.00m, 2 },
                    { new Guid("f7ade5d9-4bd0-4f63-9119-458adaa73071"), 3, new Guid("c981db82-b2f1-48c3-9864-efc6c56a5b0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black leather belt with double G buckle from Gucci.", null, 0, true, null, "Gucci GG Belt", "images/clothing/gucci_belt.jpg", 450.00m, 3 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "CreatedAt", "DeliveryTime", "Description", "LastUpdatedAt", "Price", "ShortName" },
                values: new object[,]
                {
                    { new Guid("18beee8d-0859-48a9-9f98-a117b2abed2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Days", "Fastest delivery time", null, 10m, "UPS1" },
                    { new Guid("4d4828a9-05e9-450f-a064-09b10855dc45"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Weeks", "Free! You get what you pay for", null, 0m, "FREE" },
                    { new Guid("56f70807-9719-45ce-98a3-cb6df907ee0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 Days", "Get it within 5 days", null, 5m, "UPS2" },
                    { new Guid("7073833a-1dc1-4a2e-bfb9-61c4bb1cfd02"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-10 Days", "Slower but cheap", null, 2m, "UPS3" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Wishlists_WishlistId",
                table: "WishlistItems",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
