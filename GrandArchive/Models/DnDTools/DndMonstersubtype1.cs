using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndMonstersubtype1
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public virtual ICollection<DndMonsterSubtype> DndMonsterSubtypes { get; set; } = new List<DndMonsterSubtype>();
}
