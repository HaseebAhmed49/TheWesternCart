using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedClothingBrandsInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothingItems_ClothingBrand_ClothingBrandId",
                table: "ClothingItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingBrand",
                table: "ClothingBrand");

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("086a5be5-782b-4a9a-b259-abb147196c55"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("390b89bd-56fc-4acd-a8c6-5882fa506737"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("3bc7da1a-f77f-4a11-8d27-4f41784ae65e"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("470d41af-5cda-468c-ba3c-5785060eb8b8"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("b2a3b647-fc3f-47ef-820b-83b80482d1d9"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("d4c6e397-4e7f-4112-aaef-9c08c8f7d9e6"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("1de63a40-2da0-4a46-8c52-8603d72d9565"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("6b52931c-fc4b-4926-8daa-cd9844850323"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("79023ccf-e729-4ffb-9c9d-89c498e5f564"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("e9af7dbd-dab4-446e-865a-762b5fc7b378"));

            migrationBuilder.RenameTable(
                name: "ClothingBrand",
                newName: "ClothingBrands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingBrands",
                table: "ClothingBrands",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingItems_ClothingBrands_ClothingBrandId",
                table: "ClothingItems",
                column: "ClothingBrandId",
                principalTable: "ClothingBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothingItems_ClothingBrands_ClothingBrandId",
                table: "ClothingItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingBrands",
                table: "ClothingBrands");

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

            migrationBuilder.RenameTable(
                name: "ClothingBrands",
                newName: "ClothingBrand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingBrand",
                table: "ClothingBrand",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ClothingItems",
                columns: new[] { "Id", "Category", "ClothingBrandId", "CreatedAt", "Description", "Discount", "Gender", "IsInStock", "LastUpdatedAt", "Name", "PictureUrl", "Price", "Size" },
                values: new object[,]
                {
                    { new Guid("086a5be5-782b-4a9a-b259-abb147196c55"), 5, new Guid("b5d6b8f8-dad4-4f2f-8c52-2911d856b3ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iconic Louis Vuitton bag with monogram canvas.", null, 1, true, null, "Louis Vuitton Monogram Bag", "images/clothing/lv_monogram_bag.jpg", 3200.00m, 2 },
                    { new Guid("390b89bd-56fc-4acd-a8c6-5882fa506737"), 2, new Guid("3d6f79a2-c462-4c28-ae5f-0ec93b7f4e01"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Chanel tweed jacket in black and white.", null, 1, true, null, "Chanel Tweed Jacket", "images/clothing/chanel_tweed_jacket.jpg", 5000.00m, 2 },
                    { new Guid("3bc7da1a-f77f-4a11-8d27-4f41784ae65e"), 5, new Guid("e96c60b6-09df-4e1a-9d6c-617bdd48eaf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Dior Saddle Bag in blue oblique canvas.", null, 1, true, null, "Dior Saddle Bag", "images/clothing/dior_saddle_bag.jpg", 2900.00m, 2 },
                    { new Guid("470d41af-5cda-468c-ba3c-5785060eb8b8"), 5, new Guid("a2c5c305-f2c2-45e7-8f7d-c489bb7f7e8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic black nylon backpack with leather trim.", null, 1, true, null, "Prada Nylon Backpack", "images/clothing/prada_backpack.jpg", 950.00m, 2 },
                    { new Guid("b2a3b647-fc3f-47ef-820b-83b80482d1d9"), 0, new Guid("5d24a48b-6c72-4e2a-9ef2-64d0f657bfc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Versace silk shirt with baroque print in gold and black.", null, 0, true, null, "Versace Silk Shirt", "images/clothing/versace_silk_shirt.jpg", 1200.00m, 3 },
                    { new Guid("d4c6e397-4e7f-4112-aaef-9c08c8f7d9e6"), 3, new Guid("c981db82-b2f1-48c3-9864-efc6c56a5b0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black leather belt with double G buckle from Gucci.", null, 0, true, null, "Gucci GG Belt", "images/clothing/gucci_belt.jpg", 450.00m, 3 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "CreatedAt", "DeliveryTime", "Description", "LastUpdatedAt", "Price", "ShortName" },
                values: new object[,]
                {
                    { new Guid("1de63a40-2da0-4a46-8c52-8603d72d9565"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-10 Days", "Slower but cheap", null, 2m, "UPS3" },
                    { new Guid("6b52931c-fc4b-4926-8daa-cd9844850323"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Weeks", "Free! You get what you pay for", null, 0m, "FREE" },
                    { new Guid("79023ccf-e729-4ffb-9c9d-89c498e5f564"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Days", "Fastest delivery time", null, 10m, "UPS1" },
                    { new Guid("e9af7dbd-dab4-446e-865a-762b5fc7b378"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 Days", "Get it within 5 days", null, 5m, "UPS2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingItems_ClothingBrand_ClothingBrandId",
                table: "ClothingItems",
                column: "ClothingBrandId",
                principalTable: "ClothingBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
