using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndDomainvariantOtherDeity
{
    public int Id { get; set; }

    public int DomainvariantId { get; set; }

    public int DeityId { get; set; }

    public virtual DndDeity Deity { get; set; }

    public virtual DndDomainvariant Domainvariant { get; set; }
}
