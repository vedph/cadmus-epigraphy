using Bogus;
using Cadmus.Core;
using Cadmus.Epigraphy.Parts;
using Cadmus.Mat.Bricks;
using Fusi.Tools.Configuration;
using System;

namespace Cadmus.Seed.Epigraphy.Parts;

/// <summary>
/// Seeder for <see cref="EpiSupportOldPart"/>.
/// Tag: <c>seed.it.vedph.epigraphy.support.old</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.epigraphy.support.old")]
public sealed class EpiSupportOldPartSeeder : PartSeederBase
{
    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart? GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        ArgumentNullException.ThrowIfNull(item);

        string[] fnn = ["street", "house"];

        EpiSupportOldPart part = new Faker<EpiSupportOldPart>()
           .RuleFor(p => p.OriginalFn, f => f.PickRandom(fnn))
           .RuleFor(p => p.CurrentFn, f => f.PickRandom(fnn))
           .RuleFor(p => p.ObjectType,
                f => f.PickRandom("street", "bridge", "well"))
           .RuleFor(p => p.SupportType,
                f => f.PickRandom("street", "door"))
           .RuleFor(p => p.Material,
                f => f.PickRandom("concrete", "wood", "stone"))
           .RuleFor(p => p.Indoor, f => f.Random.Bool())
           .RuleFor(p => p.Size,
                f => new PhysicalSize
                {
                    W = new PhysicalDimension
                    {
                        Value = f.Random.Number(5, 30),
                        Unit = "cm"
                    },
                    H = new PhysicalDimension
                    {
                        Value = f.Random.Number(5, 30),
                        Unit = "cm"
                    }
                })
           .RuleFor(p => p.State, f => f.Lorem.Sentence())
           .RuleFor(p => p.LastSeen, f => f.Date.Past())
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
