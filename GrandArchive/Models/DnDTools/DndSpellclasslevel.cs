namespace GrandArchive.Models.DnDTools;

public partial class DndSpellclasslevel
{
    public int Id { get; set; }

    public int CharacterClassId { get; set; }

    public int SpellId { get; set; }

    public short Level { get; set; }

    public string Extra { get; set; }

    public virtual DndCharacterclass CharacterClass { get; set; }

    public virtual DndSpell Spell { get; set; }
}
