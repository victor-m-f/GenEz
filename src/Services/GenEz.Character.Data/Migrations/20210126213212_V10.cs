using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_characteristic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    NeutralName = table.Column<string>(type: "varchar(20)", nullable: false),
                    IsPositive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_characteristic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_opposed_characteristic",
                columns: table => new
                {
                    CharacteristicsOpposedFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacteristicsOpposedToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_opposed_characteristic", x => new { x.CharacteristicsOpposedFromId, x.CharacteristicsOpposedToId });
                    table.ForeignKey(
                        name: "FK_tb_opposed_characteristic_tb_characteristic_CharacteristicsOpposedFromId",
                        column: x => x.CharacteristicsOpposedFromId,
                        principalTable: "tb_characteristic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_opposed_characteristic_tb_characteristic_CharacteristicsOpposedToId",
                        column: x => x.CharacteristicsOpposedToId,
                        principalTable: "tb_characteristic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_characteristic_Id",
                table: "tb_characteristic",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_characteristic_NeutralName",
                table: "tb_characteristic",
                column: "NeutralName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_opposed_characteristic_CharacteristicsOpposedToId",
                table: "tb_opposed_characteristic",
                column: "CharacteristicsOpposedToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_opposed_characteristic");

            migrationBuilder.DropTable(
                name: "tb_characteristic");
        }
    }
}
