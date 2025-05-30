using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpToDo.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTagsToUserLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTaskTag_Tag_TagId",
                table: "ToDoTaskTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTaskTag_ToDoTasks_ToDoTaskId",
                table: "ToDoTaskTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoTaskTag",
                table: "ToDoTaskTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "ToDoTaskTag",
                newName: "ToDoTaskTags");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoTaskTag_TagId",
                table: "ToDoTaskTags",
                newName: "IX_ToDoTaskTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_Name",
                table: "Tags",
                newName: "IX_Tags_Name");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Tags",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Tags",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoTaskTags",
                table: "ToDoTaskTags",
                columns: new[] { "ToDoTaskId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId",
                table: "Tags",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId1",
                table: "Tags",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_UserId",
                table: "Tags",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_UserId1",
                table: "Tags",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTaskTags_Tags_TagId",
                table: "ToDoTaskTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTaskTags_ToDoTasks_ToDoTaskId",
                table: "ToDoTaskTags",
                column: "ToDoTaskId",
                principalTable: "ToDoTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_UserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_UserId1",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTaskTags_Tags_TagId",
                table: "ToDoTaskTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTaskTags_ToDoTasks_ToDoTaskId",
                table: "ToDoTaskTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoTaskTags",
                table: "ToDoTaskTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_UserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_UserId1",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "ToDoTaskTags",
                newName: "ToDoTaskTag");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoTaskTags_TagId",
                table: "ToDoTaskTag",
                newName: "IX_ToDoTaskTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_Name",
                table: "Tag",
                newName: "IX_Tag_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoTaskTag",
                table: "ToDoTaskTag",
                columns: new[] { "ToDoTaskId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTaskTag_Tag_TagId",
                table: "ToDoTaskTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTaskTag_ToDoTasks_ToDoTaskId",
                table: "ToDoTaskTag",
                column: "ToDoTaskId",
                principalTable: "ToDoTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
