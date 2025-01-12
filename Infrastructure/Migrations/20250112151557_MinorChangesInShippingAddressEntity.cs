using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MinorChangesInShippingAddressEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("254477ac-5297-4578-a600-19baa2ff90d0"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("5f286a7c-29c1-400d-958d-49a000315eaa"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("6751da5c-e813-493b-898f-709fff047c58"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("863e4d73-466d-4e20-8441-0e088306caf1"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("b3deabe2-fc6a-4fce-8e24-368562a87a26"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("bae7ecd0-5b46-4ee3-8115-ac5b578b111e"));

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

            migrationBuilder.AlterColumn<string>(
                name: "Address_State",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address_PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<bool>(
                name: "Address_IsDefault",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address_City",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address_AddressLine",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "ClothingItems",
                columns: new[] { "Id", "Category", "ClothingBrandId", "CreatedAt", "Description", "Discount", "Gender", "IsInStock", "LastUpdatedAt", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { new Guid("560e4627-2287-43ac-b13f-eb22ba5b91d7"), 4, new Guid("e96c60b6-09df-4e1a-9d6c-617bdd48eaf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New for Winter 2024, the Dior Icon heeled ankle boot transcends House codes of couture refinement. The black suede calfskin upper is elevated by elastic bands on the sides and the gold-finish metal CD signature on the back. The 8-cm (3) Graphic Cannage cylindrical heel in gold-finish metal offers a modern 3D version of the House's iconic motif. Featuring a square toe, the sophisticated and comfortable ankle boot will add the finishing touch to any of the season's looks.", null, 1, true, null, "Dior Icon Heeled Ankle Boot", 2900.00m, 2 },
                    { new Guid("671cd438-0417-4925-b076-87ec78abb942"), 2, new Guid("3d6f79a2-c462-4c28-ae5f-0ec93b7f4e01"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic Chanel tweed jacket in black.", null, 1, true, null, "Chanel JACKET", 5000.00m, 2 },
                    { new Guid("870953c3-3111-44ae-9f67-a249ad14a086"), 3, new Guid("b5d6b8f8-dad4-4f2f-8c52-2911d856b3ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The LV Gram Square Cat Eye sunglasses feature a distinctive signature from Louis Vuitton’s jewelry and belts collections. The slim acetate and metal temples are adorned with the LV Initials and two Monogram Flowers finely crafted in gold-tone metal. Monogram Flower details on the lenses and end tips add an extra House touch. These stylish, feminine sunglasses are ideal for accenting a summer outfit.", null, 1, true, null, "LV Gram Square Cat Eye Sunglasses", 3200.00m, 2 },
                    { new Guid("c3f049bc-64da-4964-bf99-942b32a86bf3"), 3, new Guid("c981db82-b2f1-48c3-9864-efc6c56a5b0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The GG Marmont belt continues to enrich each new collection with its streamlined design. Inspired by an archival design from the 1970s, the line's monogram Double G hardware is presented in a shiny silver tone atop this black leather variation.", null, 0, true, null, "Gucci GG MARMONT THIN BELT", 450.00m, 3 },
                    { new Guid("e59e1f15-a129-46c6-9179-edb2f0d85192"), 0, new Guid("5d24a48b-6c72-4e2a-9ef2-64d0f657bfc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A regular-fit, long-sleeved fluid shirt featuring an all-over tonal Barocco devore motif.", null, 0, true, null, "Versace Barocco Devore Shirt", 1200.00m, 3 },
                    { new Guid("e92784cf-f29b-4cd1-bace-6447c9207865"), 0, new Guid("a2c5c305-f2c2-45e7-8f7d-c489bb7f7e8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An essential item of the brand, the Prada jersey T-shirt embodies the luxury of simplicity that becomes an attitude and search to reinvent the bases and propose new meanings. The design is accented with the brand's emblematic lettering logo presented here in a silicone version.", null, 1, true, null, "Prada Cotton T-shirt", 950.00m, 2 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "CreatedAt", "DeliveryTime", "Description", "LastUpdatedAt", "Price", "ShortName" },
                values: new object[,]
                {
                    { new Guid("19a9b507-7c2e-4df6-a3af-3f4e4d93bdcf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 Days", "Get it within 5 days", null, 5m, "UPS2" },
                    { new Guid("4c50b396-069d-4352-9ed3-8647a6fc634f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-10 Days", "Slower but cheap", null, 2m, "UPS3" },
                    { new Guid("4d6b384a-2597-4989-a8ac-7b863c18cad8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Weeks", "Free! You get what you pay for", null, 0m, "FREE" },
                    { new Guid("889a0714-0f41-40c3-9ea3-19b8a1949598"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 Days", "Fastest delivery time", null, 10m, "UPS1" }
                });

            migrationBuilder.InsertData(
                table: "ClothingItemPhotos",
                columns: new[] { "Id", "ClothingItemId", "CreatedAt", "IsMain", "LastUpdatedAt", "PublicId", "Url" },
                values: new object[,]
                {
                    { new Guid("33176701-13c8-4feb-8cd8-51bac495dc6e"), new Guid("560e4627-2287-43ac-b13f-eb22ba5b91d7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId4", "https://www.dior.com/couture/ecommerce/media/catalog/product/Q/K/1721839565_KCT067VVV_S900_E03_GHC.jpg?imwidth=720" },
                    { new Guid("6ffbf37f-4452-4f31-9f92-498fd642d8b7"), new Guid("e92784cf-f29b-4cd1-bace-6447c9207865"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId2", "https://www.prada.com/content/dam/pradabkg_products/U/UJN/UJN815/1052F0002/UJN815_1052_F0002_S_221_SLF.jpg/_jcr_content/renditions/cq5dam.web.hebebed.1000.1000.jpg" },
                    { new Guid("7914ab01-acff-4e3f-95e8-75ba3a7d9bac"), new Guid("c3f049bc-64da-4964-bf99-942b32a86bf3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId3", "https://media.gucci.com/style/DarkGray_Center_0_0_2400x2400/1714409103/414516_0AABG_1000_001_100_0000_Light-GG-Marmont-thin-belt.jpg" },
                    { new Guid("d2af9319-7f19-46ab-b8bb-a3d5c6b5df38"), new Guid("870953c3-3111-44ae-9f67-a249ad14a086"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId5", "https://eu.louisvuitton.com/images/is/image/lv/1/PP_VP_L/louis-vuitton-lv-gram-square-cat-eye-sunglasses-s00-sunglasses--Z2459U_PM2_Front%20view.png?wid=1090&hei=1090" },
                    { new Guid("ed55a288-0c0d-4410-91d6-d15b4e25ddaf"), new Guid("e59e1f15-a129-46c6-9179-edb2f0d85192"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId1", "https://www.versace.com/dw/image/v2/BGWN_PRD/on/demandware.static/-/Sites-ver-master-catalog/default/dwf9d0b70e/original/90_1012141-1A11358_1B000_10_BaroccoDevorShirt-Shirts-Versace-online-store_0_2.jpg?sw=1200&q=85&strip=true" },
                    { new Guid("fd305616-b565-4f18-80eb-9436f27f6c10"), new Guid("671cd438-0417-4925-b076-87ec78abb942"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "PublicId6", "https://www.chanel.com/images//t_zoomportee/f_auto//jacket-black-lambskin-lambskin-packshot-alternative-p78125c7009094305-9548808159262.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("33176701-13c8-4feb-8cd8-51bac495dc6e"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("6ffbf37f-4452-4f31-9f92-498fd642d8b7"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("7914ab01-acff-4e3f-95e8-75ba3a7d9bac"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("d2af9319-7f19-46ab-b8bb-a3d5c6b5df38"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("ed55a288-0c0d-4410-91d6-d15b4e25ddaf"));

            migrationBuilder.DeleteData(
                table: "ClothingItemPhotos",
                keyColumn: "Id",
                keyValue: new Guid("fd305616-b565-4f18-80eb-9436f27f6c10"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("19a9b507-7c2e-4df6-a3af-3f4e4d93bdcf"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("4c50b396-069d-4352-9ed3-8647a6fc634f"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("4d6b384a-2597-4989-a8ac-7b863c18cad8"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("889a0714-0f41-40c3-9ea3-19b8a1949598"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("560e4627-2287-43ac-b13f-eb22ba5b91d7"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("671cd438-0417-4925-b076-87ec78abb942"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("870953c3-3111-44ae-9f67-a249ad14a086"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("c3f049bc-64da-4964-bf99-942b32a86bf3"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("e59e1f15-a129-46c6-9179-edb2f0d85192"));

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: new Guid("e92784cf-f29b-4cd1-bace-6447c9207865"));

            migrationBuilder.AlterColumn<string>(
                name: "Address_State",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Address_IsDefault",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_City",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_AddressLine",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

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
        }
    }
}
