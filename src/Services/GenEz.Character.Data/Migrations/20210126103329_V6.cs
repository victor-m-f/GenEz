using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "tb_person_name");

            migrationBuilder.CreateTable(
                name: "tb_nickname",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nickname", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_person_name_nickname",
                columns: table => new
                {
                    NicknamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonNamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_person_name_nickname", x => new { x.NicknamesId, x.PersonNamesId });
                    table.ForeignKey(
                        name: "FK_tb_person_name_nickname_tb_nickname_NicknamesId",
                        column: x => x.NicknamesId,
                        principalTable: "tb_nickname",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_person_name_nickname_tb_person_name_PersonNamesId",
                        column: x => x.PersonNamesId,
                        principalTable: "tb_person_name",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_nickname_Id",
                table: "tb_nickname",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nickname_Name",
                table: "tb_nickname",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_person_name_nickname_PersonNamesId",
                table: "tb_person_name_nickname",
                column: "PersonNamesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_person_name_nickname");

            migrationBuilder.DropTable(
                name: "tb_nickname");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "tb_person_name",
                type: "varchar(30)",
                nullable: true);
        }
    }
}
