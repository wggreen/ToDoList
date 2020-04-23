using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList3.Migrations
{
    public partial class PleaseWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItems_AspNetUsers_ApplicationUserId1",
                table: "ToDoListItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoListItems_ApplicationUserId1",
                table: "ToDoListItems");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ToDoListItems");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ToDoListItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ToDoListItemAddViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    ToDoStatusId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListItemAddViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoListItemAddViewModel_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoListItemAddViewModel_ToDoStatuses_ToDoStatusId",
                        column: x => x.ToDoStatusId,
                        principalTable: "ToDoStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListItems_ApplicationUserId",
                table: "ToDoListItems",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListItemAddViewModel_ApplicationUserId",
                table: "ToDoListItemAddViewModel",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListItemAddViewModel_ToDoStatusId",
                table: "ToDoListItemAddViewModel",
                column: "ToDoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItems_AspNetUsers_ApplicationUserId",
                table: "ToDoListItems",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItems_AspNetUsers_ApplicationUserId",
                table: "ToDoListItems");

            migrationBuilder.DropTable(
                name: "ToDoListItemAddViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ToDoListItems_ApplicationUserId",
                table: "ToDoListItems");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ToDoListItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ToDoListItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListItems_ApplicationUserId1",
                table: "ToDoListItems",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItems_AspNetUsers_ApplicationUserId1",
                table: "ToDoListItems",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
