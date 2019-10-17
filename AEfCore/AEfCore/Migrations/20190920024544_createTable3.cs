using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AEfCore.Migrations
{
    public partial class createTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentBooks",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks",
                columns: new[] { "StudentId", "BookInfoId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks",
                columns: new[] { "StudentId", "BookInfoId", "Returned" });
        }
    }
}
