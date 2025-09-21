using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndFeatFeatCategory
{
    public int Id { get; set; }

    public int FeatId { get; set; }

    public int FeatcategoryId { get; set; }

    public virtual DndFeat Feat { get; set; }

    public virtual DndFeatcategory Featcategory { get; set; }
}
