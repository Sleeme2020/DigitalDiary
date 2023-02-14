using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalDiary.Behavior.Migrations
{
    /// <inheritdoc />
    public partial class updtypeuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeUser",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeUser",
                table: "Users");
        }
    }
}
