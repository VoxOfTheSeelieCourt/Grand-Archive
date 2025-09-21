using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndLanguage
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public string Description { get; set; }

    public string DescriptionHtml { get; set; }

    public virtual ICollection<DndRaceAutomaticLanguage> DndRaceAutomaticLanguages { get; set; } = new List<DndRaceAutomaticLanguage>();

    public virtual ICollection<DndRaceBonusLanguage> DndRaceBonusLanguages { get; set; } = new List<DndRaceBonusLanguage>();
}
