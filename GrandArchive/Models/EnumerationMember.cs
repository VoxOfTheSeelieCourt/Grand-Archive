namespace GrandArchive.Models;

public struct EnumerationMember
{
    public string Description { get; set; }
    public object Value { get; set; }

    public override string ToString()
    {
        return Description;
    }
}