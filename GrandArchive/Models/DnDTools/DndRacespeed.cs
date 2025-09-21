using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndRacespeed
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public short Speed { get; set; }

    public int RaceId { get; set; }

    public virtual DndRace Race { get; set; }

    public virtual DndRacespeedtype Type { get; set; }
}
