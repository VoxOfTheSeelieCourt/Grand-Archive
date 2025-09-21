using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndCharacterclassvariantrequiresrace
{
    public int Id { get; set; }

    public int CharacterClassVariantId { get; set; }

    public int RaceId { get; set; }

    public string Extra { get; set; }

    public string TextBefore { get; set; }

    public string TextAfter { get; set; }

    public byte RemoveComma { get; set; }

    public virtual DndCharacterclassvariant CharacterClassVariant { get; set; }

    public virtual DndRace Race { get; set; }
}
