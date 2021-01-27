using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_person_name_Name",
                table: "tb_person_name");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "tb_person_name");

            migrationBuilder.DropColumn(
                name: "NeutralName",
                table: "tb_person_name");

            migrationBuilder.CreateTable(
                name: "tb_spelling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "varchar(30)", nullable: false),
                    NeutralText = table.Column<string>(type: "varchar(30)", nullable: false),
                    PersonNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_spelling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_spelling_tb_person_name_PersonNameId",
                        column: x => x.PersonNameId,
                        principalTable: "tb_person_name",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_spelling_Id",
                table: "tb_spelling",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_spelling_PersonNameId",
                table: "tb_spelling",
                column: "PersonNameId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_spelling_Text",
                table: "tb_spelling",
                column: "Text",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_spelling");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tb_person_name",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NeutralName",
                table: "tb_person_name",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tb_person_name_Name",
                table: "tb_person_name",
                column: "Name",
                unique: true);
        }
    }
}
