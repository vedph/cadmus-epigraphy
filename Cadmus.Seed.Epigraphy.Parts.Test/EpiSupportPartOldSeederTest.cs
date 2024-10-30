using Cadmus.Core;
using Cadmus.Epigraphy.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.Epigraphy.Parts.Test;

public sealed class EpiSupportPartOldSeederTest
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
        Type t = typeof(EpiSupportOldPartSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.it.vedph.epigraphy.support.old", attr!.Tag);
    }

    [Fact]
    public void Seed_Ok()
    {
        EpiSupportOldPartSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);

        IPart? part = seeder.GetPart(_item, null, _factory);

        Assert.NotNull(part);

        EpiSupportOldPart? p = part as EpiSupportOldPart;
        Assert.NotNull(p);

        TestHelper.AssertPartMetadata(p!);
    }
}
