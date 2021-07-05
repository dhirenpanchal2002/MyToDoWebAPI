using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoAppWebAPI.Migrations
{
    public partial class UserToDoItemRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tbl_ToDoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ToDoItems_UserId",
                table: "tbl_ToDoItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ToDoItems_tbl_Users_UserId",
                table: "tbl_ToDoItems",
                column: "UserId",
                principalTable: "tbl_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ToDoItems_tbl_Users_UserId",
                table: "tbl_ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ToDoItems_UserId",
                table: "tbl_ToDoItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tbl_ToDoItems");
        }
    }
}
