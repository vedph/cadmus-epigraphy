using Bogus;
using Cadmus.Core;
using Cadmus.Epigraphy.Parts;
using Cadmus.Mat.Bricks;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Epigraphy.Parts;

/// <summary>
/// Seeder for <see cref="EpiSupportFrrPart"/>.
/// Tag: <c>seed.it.vedph.epigraphy.support-frr</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.epigraphy.support-frr")]
public sealed class EpiSupportFrrPartSeeder : PartSeederBase
{
    private static List<EpiSupportFr> GetFragments(int count, Faker f)
    {
        List<EpiSupportFr> fragments = [];

        for (int n = 1; n <= count; n++)
        {
            EpiSupportFr fr = new()
            {
                Id = new string((char)('A' - 1 + n), 1),
                Shelfmark = f.Address.ZipCode(),
                Size = new PhysicalSize
                {
                    W = new PhysicalDimension
                    {
                        Value = (float)Math.Round(f.Random.Float(1, 5), 1),
                        Unit = "cm"
                    },
                    H = new PhysicalDimension
                    {
                        Value = (float)Math.Round(f.Random.Float(1, 5), 1),
                        Unit = "cm"
                    }
                },
                IsLost = f.Random.Bool(0.25f),
                Row = (short)f.Random.Number(1, 5),
                Column = (short)f.Random.Number(1, 5),
                RowSpan = f.Random.Bool(0.25f)
                    ? (short)f.Random.Number(2, 3) : (short)0,
                ColumnSpan = f.Random.Bool(0.25f)
                    ? (short)f.Random.Number(2, 3) : (short)0,
                HeadText = f.Random.Bool(0.25f) ? f.Lorem.Sentence(3) : null,
                TailText = f.Random.Bool(0.25f) ? f.Lorem.Sentence(3) : null,
                Note = f.Random.Bool(0.25f) ? f.Lorem.Sentence() : null,
            };
            fragments.Add(fr);
        }

        return fragments;
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

        EpiSupportFrrPart part = new Faker<EpiSupportFrrPart>()
           .RuleFor(p => p.Fragments,
                f => GetFragments(f.Random.Number(1, 3), f))
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
