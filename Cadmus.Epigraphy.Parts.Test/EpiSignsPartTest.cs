using Cadmus.Core;
using Cadmus.Seed.Epigraphy.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Epigraphy.Parts.Test;

public sealed class EpiSignsPartTest
{
    private static EpiSignsPart GetPart()
    {
        EpiSignsPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (EpiSignsPart)seeder.GetPart(item, null, null)!;
    }

    private static EpiSignsPart GetEmptyPart()
    {
        return new EpiSignsPart
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
        EpiSignsPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        EpiSignsPart part2 =
            TestHelper.DeserializePart<EpiSignsPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(part.Signs.Count, part2.Signs.Count);
    }

    [Fact]
    public void GetDataPins_NoEntries_Ok()
    {
        EpiSignsPart part = GetPart();
        part.Signs.Clear();

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Single(pins);
        DataPin pin = pins[0];
        Assert.Equal("tot-count", pin.Name);
        TestHelper.AssertPinIds(part, pin);
        Assert.Equal("0", pin.Value);
    }

    [Fact]
    public void GetDataPins_Entries_Ok()
    {
        EpiSignsPart part = GetEmptyPart();

        for (int n = 1; n <= 3; n++)
        {
            part.Signs.Add(new EpiSign
            {
                Id = $"s{n}",
                Features = [n % 2 == 0 ? "even" : "odd"],
            });
        }

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Equal(6, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin!.Value);

        // id
        pin = pins.Find(p => p.Name == "id" && p.Value == "s1");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "id" && p.Value == "s2");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "id" && p.Value == "s3");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // feature
        pin = pins.Find(p => p.Name == "feature" && p.Value == "even");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "feature" && p.Value == "odd");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}