namespace GrandArchive.Models.DnDTools;

public partial class DndTextfeatprerequisite
{
    public int Id { get; set; }

    public string Text { get; set; }

    public int FeatId { get; set; }

    public virtual DndFeat Feat { get; set; }
}
