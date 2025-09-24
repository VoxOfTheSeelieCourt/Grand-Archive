using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrandArchive.Migrations
{
    /// <inheritdoc />
    public partial class truenameComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TruenameComponent",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TruenameComponent",
                table: "DndSpells");
        }
    }
}
