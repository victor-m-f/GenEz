using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_sexual_orientation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(11)", nullable: false),
                    PreferOppositeSex = table.Column<bool>(type: "bit", nullable: true),
                    PreferFemale = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sexual_orientation", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tb_sexual_orientation",
                columns: new[] { "Id", "Name", "PreferFemale", "PreferOppositeSex" },
                values: new object[,]
                {
                    { new Guid("418a24c4-5e3a-41be-aec7-5f534ca09587"), "androsexual", false, null },
                    { new Guid("cc1bffd3-8272-48ae-85f0-f1b7abeffe06"), "gynesexual", true, null },
                    { new Guid("a24f28be-5288-438b-8710-5cdc180426a6"), "asexual", null, null },
                    { new Guid("04856059-d913-4615-b469-1f2ed2cf47f7"), "autosexual", null, null },
                    { new Guid("0bb2708d-d637-42ef-a728-93b6eb9f4f32"), "bicurious", null, null },
                    { new Guid("606ba2fc-e154-438f-a9de-7c2ad447886e"), "bisexual", null, null },
                    { new Guid("1cb3cdce-5aa9-49ab-b18d-4e9f225ccbbe"), "gay", null, false },
                    { new Guid("a489ab07-7264-4c7d-881a-31504fc3a372"), "straight", null, true },
                    { new Guid("d7a9cab4-703d-47f7-92b3-87b3281c2ed0"), "pansexual", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_sexual_orientation_Id",
                table: "tb_sexual_orientation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sexual_orientation_Name",
                table: "tb_sexual_orientation",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_sexual_orientation");
        }
    }
}
