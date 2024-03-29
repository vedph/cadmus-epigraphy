﻿using Cadmus.Core;
using Cadmus.Core.Layers;
using Cadmus.Epigraphy.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.Epigraphy.Parts.Test;

public sealed class EpiLigaturesLayerFragmentSeederTest
{
    private static readonly PartSeederFactory _factory
         = TestHelper.GetFactory();
    private static readonly SeedOptions _seedOptions
         = _factory.GetSeedOptions();
    private static readonly IItem _item =
        _factory.GetItemSeeder().GetItem(1, "facet");

    [Fact]
    public void TypeHasTagAttribute()
    {
        Type t = typeof(EpiLigaturesLayerFragmentSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.fr.it.vedph.epigraphy.ligatures", attr.Tag);
    }

    [Fact]
    public void GetFragmentType_Ok()
    {
        EpiLigaturesLayerFragmentSeeder seeder = new();
        Assert.Equal(typeof(EpiLigaturesLayerFragment), seeder.GetFragmentType());
    }

    [Fact]
    public void Seed_WithOptions_Ok()
    {
        EpiLigaturesLayerFragmentSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);
        seeder.Configure(new EpiLigaturesLayerFragmentSeederOptions
        {
            Types = new[]
            {
                "a",
                "b",
                "c"
            }
        });

        ITextLayerFragment fragment = seeder.GetFragment(_item, "1.1", "alpha");

        Assert.NotNull(fragment);

        EpiLigaturesLayerFragment? fr = fragment as EpiLigaturesLayerFragment;
        Assert.NotNull(fr);

        Assert.Equal("1.1", fr.Location);
        Assert.True(fr.Types.All(s => s == "a" || s == "b" || s == "c"));
    }
}
