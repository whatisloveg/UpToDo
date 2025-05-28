using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpToDo.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeleteEstimatedTimeForSubtask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedTime",
                table: "Subtasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedTime",
                table: "Subtasks",
                type: "numeric",
                nullable: true);
        }
    }
}
