using Bogus;
using Cadmus.Core;
using Cadmus.Epigraphy.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Epigraphy.Parts;

/// <summary>
/// Seeder for <see cref="EpiSupportPart"/>.
/// Tag: <c>seed.it.vedph.epigraphy.support</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.epigraphy.support")]
public sealed class EpiSupportPartSeeder : PartSeederBase
{
    private static EpiTextArea GetTextArea()
    {
        return new Faker<EpiTextArea>()
            .RuleFor(a => a.FrameType, f => f.PickRandom("simple", "double"))
            .RuleFor(a => a.Layout, f => f.PickRandom("full-page", "columns"))
            .RuleFor(a => a.FrameDescription, f => f.Lorem.Sentence())
            .Generate();
    }

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

        string[] fnn = ["private", "public"];
        string[] types = ["house", "library", "castle"];

        EpiSupportPart part = new Faker<EpiSupportPart>()
           .RuleFor(p => p.Material,
                    f => f.PickRandom("concrete", "wood", "stone"))
           .RuleFor(p => p.OriginalFn, f => f.PickRandom(fnn))
           .RuleFor(p => p.CurrentFn, f => f.PickRandom(fnn))
           .RuleFor(p => p.OriginalType, f => f.PickRandom(types))
           .RuleFor(p => p.CurrentType, f => f.PickRandom(types))
           .RuleFor(p => p.ObjectType, f => f.PickRandom("slab", "column", "wall"))
           .RuleFor(p => p.Features, f => new HashSet<string>(
               [f.PickRandom("in-situ", "indoor")]))
           .RuleFor(p => p.Size, f => SeedHelper.GetSize(f))
           .RuleFor(p => p.TextAreas, _ => new List<EpiTextArea>([GetTextArea()]))
           .RuleFor(p => p.Note, f => f.Random.Bool(0.25f)
                ? f.Lorem.Sentence() : null)
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
