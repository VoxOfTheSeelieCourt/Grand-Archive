using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndRacetype
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public short HitDieSize { get; set; }

    public string BaseAttackType { get; set; }

    public string BaseFortSaveType { get; set; }

    public string BaseReflexSaveType { get; set; }

    public string BaseWillSaveType { get; set; }

    public virtual ICollection<DndRace> DndRaces { get; set; } = new List<DndRace>();
}
