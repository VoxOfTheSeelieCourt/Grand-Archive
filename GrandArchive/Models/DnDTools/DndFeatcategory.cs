using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndFeatcategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public virtual ICollection<DndFeatFeatCategory> DndFeatFeatCategories { get; set; } = new List<DndFeatFeatCategory>();
}
