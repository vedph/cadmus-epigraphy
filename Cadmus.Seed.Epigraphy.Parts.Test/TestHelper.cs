﻿using Cadmus.Core.Config;
using Cadmus.Core;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Cadmus.Epigraphy.Parts;
using Xunit;
using Fusi.Microsoft.Extensions.Configuration.InMemoryJson;
using Microsoft.Extensions.Hosting;

namespace Cadmus.Seed.Epigraphy.Parts.Test;

static internal class TestHelper
{
    static public string LoadResourceText(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        using StreamReader reader = new(
            Assembly.GetExecutingAssembly().GetManifestResourceStream(
                $"Cadmus.Seed.Epigraphy.Parts.Test.Assets.{name}")!,
            Encoding.UTF8);
        return reader.ReadToEnd();
    }

    private static IHost GetHost(string config)
    {
        // map
        TagAttributeToTypeMap map = new();
        map.Add(
        [
            // Cadmus.Core
            typeof(StandardItemSortKeyBuilder).Assembly,
            // Cadmus.Epigraphy.Parts
            typeof(EpiSupportPart).Assembly
        ]);

        return new HostBuilder().ConfigureServices((hostContext, services) =>
        {
            PartSeederFactory.ConfigureServices(services,
                new StandardPartTypeProvider(map),
                // Cadmus.Seed.Epigraphy.Parts
                typeof(EpiSupportPartSeeder).Assembly);
        })
        // extension method from Fusi library
        .AddInMemoryJson(config)
        .Build();
    }

    static public PartSeederFactory GetFactory()
    {
        return new PartSeederFactory(GetHost(LoadResourceText("SeedConfig.json")));
    }

    static public void AssertPartMetadata(IPart part)
    {
        Assert.NotNull(part.Id);
        Assert.NotNull(part.ItemId);
        Assert.NotNull(part.UserId);
        Assert.NotNull(part.CreatorId);
    }
}
