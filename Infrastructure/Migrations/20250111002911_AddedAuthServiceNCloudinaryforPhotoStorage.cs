using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuthServiceNCloudinaryforPhotoStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ItemOrdered_PictureUrl",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "ClothingItems");

            migrationBuilder.CreateTable(
                name: "ClothingItemPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClothingItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingItemPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothingItemPhotos_ClothingItems_ClothingItemId",
                        column: x => x.ClothingItemId,
                        principalTable: "ClothingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClothingItems",
                columns: new[] { "Id", "Category", "ClothingBrandId", "CreatedAt", "Description", "Discount", "Gender", "IsInStock", "LastUpdatedAt", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { new Guid("041ec767-c1b2-4345-ab32-9283215cb9a9"), 0, new Guid("5d24a48b-6c72-4e2a-9ef2-64d0f657bfc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A regular-fit, long-sleeved fluid shirt featuring an all-over tonal Barocco devore motif.", null, 0, true, null, "Versace Barocco Devore Shirt", 1200.00m, 3 },
                    { new Guid("0b6ee263-53e5-42c6-86b2-659aa3237d0c"), 2, new Guid("3d6f79a2-c462-4c28-ae5f-0ec93b7f4e01"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Chanel tweed jacket in black.", null, 1, true, null, "Chanel JACKET", 5000.00m, 2 },
                    { new Guid("209cb7ec-e2c6-4518-b16e-84a879c6d9fa"), 4, new Guid("e96c60b6-09df-4e1a-9d6c-617bdd48eaf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New for Winter 2024, the Dior Icon heeled ankle boot transcends House codes of couture refinement. The black suede calfskin upper is elevated by elastic bands on the sides and the gold-finish metal CD signature on the back. The 8-cm (3) Graphic Cannage cylindrical heel in gold-finish metal offers a modern 3D version of the House's iconic motif. Featuring a square toe, the sophisticated and comfortable ankle boot will add the finishing touch to any of the season's looks.", null, 1, true, null, "Dior Icon Heeled Ankle Boot", 2900.00m, 2 },
                    { new Guid("6fbdeba4-dff9-4ce0-98dd-f6977b887b5c"), 0, new Guid("a2c5c305-f2c2-45e7-8f7d-c489bb7f7e8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An essential item of the brand, the Prada jersey T-shirt embodies the luxury of simplicity that becomes an attitude and search to reinvent the bases and propose new meanings. The design is accented with the brand's emblematic lettering logo presented here in a silicone version.", null, 1, true, null, "Prada Cotton T-shirt", 950.00m, 2 },
                    { new Guid("96f4e9a4-9e2a-43ed-9f3d-d4cd10bf8b29"), 3, new Guid("c981db82-b2f1-48c3-9864-efc6c56a5b0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The GG Marmont belt continues to enrich each new collection with its streamlined design. Inspired by an archival design from the 1970s, the line's monogram Double G hardware is presented in a shiny silver tone atop this black leather variation.", null, 0, true, null, "Gucci GG MARMONT THIN BELT", 450.00m, 3 },
                    { new Guid("b60e8ccf-8eaf-4d26-873a-ac1096b6bcbd"), 3, new Guid("b5d6b8f8-dad4-4f2f-8c52-2911d856b3ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The LV Gram Square Cat Eye sunglasses feature a distinctive signature from Louis Vuitton’s jewelry and belts collections. The slim acetate and metal temples are adorned with the LV Initials and two Monogram Flowers finely crafted in gold-tone metal. Monogram Flower details on the lenses and end tips add an extra House touch. These stylish, feminine sunglasses are ideal for accenting a summer outfit.", null, 1, true, null, "LV Gram Square Cat Eye Sunglasses", 3200.00m, 2 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "CreatedAt", "DeliveryTime", "Description", "LastUpdatedAt", "Price", "ShortName" },
                values: new object[,]
                {
                    { new Guid("1a8b9a38-8f17-4b61-a40c-f820fd7f2b1b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 Days", "Get it within 5 days", null, 5m, "UPS2" },
                    { new Guid("2ef34342-3146-484b-8305-eed2d5a1b318"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-10 Days", "Slower but cheap", null, 2m, "UPS3" },
                    { new Guid("317f5e82-061b-4552-b63f-7263d21e31c6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Days", "Fastest delivery time", null, 10m, "UPS1" },
                    { new Guid("3f14dff5-3e2f-4843-a386-6fcf5f234779"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Weeks", "Free! You get what you pay for", null, 0m, "FREE" }
                });

            migrationBuilder.InsertData(
                table: "ClothingItemPhotos",
                columns: new[] { "Id", "ClothingItemId", "CreatedAt", "IsMain", "LastUpdatedAt", "PublicId", "Url" },
                values: new object[,]
                {
                    { new Guid("254477ac-5297-4578-a600-19baa2ff90d0"), new Guid("b60e8ccf-8eaf-4d26-873a-ac1096b6bcbd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId5", "https://eu.louisvuitton.com/images/is/image/lv/1/PP_VP_L/louis-vuitton-lv-gram-square-cat-eye-sunglasses-s00-sunglasses--Z2459U_PM2_Front%20view.png?wid=1090&hei=1090" },
                    { new Guid("5f286a7c-29c1-400d-958d-49a000315eaa"), new Guid("96f4e9a4-9e2a-43ed-9f3d-d4cd10bf8b29"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId3", "https://media.gucci.com/style/DarkGray_Center_0_0_2400x2400/1714409103/414516_0AABG_1000_001_100_0000_Light-GG-Marmont-thin-belt.jpg" },
                    { new Guid("6751da5c-e813-493b-898f-709fff047c58"), new Guid("6fbdeba4-dff9-4ce0-98dd-f6977b887b5c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId2", "https://www.prada.com/content/dam/pradabkg_products/U/UJN/UJN815/1052F0002/UJN815_1052_F0002_S_221_SLF.jpg/_jcr_content/renditions/cq5dam.web.hebebed.1000.1000.jpg" },
                    { new Guid("863e4d73-466d-4e20-8441-0e088306caf1"), new Guid("0b6ee263-53e5-42c6-86b2-659aa3237d0c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId6", "https://www.chanel.com/images//t_zoomportee/f_auto//jacket-black-lambskin-lambskin-packshot-alternative-p78125c7009094305-9548808159262.jpg" },
                    { new Guid("b3deabe2-fc6a-4fce-8e24-368562a87a26"), new Guid("041ec767-c1b2-4345-ab32-9283215cb9a9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId1", "https://www.versace.com/dw/image/v2/BGWN_PRD/on/demandware.static/-/Sites-ver-master-catalog/default/dwf9d0b70e/original/90_1012141-1A11358_1B000_10_BaroccoDevorShirt-Shirts-Versace-online-store_0_2.jpg?sw=1200&q=85&strip=true" },
                    { new Guid("bae7ecd0-5b46-4ee3-8115-ac5b578b111e"), new Guid("209cb7ec-e2c6-4518-b16e-84a879c6d9fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId4", "https://www.dior.com/couture/ecommerce/media/catalog/product/Q/K/1721839565_KCT067VVV_S900_E03_GHC.jpg?imwidth=720" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingItemPhotos_ClothingItemId",
                table: "ClothingItemPhotos",
                column: "ClothingItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingItemPhotos");

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("041ec767-c1b2-4345-ab32-9283215cb9a9"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("0b6ee263-53e5-42c6-86b2-659aa3237d0c"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("209cb7ec-e2c6-4518-b16e-84a879c6d9fa"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("6fbdeba4-dff9-4ce0-98dd-f6977b887b5c"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("96f4e9a4-9e2a-43ed-9f3d-d4cd10bf8b29"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("b60e8ccf-8eaf-4d26-873a-ac1096b6bcbd"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("1a8b9a38-8f17-4b61-a40c-f820fd7f2b1b"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("2ef34342-3146-484b-8305-eed2d5a1b318"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("317f5e82-061b-4552-b63f-7263d21e31c6"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("3f14dff5-3e2f-4843-a386-6fcf5f234779"));

            migrationBuilder.AddColumn<string>(
                name: "ItemOrdered_PictureUrl",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "ClothingItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
