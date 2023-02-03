using Cadmus.Core;
using Fusi.Tools.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using Cadmus.Seed.Epigraphy.Parts;

namespace Cadmus.Epigraphy.Parts.Test;

public sealed class EpiLigaturesLayerFragmentTest
{
    private static EpiLigaturesLayerFragment GetFragment()
    {
        var seeder = new EpiLigaturesLayerFragmentSeeder();
        return (EpiLigaturesLayerFragment)
            seeder.GetFragment(new Item(), "1.2", "exemplum fictum");
    }

    private static EpiLigaturesLayerFragment GetEmptyFragment()
    {
        return new EpiLigaturesLayerFragment
        {
            Location = "1.23",
        };
    }

    [Fact]
    public void Fragment_Has_Tag()
    {
        TagAttribute? attr = typeof(EpiLigaturesLayerFragment).GetTypeInfo()
            .GetCustomAttribute<TagAttribute>();
        string? typeId = attr != null ? attr.Tag : GetType().FullName;
        Assert.NotNull(typeId);
        Assert.StartsWith(PartBase.FR_PREFIX, typeId);
    }

    [Fact]
    public void Fragment_Is_Serializable()
    {
        EpiLigaturesLayerFragment fragment = GetFragment();

        string json = TestHelper.SerializeFragment(fragment);
        EpiLigaturesLayerFragment? fragment2 =
            TestHelper.DeserializeFragment<EpiLigaturesLayerFragment>(json);

        Assert.NotNull(fragment2);
        Assert.Equal(fragment.Location, fragment2.Location);
    }

    [Fact]
    public void GetDataPins_Ok()
    {
        EpiLigaturesLayerFragment fragment = GetEmptyFragment();
        fragment.Eid = "x";
        fragment.Types = new List<string> { "joint", "inversion" };

        List<DataPin> pins = fragment.GetDataPins(null).ToList();

        Assert.Equal(4, pins.Count);

        Assert.NotNull(pins.Find(p => p.Name == PartBase.FR_PREFIX + "count" &&
            p.Value == "2"));
        Assert.NotNull(pins.Find(p => p.Name == PartBase.FR_PREFIX + "eid" &&
            p.Value == "x"));
        Assert.NotNull(pins.Find(p => p.Name == PartBase.FR_PREFIX + "type" &&
            p.Value == "joint"));
        Assert.NotNull(pins.Find(p => p.Name == PartBase.FR_PREFIX + "type" &&
            p.Value == "inversion"));
    }
}
