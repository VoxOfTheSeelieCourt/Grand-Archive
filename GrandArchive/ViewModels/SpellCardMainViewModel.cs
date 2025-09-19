using GrandArchive.Helpers.Attributes;
using GrandArchive.ViewModels.Abstract;

namespace GrandArchive.ViewModels;

[NavigableMenuItem("Spell Cards", "LayerRegular")]
public class SpellCardMainViewModel : NavigableViewModel
{
    public SpellCardMainViewModel()
    {
        // var a = File.ReadAllText("Assets/Spells.json");
        // var b = JsonSerializer.Deserialize<List<Spell>>(a);
    }
}