using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrandArchive.Migrations
{
    /// <inheritdoc />
    public partial class abstinceComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AbstinenceComponent",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasAbstinenceComponent",
                table: "DndSpells",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbstinenceComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "HasAbstinenceComponent",
                table: "DndSpells");
        }
    }
}
