namespace GrandArchive.Models.DnDTools;

public partial class DndSpelldomainlevel
{
    public int Id { get; set; }

    public int DomainId { get; set; }

    public int SpellId { get; set; }

    public short Level { get; set; }

    public string Extra { get; set; }

    public virtual DndDomain Domain { get; set; }

    public virtual DndSpell Spell { get; set; }
}
