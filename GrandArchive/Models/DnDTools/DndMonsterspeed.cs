namespace GrandArchive.Models.DnDTools;

public partial class DndMonsterspeed
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public int TypeId { get; set; }

    public short Speed { get; set; }

    public virtual DndMonster Race { get; set; }

    public virtual DndRacespeedtype Type { get; set; }
}
