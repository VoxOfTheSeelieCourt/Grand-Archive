using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndRacesize
{
    public int Id { get; set; }

    public string Name { get; set; }

    public short Order { get; set; }

    public string Description { get; set; }

    public virtual ICollection<DndMonster> DndMonsters { get; set; } = new List<DndMonster>();

    public virtual ICollection<DndRace> DndRaces { get; set; } = new List<DndRace>();
}
