using Bogus;
using Cadmus.Core;
using Cadmus.Epigraphy.Parts;
using Fusi.Tools.Configuration;
using System;

namespace Cadmus.Seed.Epigraphy.Parts;

/// <summary>
/// Seeder for <see cref="EpiTechniquePart"/>.
/// Tag: <c>seed.it.vedph.epigraphy.technique</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.epigraphy.technique")]
public sealed class EpiTechniquePartSeeder : PartSeederBase
{
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

        EpiTechniquePart part = new Faker<EpiTechniquePart>()
           .RuleFor(p => p.Techniques, f => [f.PickRandom("incision", "engraving")])
           .RuleFor(p => p.Tools, f => [f.PickRandom("chisel", "ink")])
           .RuleFor(p => p.Note, f => f.Random.Bool(0.25f) ? f.Lorem.Sentence() : null)
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}