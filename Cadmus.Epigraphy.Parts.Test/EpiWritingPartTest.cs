﻿using Cadmus.Core;
using Cadmus.Refs.Bricks;
using Cadmus.Seed.Epigraphy.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Epigraphy.Parts.Test;

public sealed class EpiWritingPartTest
{
    private static EpiWritingPart GetPart()
    {
        EpiWritingPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (EpiWritingPart)seeder.GetPart(item, null, null)!;
    }

    private static EpiWritingPart GetEmptyPart()
    {
        return new EpiWritingPart
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
        EpiWritingPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        EpiWritingPart part2 = TestHelper.DeserializePart<EpiWritingPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);
    }

    [Fact]
    public void GetDataPins_Ok()
    {
        EpiWritingPart part = GetEmptyPart();
        part.System = "latn";
        part.Script = "merchant";
        part.Casing = "uppercase";
        part.Features.Add("ligatures");

        List<DataPin> pins = part.GetDataPins(null).ToList();
        Assert.Equal(4, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "system" && p.Value == "latn");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "script" && p.Value == "merchant");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "casing" && p.Value == "uppercase");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "feature" && p.Value == "ligatures");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
