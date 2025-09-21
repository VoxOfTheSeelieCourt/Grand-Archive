using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndCharacterclass
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public byte Prestige { get; set; }

    public string ShortDescription { get; set; }

    public string ShortDescriptionHtml { get; set; }

    public virtual ICollection<DndCharacterclassvariant> DndCharacterclassvariants { get; set; } = new List<DndCharacterclassvariant>();

    public virtual ICollection<DndRacefavoredcharacterclass> DndRacefavoredcharacterclasses { get; set; } = new List<DndRacefavoredcharacterclass>();

    public virtual ICollection<DndSpellclasslevel> DndSpellclasslevels { get; set; } = new List<DndSpellclasslevel>();
}
