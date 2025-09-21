using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndSpecialfeatprerequisite
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string PrintFormat { get; set; }

    public virtual ICollection<DndFeatspecialfeatprerequisite> DndFeatspecialfeatprerequisites { get; set; } = new List<DndFeatspecialfeatprerequisite>();
}
