using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndCharacterclassvariant
{
    public int Id { get; set; }

    public int CharacterClassId { get; set; }

    public int RulebookId { get; set; }

    public short? Page { get; set; }

    public string Advancement { get; set; }

    public string AdvancementHtml { get; set; }

    public string ClassFeatures { get; set; }

    public short? SkillPoints { get; set; }

    public short? HitDie { get; set; }

    public string Alignment { get; set; }

    public string ClassFeaturesHtml { get; set; }

    public string Requirements { get; set; }

    public string RequirementsHtml { get; set; }

    public short? RequiredBab { get; set; }

    public string StartingGold { get; set; }

    public virtual DndCharacterclass CharacterClass { get; set; }

    public virtual ICollection<DndCharacterclassvariantClassSkill> DndCharacterclassvariantClassSkills { get; set; } = new List<DndCharacterclassvariantClassSkill>();

    public virtual ICollection<DndCharacterclassvariantrequiresfeat> DndCharacterclassvariantrequiresfeats { get; set; } = new List<DndCharacterclassvariantrequiresfeat>();

    public virtual ICollection<DndCharacterclassvariantrequiresrace> DndCharacterclassvariantrequiresraces { get; set; } = new List<DndCharacterclassvariantrequiresrace>();

    public virtual ICollection<DndCharacterclassvariantrequiresskill> DndCharacterclassvariantrequiresskills { get; set; } = new List<DndCharacterclassvariantrequiresskill>();

    public virtual DndRulebook Rulebook { get; set; }
}
