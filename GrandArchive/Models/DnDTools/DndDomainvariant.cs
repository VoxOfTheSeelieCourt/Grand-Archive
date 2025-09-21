using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndDomainvariant
{
    public int Id { get; set; }

    public int DomainId { get; set; }

    public int RulebookId { get; set; }

    public short? Page { get; set; }

    public string Requirement { get; set; }

    public string GrantedPower { get; set; }

    public string GrantedPowerHtml { get; set; }

    public string GrantedPowerType { get; set; }

    public string DeitiesText { get; set; }

    public virtual ICollection<DndDomainvariantDeity> DndDomainvariantDeities { get; set; } = new List<DndDomainvariantDeity>();

    public virtual ICollection<DndDomainvariantOtherDeity> DndDomainvariantOtherDeities { get; set; } = new List<DndDomainvariantOtherDeity>();

    public virtual DndDomain Domain { get; set; }

    public virtual DndRulebook Rulebook { get; set; }
}
