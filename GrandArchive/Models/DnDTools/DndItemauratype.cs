using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndItemauratype
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public virtual ICollection<DndItem> DndItems { get; set; } = new List<DndItem>();
}
