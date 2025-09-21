using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndFeatspecialfeatprerequisite
{
    public int Id { get; set; }

    public int FeatId { get; set; }

    public int SpecialFeatPrerequisiteId { get; set; }

    public string Value1 { get; set; }

    public string Value2 { get; set; }

    public virtual DndFeat Feat { get; set; }

    public virtual DndSpecialfeatprerequisite SpecialFeatPrerequisite { get; set; }
}
