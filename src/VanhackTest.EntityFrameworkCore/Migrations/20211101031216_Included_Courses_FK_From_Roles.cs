using Microsoft.EntityFrameworkCore.Migrations;

namespace VanhackTest.Migrations
{
    public partial class Included_Courses_FK_From_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_RoleId",
                table: "Courses",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AbpRoles_RoleId",
                table: "Courses",
                column: "RoleId",
                principalTable: "AbpRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AbpRoles_RoleId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_RoleId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Courses");
        }
    }
}
