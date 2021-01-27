using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_name_origin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_name_origin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_person_name",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    NeutralName = table.Column<string>(type: "varchar(30)", nullable: false),
                    Nickname = table.Column<string>(type: "varchar(30)", nullable: true),
                    IsFirstName = table.Column<bool>(type: "bit", nullable: false),
                    IsSurname = table.Column<bool>(type: "bit", nullable: false),
                    IsFemale = table.Column<bool>(type: "bit", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    PersonNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_person_name", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_person_name_tb_person_name_PersonNameId",
                        column: x => x.PersonNameId,
                        principalTable: "tb_person_name",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NameOriginPersonName",
                columns: table => new
                {
                    NameOriginsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonNamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameOriginPersonName", x => new { x.NameOriginsId, x.PersonNamesId });
                    table.ForeignKey(
                        name: "FK_NameOriginPersonName_tb_name_origin_NameOriginsId",
                        column: x => x.NameOriginsId,
                        principalTable: "tb_name_origin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NameOriginPersonName_tb_person_name_PersonNamesId",
                        column: x => x.PersonNamesId,
                        principalTable: "tb_person_name",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NameOriginPersonName_PersonNamesId",
                table: "NameOriginPersonName",
                column: "PersonNamesId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_name_origin_Id",
                table: "tb_name_origin",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_person_name_Id",
                table: "tb_person_name",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_person_name_PersonNameId",
                table: "tb_person_name",
                column: "PersonNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NameOriginPersonName");

            migrationBuilder.DropTable(
                name: "tb_name_origin");

            migrationBuilder.DropTable(
                name: "tb_person_name");
        }
    }
}
