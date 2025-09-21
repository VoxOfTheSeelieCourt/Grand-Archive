namespace GrandArchive.Models.DnDTools;

public partial class DndRule
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public string Body { get; set; }

    public string BodyHtml { get; set; }

    public int RulebookId { get; set; }

    public short? PageFrom { get; set; }

    public short? PageTo { get; set; }

    public virtual DndRulebook Rulebook { get; set; }
}
