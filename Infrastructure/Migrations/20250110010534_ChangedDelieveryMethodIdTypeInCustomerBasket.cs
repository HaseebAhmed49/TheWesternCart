using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDelieveryMethodIdTypeInCustomerBasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("6b68bce6-110a-426a-b51c-5a32040dfd31"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("6fbc6477-5323-4d0c-9c48-f3ae4ea86284"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("8d5de529-58da-4059-86c8-a6a1955ff468"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("afc14de3-e8dd-4cdc-b193-4a0bb6dabf08"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("ded84a96-ea78-4b80-8511-38c0dbf2dd83"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("eb625fb1-e10a-4ef2-8fda-037ca946d50d"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("4ed22e9c-9a7d-4584-b993-a7279f869966"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("6d101243-5147-4774-9f59-001efce92a9e"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("9e9073ae-ba04-484f-9a26-fd2e3ecaf261"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("e919682b-00c5-4578-ae61-beb930ca5fc4"));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "ClothingItems",
                columns: new[] { "Id", "Category", "ClothingBrandId", "CreatedAt", "Description", "Discount", "Gender", "IsInStock", "LastUpdatedAt", "Name", "PictureUrl", "Price", "Size" },
                values: new object[,]
                {
                    { new Guid("6b68bce6-110a-426a-b51c-5a32040dfd31"), 3, new Guid("c981db82-b2f1-48c3-9864-efc6c56a5b0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black leather belt with double G buckle from Gucci.", null, 0, true, null, "Gucci GG Belt", "images/clothing/gucci_belt.jpg", 450.00m, 3 },
                    { new Guid("6fbc6477-5323-4d0c-9c48-f3ae4ea86284"), 5, new Guid("e96c60b6-09df-4e1a-9d6c-617bdd48eaf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Dior Saddle Bag in blue oblique canvas.", null, 1, true, null, "Dior Saddle Bag", "images/clothing/dior_saddle_bag.jpg", 2900.00m, 2 },
                    { new Guid("8d5de529-58da-4059-86c8-a6a1955ff468"), 5, new Guid("a2c5c305-f2c2-45e7-8f7d-c489bb7f7e8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic black nylon backpack with leather trim.", null, 1, true, null, "Prada Nylon Backpack", "images/clothing/prada_backpack.jpg", 950.00m, 2 },
                    { new Guid("afc14de3-e8dd-4cdc-b193-4a0bb6dabf08"), 5, new Guid("b5d6b8f8-dad4-4f2f-8c52-2911d856b3ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iconic Louis Vuitton bag with monogram canvas.", null, 1, true, null, "Louis Vuitton Monogram Bag", "images/clothing/lv_monogram_bag.jpg", 3200.00m, 2 },
                    { new Guid("ded84a96-ea78-4b80-8511-38c0dbf2dd83"), 0, new Guid("5d24a48b-6c72-4e2a-9ef2-64d0f657bfc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Versace silk shirt with baroque print in gold and black.", null, 0, true, null, "Versace Silk Shirt", "images/clothing/versace_silk_shirt.jpg", 1200.00m, 3 },
                    { new Guid("eb625fb1-e10a-4ef2-8fda-037ca946d50d"), 2, new Guid("3d6f79a2-c462-4c28-ae5f-0ec93b7f4e01"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Chanel tweed jacket in black and white.", null, 1, true, null, "Chanel Tweed Jacket", "images/clothing/chanel_tweed_jacket.jpg", 5000.00m, 2 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "CreatedAt", "DeliveryTime", "Description", "LastUpdatedAt", "Price", "ShortName" },
                values: new object[,]
                {
                    { new Guid("4ed22e9c-9a7d-4584-b993-a7279f869966"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Weeks", "Free! You get what you pay for", null, 0m, "FREE" },
                    { new Guid("6d101243-5147-4774-9f59-001efce92a9e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 Days", "Get it within 5 days", null, 5m, "UPS2" },
                    { new Guid("9e9073ae-ba04-484f-9a26-fd2e3ecaf261"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-10 Days", "Slower but cheap", null, 2m, "UPS3" },
                    { new Guid("e919682b-00c5-4578-ae61-beb930ca5fc4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Days", "Fastest delivery time", null, 10m, "UPS1" }
                });
        }
    }
}
