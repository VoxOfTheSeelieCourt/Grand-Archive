using System;

namespace GrandArchive.Models.DnDTools;

public partial class DndNewsentry
{
    public int Id { get; set; }

    public DateOnly Published { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public string BodyHtml { get; set; }

    public byte Enabled { get; set; }
}
