using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_name_origin",
                keyColumn: "Id",
                keyValue: new Guid("732c6a1b-ef2d-4471-acf8-3f9033ef5d57"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_name_origin",
                columns: new[] { "Id", "Name", "NeutralName" },
                values: new object[] { new Guid("732c6a1b-ef2d-4471-acf8-3f9033ef5d57"), "Biblical", "BIBLICAL" });
        }
    }
}
