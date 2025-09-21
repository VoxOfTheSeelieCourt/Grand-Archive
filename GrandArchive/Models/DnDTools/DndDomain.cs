using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndDomain
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public virtual ICollection<DndDomainvariant> DndDomainvariants { get; set; } = new List<DndDomainvariant>();

    public virtual ICollection<DndSpelldomainlevel> DndSpelldomainlevels { get; set; } = new List<DndSpelldomainlevel>();
}
