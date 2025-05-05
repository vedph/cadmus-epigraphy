using Cadmus.Core;
using Cadmus.Mat.Bricks;
using Cadmus.Refs.Bricks;
using Cadmus.Seed.Epigraphy.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Epigraphy.Parts.Test;

public sealed class EpiSupportPartTest
{
    private static EpiSupportPart GetPart()
    {
        EpiSupportPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (EpiSupportPart)seeder.GetPart(item, null, null)!;
    }

    private static EpiSupportPart GetEmptyPart()
    {
        return new EpiSupportPart
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
        EpiSupportPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        EpiSupportPart part2 = TestHelper.DeserializePart<EpiSupportPart>(json)!;

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
        EpiSupportPart part = GetEmptyPart();
        part.Material = "stone";
        part.ObjectType = "window";
        part.Features = ["damnatio", "indoor"];

        part.Counts.Add(new DecoratedCount
        {
            Id = "row",
            Value = 3,
        });

        part.Size = new PhysicalSize
        {
            W = new PhysicalDimension
            {
                Value = 21,
                Unit = "cm"
            },
            H = new PhysicalDimension
            {
                Value = 29.70f,
                Unit = "cm"
            }
        };

        part.TextAreas =
        [
            new EpiTextArea
            {
                Type = "added",
                Layout = "columns",
                Size = new PhysicalSize
                {
                    W = new PhysicalDimension
                    {
                        Value = 10,
                        Unit = "cm"
                    },
                    H = new PhysicalDimension
                    {
                        Value = 15,
                        Unit = "cm"
                    }
                },
                FrameType = "double",
            }
        ];

        List<DataPin> pins = [.. part.GetDataPins(null)];
        Assert.Equal(16, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "material" && p.Value == "stone");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "original-fn" && p.Value == "house");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "current-fn" && p.Value == "street");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "original-type" && p.Value == "house");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "current-type" && p.Value == "library");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "object-type" && p.Value == "window");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // counts
        pin = pins.Find(p => p.Name == "c-row" && p.Value == "3");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // features
        pin = pins.Find(p => p.Name == "feature" && p.Value == "damnatio");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "feature" && p.Value == "indoor");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // area
        pin = pins.Find(p => p.Name == "area-type" && p.Value == "added");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "area-layout" && p.Value == "columns");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "area-added-w" && p.Value == "10.0");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "area-added-h" && p.Value == "15.0");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "frame-type" && p.Value == "double");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // size
        pin = pins.Find(p => p.Name == "support-w" && p.Value == "21.0");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "support-h" && p.Value == "29.7");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
