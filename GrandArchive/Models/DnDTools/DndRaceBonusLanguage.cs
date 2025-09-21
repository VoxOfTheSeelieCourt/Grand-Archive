namespace GrandArchive.Models.DnDTools;

public partial class DndRaceBonusLanguage
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public int LanguageId { get; set; }

    public virtual DndLanguage Language { get; set; }

    public virtual DndRace Race { get; set; }
}
