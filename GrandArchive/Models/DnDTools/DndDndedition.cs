using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndDndedition
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string System { get; set; }

    public string Slug { get; set; }

    public byte Core { get; set; }

    public virtual ICollection<DndRulebook> DndRulebooks { get; set; } = new List<DndRulebook>();
}
