using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndFeat
{
    public int Id { get; set; }

    public int RulebookId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Benefit { get; set; }

    public string Special { get; set; }

    public string Normal { get; set; }

    public short? Page { get; set; }

    public string Slug { get; set; }

    public string DescriptionHtml { get; set; }

    public string BenefitHtml { get; set; }

    public string SpecialHtml { get; set; }

    public string NormalHtml { get; set; }

    public virtual ICollection<DndCharacterclassvariantrequiresfeat> DndCharacterclassvariantrequiresfeats { get; set; } = new List<DndCharacterclassvariantrequiresfeat>();

    public virtual ICollection<DndFeatFeatCategory> DndFeatFeatCategories { get; set; } = new List<DndFeatFeatCategory>();

    public virtual ICollection<DndFeatrequiresfeat> DndFeatrequiresfeatRequiredFeats { get; set; } = new List<DndFeatrequiresfeat>();

    public virtual ICollection<DndFeatrequiresfeat> DndFeatrequiresfeatSourceFeats { get; set; } = new List<DndFeatrequiresfeat>();

    public virtual ICollection<DndFeatrequiresskill> DndFeatrequiresskills { get; set; } = new List<DndFeatrequiresskill>();

    public virtual ICollection<DndFeatspecialfeatprerequisite> DndFeatspecialfeatprerequisites { get; set; } = new List<DndFeatspecialfeatprerequisite>();

    public virtual ICollection<DndItemRequiredFeat> DndItemRequiredFeats { get; set; } = new List<DndItemRequiredFeat>();

    public virtual ICollection<DndMonsterhasfeat> DndMonsterhasfeats { get; set; } = new List<DndMonsterhasfeat>();

    public virtual ICollection<DndTextfeatprerequisite> DndTextfeatprerequisites { get; set; } = new List<DndTextfeatprerequisite>();

    public virtual DndRulebook Rulebook { get; set; }
}
