namespace GrandArchive.Models.DnDTools;

public partial class DndItemRequiredSpell
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int SpellId { get; set; }

    public virtual DndItem Item { get; set; }

    public virtual DndSpell Spell { get; set; }
}
