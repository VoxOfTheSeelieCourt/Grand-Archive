namespace GrandArchive.Models.DnDTools;

public partial class DndMonsterSubtype
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int MonstersubtypeId { get; set; }

    public virtual DndMonster Monster { get; set; }

    public virtual DndMonstersubtype1 Monstersubtype { get; set; }
}
