using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_education",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", nullable: false),
                    MinimumAge = table.Column<byte>(type: "tinyint", nullable: false),
                    YearsToComplete = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_education", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tb_education",
                columns: new[] { "Id", "Abbreviation", "MinimumAge", "Name", "Title", "YearsToComplete" },
                values: new object[,]
                {
                    { new Guid("418a24c4-5e3a-41be-aec7-5f534ca09587"), null, (byte)0, "less than primary school", null, (byte)0 },
                    { new Guid("cc1bffd3-8272-48ae-85f0-f1b7abeffe06"), null, (byte)6, "primary school", null, (byte)5 },
                    { new Guid("a24f28be-5288-438b-8710-5cdc180426a6"), null, (byte)15, "high school", null, (byte)4 },
                    { new Guid("04856059-d913-4615-b469-1f2ed2cf47f7"), null, (byte)17, "some college", null, (byte)3 },
                    { new Guid("0bb2708d-d637-42ef-a728-93b6eb9f4f32"), null, (byte)17, "bachelor's degree", "Bachelor", (byte)5 },
                    { new Guid("606ba2fc-e154-438f-a9de-7c2ad447886e"), null, (byte)22, "masters", "Master", (byte)2 },
                    { new Guid("814ef9bc-0e26-4154-9bd5-28476b909945"), "Dr.", (byte)22, "doctorate", "Doctor", (byte)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_education_Id",
                table: "tb_education",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_education_Name",
                table: "tb_education",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_education");
        }
    }
}
