namespace GrandArchive.Models.DnDTools;

public partial class DndItemRequiredFeat
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int FeatId { get; set; }

    public virtual DndFeat Feat { get; set; }

    public virtual DndItem Item { get; set; }
}
