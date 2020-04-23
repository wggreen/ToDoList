

using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList3.Migrations
{
    public partial class ToDoItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "To Do" });

            migrationBuilder.InsertData(
                table: "ToDoStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "In Progress" });

            migrationBuilder.InsertData(
                table: "ToDoStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4, "Done" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDoStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ToDoStatuses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
