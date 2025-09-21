using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndDeity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public string Description { get; set; }

    public string DescriptionHtml { get; set; }

    public string Alignment { get; set; }

    public int? FavoredWeaponId { get; set; }

    public virtual ICollection<DndDomainvariantDeity> DndDomainvariantDeities { get; set; } = new List<DndDomainvariantDeity>();

    public virtual ICollection<DndDomainvariantOtherDeity> DndDomainvariantOtherDeities { get; set; } = new List<DndDomainvariantOtherDeity>();

    public virtual DndItem FavoredWeapon { get; set; }
}
