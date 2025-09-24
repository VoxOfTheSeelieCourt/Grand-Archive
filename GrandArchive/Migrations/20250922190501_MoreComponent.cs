using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrandArchive.Migrations
{
    /// <inheritdoc />
    public partial class MoreComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColdfireComponent",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiseaseComponent",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DragonmarkComponent",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DrugComponent",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasColdfireComponent",
                table: "DndSpells",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasDiseaseComponent",
                table: "DndSpells",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasDragonmarkComponent",
                table: "DndSpells",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasDrugComponent",
                table: "DndSpells",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasLocationComponent",
                table: "DndSpells",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMindsetComponent",
                table: "DndSpells",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSacrificeComponent",
                table: "DndSpells",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LocationComponent",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MindsetComponent",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SacrificeComponent",
                table: "DndSpells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColdfireComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "DiseaseComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "DragonmarkComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "DrugComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "HasColdfireComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "HasDiseaseComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "HasDragonmarkComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "HasDrugComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "HasLocationComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "HasMindsetComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "HasSacrificeComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "LocationComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "MindsetComponent",
                table: "DndSpells");

            migrationBuilder.DropColumn(
                name: "SacrificeComponent",
                table: "DndSpells");
        }
    }
}
