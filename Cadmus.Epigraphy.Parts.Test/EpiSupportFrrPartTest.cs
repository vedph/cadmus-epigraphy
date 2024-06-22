using Cadmus.Core;
using Cadmus.Seed.Epigraphy.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Epigraphy.Parts.Test;

public sealed class EpiSupportFrrPartTest
{
    private static EpiSupportFrrPart GetPart()
    {
        EpiSupportFrrPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (EpiSupportFrrPart)seeder.GetPart(item, null, null)!;
    }

    private static EpiSupportFrrPart GetEmptyPart()
    {
        return new EpiSupportFrrPart
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
        EpiSupportFrrPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        EpiSupportFrrPart part2 =
            TestHelper.DeserializePart<EpiSupportFrrPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(part.Fragments.Count, part2.Fragments.Count);
    }

    [Fact]
    public void GetDataPins_NoEntries_Ok()
    {
        EpiSupportFrrPart part = GetPart();
        part.Fragments.Clear();

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
        EpiSupportFrrPart part = GetEmptyPart();

        for (int n = 1; n <= 3; n++)
        {
            part.Fragments.Add(new EpiSupportFr
            {
                Id= new string((char)('A' + n - 1), 1),
                Shelfmark = "S" + n,
            });
        }

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Equal(7, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin!.Value);

        for (int n = 1; n <= 3; n++)
        {
            pin = pins.Find(p => p.Name == "id" &&
                p.Value == new string((char)('A' + n - 1), 1));
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
        }
    }
}