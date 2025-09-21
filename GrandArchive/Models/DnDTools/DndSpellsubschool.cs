using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndSpellsubschool
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public virtual ICollection<DndSpell> DndSpells { get; set; } = new List<DndSpell>();
}
