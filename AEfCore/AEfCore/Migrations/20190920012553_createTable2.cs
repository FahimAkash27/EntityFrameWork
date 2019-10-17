using Microsoft.EntityFrameworkCore.Migrations;

namespace AEfCore.Migrations
{
    public partial class createTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks",
                columns: new[] { "StudentId", "BookInfoId", "Returned" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks",
                columns: new[] { "StudentId", "BookInfoId" });
        }
    }
}
