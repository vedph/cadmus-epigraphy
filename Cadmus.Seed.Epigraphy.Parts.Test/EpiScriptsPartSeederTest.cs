using Cadmus.Core;
using Cadmus.Epigraphy.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.Epigraphy.Parts.Test;

public sealed class EpiScriptsPartSeederTest
{
    private static readonly PartSeederFactory _factory =
    TestHelper.GetFactory();
    private static readonly SeedOptions _seedOptions =
        _factory.GetSeedOptions();
    private static readonly IItem _item =
        _factory.GetItemSeeder().GetItem(1, "facet");

    [Fact]
    public void TypeHasTagAttribute()
    {
        Type t = typeof(EpiScriptsPartSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.it.vedph.epigraphy.scripts", attr!.Tag);
    }

    [Fact]
    public void Seed_Ok()
    {
        EpiScriptsPartSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);

        IPart? part = seeder.GetPart(_item, null, _factory);

        Assert.NotNull(part);

        EpiScriptsPart? p = part as EpiScriptsPart;
        Assert.NotNull(p);

        TestHelper.AssertPartMetadata(p!);
    }
}
