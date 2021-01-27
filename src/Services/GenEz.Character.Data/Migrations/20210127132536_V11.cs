using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_ethnicity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ethnicity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_religion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(15)", nullable: false),
                    NeutralText = table.Column<string>(type: "varchar(15)", nullable: false),
                    IsFictional = table.Column<bool>(type: "bit", nullable: false),
                    Adjective = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_religion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_social_class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_social_class", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tb_ethnicity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("418a24c4-5e3a-41be-aec7-5f534ca09587"), "caucasian" },
                    { new Guid("cc1bffd3-8272-48ae-85f0-f1b7abeffe06"), "mixed" },
                    { new Guid("a24f28be-5288-438b-8710-5cdc180426a6"), "latin" },
                    { new Guid("04856059-d913-4615-b469-1f2ed2cf47f7"), "african" },
                    { new Guid("0bb2708d-d637-42ef-a728-93b6eb9f4f32"), "middle eastern" },
                    { new Guid("606ba2fc-e154-438f-a9de-7c2ad447886e"), "amerindian" },
                    { new Guid("1cb3cdce-5aa9-49ab-b18d-4e9f225ccbbe"), "asian" },
                    { new Guid("a489ab07-7264-4c7d-881a-31504fc3a372"), "south asian" }
                });

            migrationBuilder.InsertData(
                table: "tb_religion",
                columns: new[] { "Id", "Adjective", "IsFictional", "Name", "NeutralText" },
                values: new object[,]
                {
                    { new Guid("5ddb4cc2-bea2-4766-a870-9abb852574dd"), "jew", false, "Judaism", "JUDAISM" },
                    { new Guid("be87573a-91f0-4228-bf66-4bc4382467b7"), "spiritist", false, "Spiritism", "SPIRITISM" },
                    { new Guid("a489ab07-7264-4c7d-881a-31504fc3a372"), "sikh", false, "Sikhism", "SIKHISM" },
                    { new Guid("1cb3cdce-5aa9-49ab-b18d-4e9f225ccbbe"), "taoist", false, "Taoism", "TAOISM" },
                    { new Guid("606ba2fc-e154-438f-a9de-7c2ad447886e"), "buddhist", false, "Buddhism", "BUDDHISM" },
                    { new Guid("a24f28be-5288-438b-8710-5cdc180426a6"), "agnostic", false, "Agnosticism", "AGNOSTICISM" },
                    { new Guid("04856059-d913-4615-b469-1f2ed2cf47f7"), "atheist", false, "Atheism", "ATHEISM" },
                    { new Guid("cc1bffd3-8272-48ae-85f0-f1b7abeffe06"), "muslim", false, "Islam", "ISLAM" },
                    { new Guid("418a24c4-5e3a-41be-aec7-5f534ca09587"), "christian", false, "Christianity", "CHRISTIANITY" },
                    { new Guid("0bb2708d-d637-42ef-a728-93b6eb9f4f32"), "hindu", false, "Hinduism", "HINDUISM" }
                });

            migrationBuilder.InsertData(
                table: "tb_social_class",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f7a540bd-ddc7-421d-a879-0e7974a5633b"), "middle" },
                    { new Guid("be0c73e9-2710-4676-9478-ee36a9e6f96e"), "working" },
                    { new Guid("81f4bb6e-3c6d-4ee4-a7c6-4f18be3dd478"), "upper" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ethnicity_Id",
                table: "tb_ethnicity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ethnicity_Name",
                table: "tb_ethnicity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_religion_Id",
                table: "tb_religion",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_religion_Name",
                table: "tb_religion",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_social_class_Id",
                table: "tb_social_class",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_social_class_Name",
                table: "tb_social_class",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ethnicity");

            migrationBuilder.DropTable(
                name: "tb_religion");

            migrationBuilder.DropTable(
                name: "tb_social_class");
        }
    }
}
