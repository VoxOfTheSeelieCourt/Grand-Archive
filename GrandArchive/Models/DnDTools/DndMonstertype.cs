using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndMonstertype
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public virtual ICollection<DndMonster> DndMonsters { get; set; } = new List<DndMonster>();
}
