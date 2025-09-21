using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrandArchive.Migrations
{
    /// <inheritdoc />
    public partial class spells : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DndSpells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RulebookPage = table.Column<int>(type: "INTEGER", nullable: true),
                    School = table.Column<int>(type: "INTEGER", nullable: false),
                    SubSchool = table.Column<int>(type: "INTEGER", nullable: false),
                    Descriptor = table.Column<long>(type: "INTEGER", nullable: false),
                    HasVerbalComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasSomaticComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasMaterialComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaterialComponent = table.Column<string>(type: "TEXT", nullable: false),
                    HasArcaneFocus = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasDivineFocus = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasExperienceComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExperienceComponent = table.Column<string>(type: "TEXT", nullable: false),
                    HasBreathComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasTruenameComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasCorruptionComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    CorruptionComponent = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraComponent = table.Column<string>(type: "TEXT", nullable: false),
                    CastingTime = table.Column<string>(type: "TEXT", nullable: false),
                    Range = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomRangeText = table.Column<string>(type: "TEXT", nullable: false),
                    Target = table.Column<string>(type: "TEXT", nullable: false),
                    Effect = table.Column<string>(type: "TEXT", nullable: false),
                    Area = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: false),
                    SavingThrow = table.Column<string>(type: "TEXT", nullable: false),
                    SpellResistance = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionShort = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    RulebookId = table.Column<int>(type: "INTEGER", nullable: false),
                    MigrationId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndSpells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DndSpells_DndRulebooks_RulebookId",
                        column: x => x.RulebookId,
                        principalTable: "DndRulebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DndSpells_RulebookId",
                table: "DndSpells",
                column: "RulebookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DndSpells");
        }
    }
}
