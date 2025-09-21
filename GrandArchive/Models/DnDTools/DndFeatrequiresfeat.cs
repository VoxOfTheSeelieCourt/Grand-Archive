using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndFeatrequiresfeat
{
    public int Id { get; set; }

    public int SourceFeatId { get; set; }

    public int RequiredFeatId { get; set; }

    public string AdditionalText { get; set; }

    public virtual DndFeat RequiredFeat { get; set; }

    public virtual DndFeat SourceFeat { get; set; }
}
