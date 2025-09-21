using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndRacespeedtype
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Extra { get; set; }

    public virtual ICollection<DndMonsterspeed> DndMonsterspeeds { get; set; } = new List<DndMonsterspeed>();

    public virtual ICollection<DndRacespeed> DndRacespeeds { get; set; } = new List<DndRacespeed>();
}
