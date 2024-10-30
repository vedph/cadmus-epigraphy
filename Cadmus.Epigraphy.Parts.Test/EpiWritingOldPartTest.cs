using Cadmus.Core;
using Cadmus.Refs.Bricks;
using Cadmus.Seed.Epigraphy.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Epigraphy.Parts.Test;

public sealed class EpiWritingOldPartTest
{
    private static EpiWritingOldPart GetPart()
    {
        EpiWritingOldPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (EpiWritingOldPart)seeder.GetPart(item, null, null)!;
    }

    private static EpiWritingOldPart GetEmptyPart()
    {
        return new EpiWritingOldPart
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
        EpiWritingOldPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        EpiWritingOldPart part2 = TestHelper.DeserializePart<EpiWritingOldPart>(json)!;

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
        EpiWritingOldPart part = GetEmptyPart();
        part.System = "latn";
        part.Type = "capital";
        part.Technique = "ink";
        part.Tool = "pen";
        part.FrameType = "rectangle";
        part.Counts.Add(new DecoratedCount
        {
            Id = "row",
            Value = 3
        });
        part.FigType = "cross";
        part.FigFeatures.Add("fish");
        part.ScriptFeatures.Add("ligatures");
        part.Languages.Add("lat");
        part.HasPoetry = true;
        part.Metres.Add("6da^");

        List<DataPin> pins = part.GetDataPins(null).ToList();
        Assert.Equal(12, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "system" && p.Value == "latn");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "type" && p.Value == "capital");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "technique" && p.Value == "ink");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "tool" && p.Value == "pen");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "frame-type" && p.Value == "rectangle");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "c-row" && p.Value == "3");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "fig-type" && p.Value == "cross");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "fig-feat" && p.Value == "fish");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "script-feat" && p.Value == "ligatures");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "language" && p.Value == "lat");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "poetic" && p.Value == "1");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "metre" && p.Value == "6da^");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
