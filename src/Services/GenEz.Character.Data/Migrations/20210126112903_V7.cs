using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_name_origin",
                columns: new[] { "Id", "Name", "NeutralName" },
                values: new object[] { new Guid("24ecc259-89e2-4b20-b1f5-7890a5e4e820"), "Hebrew", "HEBREW" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("24ecc259-89e2-4b20-b1f5-7890a5e4e820"));
        }
    }
}
