using System;
using Xunit;
using Cadmus.Core;
using System.Collections.Generic;
using System.Linq;
using Cadmus.Seed.Epigraphy.Parts;

namespace Cadmus.Epigraphy.Parts.Test;

public sealed class EpiTechniquePartTest
{
    private static EpiTechniquePart GetPart()
    {
        EpiTechniquePartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (EpiTechniquePart)seeder.GetPart(item, null, null)!;
    }

    private static EpiTechniquePart GetEmptyPart()
    {
        return new EpiTechniquePart
        {
            ItemId = Guid.NewGuid().ToString(),
            RoleId = "some-role",
            CreatorId = "zeus",
            UserId = "another",
        };
    }

    [Fact]
    public void Part_Is_Serializable()
    {
        EpiTechniquePart part = GetPart();

        string json = TestHelper.SerializePart(part);
        EpiTechniquePart part2 = TestHelper.DeserializePart<EpiTechniquePart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);
    }

    [Fact]
    public void GetDataPins_Tag_1()
    {
        EpiTechniquePart part = GetEmptyPart();
        part.Techniques.Add("engraving");
        part.Tools.Add("chisel");
        part.Tools.Add("ink");

        List<DataPin> pins = part.GetDataPins(null).ToList();
        Assert.Equal(3, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "technique" && p.Value == "engraving");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "tool" && p.Value == "chisel");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "tool" && p.Value == "ink");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
