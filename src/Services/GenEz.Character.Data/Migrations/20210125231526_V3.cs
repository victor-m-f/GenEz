using Microsoft.EntityFrameworkCore.Migrations;

namespace GenEz.Character.Data.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_person_name_Name",
                table: "tb_person_name",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_name_origin_Name",
                table: "tb_name_origin",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_person_name_Name",
                table: "tb_person_name");

            migrationBuilder.DropIndex(
                name: "IX_tb_name_origin_Name",
                table: "tb_name_origin");
        }
    }
}
