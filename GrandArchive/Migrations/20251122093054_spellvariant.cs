using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrandArchive.Migrations
{
    /// <inheritdoc />
    public partial class spellvariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VariantOfSpellId",
                table: "DndSpells",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DndSpells_VariantOfSpellId",
                table: "DndSpells",
                column: "VariantOfSpellId");

            migrationBuilder.AddForeignKey(
                name: "FK_DndSpells_DndSpells_VariantOfSpellId",
                table: "DndSpells",
                column: "VariantOfSpellId",
                principalTable: "DndSpells",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DndSpells_DndSpells_VariantOfSpellId",
                table: "DndSpells");

            migrationBuilder.DropIndex(
                name: "IX_DndSpells_VariantOfSpellId",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "VariantOfSpellId",
                table: "DndSpells");
        }
    }
}
