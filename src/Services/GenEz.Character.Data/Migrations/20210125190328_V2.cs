using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NameOriginPersonName_tb_name_origin_NameOriginsId",
                table: "NameOriginPersonName");

            migrationBuilder.DropForeignKey(
                name: "FK_NameOriginPersonName_tb_person_name_PersonNamesId",
                table: "NameOriginPersonName");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_person_name_tb_person_name_PersonNameId",
                table: "tb_person_name");

            migrationBuilder.DropIndex(
                name: "IX_tb_person_name_PersonNameId",
                table: "tb_person_name");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NameOriginPersonName",
                table: "NameOriginPersonName");

            migrationBuilder.DropColumn(
                name: "PersonNameId",
                table: "tb_person_name");

            migrationBuilder.RenameTable(
                name: "NameOriginPersonName",
                newName: "tb_person_name_origin");

            migrationBuilder.RenameIndex(
                name: "IX_NameOriginPersonName_PersonNamesId",
                table: "tb_person_name_origin",
                newName: "IX_tb_person_name_origin_PersonNamesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_person_name_origin",
                table: "tb_person_name_origin",
                columns: new[] { "NameOriginsId", "PersonNamesId" });

            migrationBuilder.CreateTable(
                name: "tb_related_person_name",
                columns: table => new
                {
                    RelatedPersonNamesFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedPersonNamesToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_related_person_name", x => new { x.RelatedPersonNamesFromId, x.RelatedPersonNamesToId });
                    table.ForeignKey(
                        name: "FK_tb_related_person_name_tb_person_name_RelatedPersonNamesFromId",
                        column: x => x.RelatedPersonNamesFromId,
                        principalTable: "tb_person_name",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_related_person_name_tb_person_name_RelatedPersonNamesToId",
                        column: x => x.RelatedPersonNamesToId,
                        principalTable: "tb_person_name",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_related_person_name_RelatedPersonNamesToId",
                table: "tb_related_person_name",
                column: "RelatedPersonNamesToId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_person_name_origin_tb_name_origin_NameOriginsId",
                table: "tb_person_name_origin",
                column: "NameOriginsId",
                principalTable: "tb_name_origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_person_name_origin_tb_person_name_PersonNamesId",
                table: "tb_person_name_origin",
                column: "PersonNamesId",
                principalTable: "tb_person_name",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_person_name_origin_tb_name_origin_NameOriginsId",
                table: "tb_person_name_origin");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_person_name_origin_tb_person_name_PersonNamesId",
                table: "tb_person_name_origin");

            migrationBuilder.DropTable(
                name: "tb_related_person_name");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_person_name_origin",
                table: "tb_person_name_origin");

            migrationBuilder.RenameTable(
                name: "tb_person_name_origin",
                newName: "NameOriginPersonName");

            migrationBuilder.RenameIndex(
                name: "IX_tb_person_name_origin_PersonNamesId",
                table: "NameOriginPersonName",
                newName: "IX_NameOriginPersonName_PersonNamesId");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonNameId",
                table: "tb_person_name",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NameOriginPersonName",
                table: "NameOriginPersonName",
                columns: new[] { "NameOriginsId", "PersonNamesId" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_person_name_PersonNameId",
                table: "tb_person_name",
                column: "PersonNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_NameOriginPersonName_tb_name_origin_NameOriginsId",
                table: "NameOriginPersonName",
                column: "NameOriginsId",
                principalTable: "tb_name_origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NameOriginPersonName_tb_person_name_PersonNamesId",
                table: "NameOriginPersonName",
                column: "PersonNamesId",
                principalTable: "tb_person_name",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_person_name_tb_person_name_PersonNameId",
                table: "tb_person_name",
                column: "PersonNameId",
                principalTable: "tb_person_name",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
