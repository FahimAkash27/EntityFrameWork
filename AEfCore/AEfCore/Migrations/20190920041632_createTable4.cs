using Microsoft.EntityFrameworkCore.Migrations;

namespace AEfCore.Migrations
{
    public partial class createTable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks",
                columns: new[] { "StudentId", "BookInfoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks",
                columns: new[] { "StudentId", "BookInfoId", "Id" });
        }
    }
}
