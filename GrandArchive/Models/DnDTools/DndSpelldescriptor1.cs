using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndSpelldescriptor1
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public virtual ICollection<DndSpellDescriptor> DndSpellDescriptors { get; set; } = new List<DndSpellDescriptor>();
}
