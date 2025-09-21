using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndSkillvariant
{
    public int Id { get; set; }

    public int SkillId { get; set; }

    public int RulebookId { get; set; }

    public short? Page { get; set; }

    public string Description { get; set; }

    public string Check { get; set; }

    public string Action { get; set; }

    public string TryAgain { get; set; }

    public string Special { get; set; }

    public string Synergy { get; set; }

    public string Untrained { get; set; }

    public string DescriptionHtml { get; set; }

    public string CheckHtml { get; set; }

    public string ActionHtml { get; set; }

    public string TryAgainHtml { get; set; }

    public string SpecialHtml { get; set; }

    public string SynergyHtml { get; set; }

    public string UntrainedHtml { get; set; }

    public string Restriction { get; set; }

    public string RestrictionHtml { get; set; }

    public virtual DndRulebook Rulebook { get; set; }

    public virtual DndSkill Skill { get; set; }
}
