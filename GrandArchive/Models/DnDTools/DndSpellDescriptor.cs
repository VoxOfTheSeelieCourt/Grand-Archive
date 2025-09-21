using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndSpellDescriptor
{
    public int Id { get; set; }

    public int SpellId { get; set; }

    public int SpelldescriptorId { get; set; }

    public virtual DndSpell Spell { get; set; }

    public virtual DndSpelldescriptor1 Spelldescriptor { get; set; }
}
