using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndItemAuraSchool
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int SpellschoolId { get; set; }

    public virtual DndItem Item { get; set; }

    public virtual DndSpellschool Spellschool { get; set; }
}
