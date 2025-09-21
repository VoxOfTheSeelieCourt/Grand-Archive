namespace GrandArchive.Models.DnDTools;

public partial class DndRacefavoredcharacterclass
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public int CharacterClassId { get; set; }

    public string Extra { get; set; }

    public virtual DndCharacterclass CharacterClass { get; set; }

    public virtual DndRace Race { get; set; }
}
