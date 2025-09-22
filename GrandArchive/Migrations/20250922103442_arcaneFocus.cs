using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrandArchive.Migrations
{
    /// <inheritdoc />
    public partial class arcaneFocus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArcaneFocus",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArcaneFocus",
                table: "DndSpells");
        }
    }
}
