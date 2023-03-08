using Cadmus.Core;
using Cadmus.Seed.Epigraphy.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Epigraphy.Parts.Test;

public sealed class EpiFormulaPatternsPartTest
{
    private static EpiFormulaPatternsPart GetPart()
    {
        EpiFormulaPatternsPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (EpiFormulaPatternsPart)seeder.GetPart(item, null, null)!;
    }

    private static EpiFormulaPatternsPart GetEmptyPart()
    {
        return new EpiFormulaPatternsPart
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
        EpiFormulaPatternsPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        EpiFormulaPatternsPart part2 =
            TestHelper.DeserializePart<EpiFormulaPatternsPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(part.Patterns.Count, part2.Patterns.Count);
    }

    [Fact]
    public void GetDataPins_NoEntries_Ok()
    {
        EpiFormulaPatternsPart part = GetPart();
        part.Patterns.Clear();

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Single(pins);
        DataPin pin = pins[0];
        Assert.Equal("tot-count", pin.Name);
        TestHelper.AssertPinIds(part, pin);
        Assert.Equal("0", pin.Value);
    }

    private static List<EpiFormulaToken> GetTokens(int count)
    {
        List<EpiFormulaToken> tokens = new(count);

        for (int i = 0; i < count; i++)
        {
            bool even = i % 2 == 0;

            tokens.Add(new EpiFormulaToken
            {
                Tags = new List<string>
                {
                    even? "t1.t2" : "t3"
                },
                Values = even ? new List<string> { $"$p{i + 1}" }
                    : new List<string> { $"v{i + 1}" },
            });
        }
        return tokens;
    }

    [Fact]
    public void GetDataPins_Entries_Ok()
    {
        EpiFormulaPatternsPart part = GetEmptyPart();

        // grc: <t3 $p1>; <t1.t2 v2>
        // lat: <t3 $p1>; <t1.t2 v2>
        // lat: <t3 $p1>; <t1.t2 v2>

        for (int n = 1; n <= 3; n++)
        {
            part.Patterns.Add(new EpiFormulaPattern
            {
                Eid = "pat" + n,
                Language = n == 1? "grc" : "lat",
                Tag = "tag" + n,
                Tokens = GetTokens(2)
            });
        }

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Equal(13, pins.Count);

        // tot-count
        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin!.Value);

        // language
        pin = pins.Find(p => p.Name == "language" && p.Value == "lat");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "language" && p.Value == "grc");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // token-tags
        pin = pins.Find(p => p.Name == "token-tags" && p.Value == "t1.t2");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "token-tags" && p.Value == "t3");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // token-value
        pin = pins.Find(p => p.Name == "token-value" && p.Value == "$p1");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "token-value" && p.Value == "v2");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        for (int n = 1; n <= 3; n++)
        {
            // eid
            pin = pins.Find(p => p.Name == "eid" && p.Value == "pat" + n);
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);

            // tag
            pin = pins.Find(p => p.Name == "tag" && p.Value == "tag" + n);
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
        }
    }
}
