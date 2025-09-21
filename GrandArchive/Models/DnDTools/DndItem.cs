using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndItem
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public int RulebookId { get; set; }

    public short? Page { get; set; }

    public int? PriceGp { get; set; }

    public short? PriceBonus { get; set; }

    public short? ItemLevel { get; set; }

    public int? BodySlotId { get; set; }

    public short? CasterLevel { get; set; }

    public int? AuraId { get; set; }

    public string AuraDc { get; set; }

    public int? ActivationId { get; set; }

    public double? Weight { get; set; }

    public string VisualDescription { get; set; }

    public string Description { get; set; }

    public string DescriptionHtml { get; set; }

    public string Type { get; set; }

    public int? PropertyId { get; set; }

    public string CostToCreate { get; set; }

    public int? SynergyPrerequisiteId { get; set; }

    public string RequiredExtra { get; set; }

    public virtual DndItemactivationtype Activation { get; set; }

    public virtual DndItemauratype Aura { get; set; }

    public virtual DndItemslot BodySlot { get; set; }

    public virtual ICollection<DndDeity> DndDeities { get; set; } = new List<DndDeity>();

    public virtual ICollection<DndItemAuraSchool> DndItemAuraSchools { get; set; } = new List<DndItemAuraSchool>();

    public virtual ICollection<DndItemRequiredFeat> DndItemRequiredFeats { get; set; } = new List<DndItemRequiredFeat>();

    public virtual ICollection<DndItemRequiredSpell> DndItemRequiredSpells { get; set; } = new List<DndItemRequiredSpell>();

    public virtual ICollection<DndItem> InverseSynergyPrerequisite { get; set; } = new List<DndItem>();

    public virtual DndItemproperty Property { get; set; }

    public virtual DndRulebook Rulebook { get; set; }

    public virtual DndItem SynergyPrerequisite { get; set; }
}
