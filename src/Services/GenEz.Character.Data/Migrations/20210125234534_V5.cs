using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_name_origin",
                columns: new[] { "Id", "Name", "NeutralName" },
                values: new object[,]
                {
                    { new Guid("be0c73e9-2710-4676-9478-ee36a9e6f96e"), "African", "AFRICAN" },
                    { new Guid("f7a540bd-ddc7-421d-a879-0e7974a5633b"), "Arabic", "ARABIC" },
                    { new Guid("732c6a1b-ef2d-4471-acf8-3f9033ef5d57"), "Biblical", "BIBLICAL" },
                    { new Guid("81f4bb6e-3c6d-4ee4-a7c6-4f18be3dd478"), "Celtic", "CELTIC" },
                    { new Guid("e376ea1a-0f28-4f67-809a-a78bcc0a7183"), "Chinese", "CHINESE" },
                    { new Guid("838c1be0-06b0-48ac-9268-c69072280f90"), "French", "FRENCH" },
                    { new Guid("208ed58e-d875-473a-a67e-3dc3e034c783"), "Gaelic", "GAELIC" },
                    { new Guid("eb47fd93-662f-45a8-b6f4-fe63400d0c3d"), "German", "GERMAN" },
                    { new Guid("0c101315-5611-4967-acb0-27e124d5de1c"), "Greek", "GREEK" },
                    { new Guid("6408b9ea-d64f-4f22-9045-133788ecb4b6"), "Hawaiian", "HAWAIIAN" },
                    { new Guid("ee7088e9-706b-49c6-8468-ed57ddfaed12"), "Hindu", "HINDU" },
                    { new Guid("4455ea44-e256-4f38-b120-5da91007aef6"), "Italian", "ITALIAN" },
                    { new Guid("bc3d3311-4353-4fe7-85f8-e9816ca2e80a"), "Japanese", "JAPANESE" },
                    { new Guid("fcb12666-b2f2-4a00-a9e8-0b48e46653cd"), "Latin", "LATIN" },
                    { new Guid("9da6842e-8f89-4a04-a187-973bef4f0d45"), "Portuguese", "PORTUGUESE" },
                    { new Guid("609c53b7-968c-46b0-b231-01e0ddc6a351"), "Russian", "RUSSIAN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("0c101315-5611-4967-acb0-27e124d5de1c"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("208ed58e-d875-473a-a67e-3dc3e034c783"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("4455ea44-e256-4f38-b120-5da91007aef6"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("609c53b7-968c-46b0-b231-01e0ddc6a351"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("6408b9ea-d64f-4f22-9045-133788ecb4b6"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("732c6a1b-ef2d-4471-acf8-3f9033ef5d57"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("81f4bb6e-3c6d-4ee4-a7c6-4f18be3dd478"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("838c1be0-06b0-48ac-9268-c69072280f90"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("9da6842e-8f89-4a04-a187-973bef4f0d45"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("bc3d3311-4353-4fe7-85f8-e9816ca2e80a"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("be0c73e9-2710-4676-9478-ee36a9e6f96e"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("e376ea1a-0f28-4f67-809a-a78bcc0a7183"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("eb47fd93-662f-45a8-b6f4-fe63400d0c3d"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("ee7088e9-706b-49c6-8468-ed57ddfaed12"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("f7a540bd-ddc7-421d-a879-0e7974a5633b"));

            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("fcb12666-b2f2-4a00-a9e8-0b48e46653cd"));
        }
    }
}
