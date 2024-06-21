using Bogus;
using Cadmus.Core;
using Cadmus.Epigraphy.Parts;
using Cadmus.Mat.Bricks;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Epigraphy.Parts;

/// <summary>
/// Seeder for <see cref="EpiSignsPart"/>.
/// Tag: <c>seed.it.vedph.epigraphy.signs</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.epigraphy.signs")]
public sealed class EpiSignsPartSeeder : PartSeederBase
{
    private static List<EpiSign> GetSigns(int count, Faker f)
    {
        List<EpiSign> signs = [];
        for (int n = 1; n <= count; n++)
        {
            EpiSign sign = new()
            {
                Id = f.PickRandom("A", "B", "H"),
                Features = [f.PickRandom("alpha", "beta")],
                Sizes = new Dictionary<string, PhysicalSize>
                {
                    ["height"] = new PhysicalSize
                    {
                        W = new PhysicalDimension
                        {
                            Value = f.Random.Float(1, 5),
                            Unit = "cm"
                        }
                    },
                    ["width"] = new PhysicalSize
                    {
                        H = new PhysicalDimension
                        {
                            Value = f.Random.Float(1, 5),
                            Unit = "cm"
                        }
                    }
                },
                Description = f.Lorem.Sentence()
            };
            signs.Add(sign);
        }
        return signs;
    }

    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part or null.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart? GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        ArgumentNullException.ThrowIfNull(item);

        EpiSignsPart part = new Faker<EpiSignsPart>()
           .RuleFor(p => p.Signs, f => GetSigns(f.Random.Number(1, 3), f))
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
