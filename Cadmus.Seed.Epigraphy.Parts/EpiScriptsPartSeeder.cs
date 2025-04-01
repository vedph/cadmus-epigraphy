using Bogus;
using Cadmus.Core;
using Cadmus.Epigraphy.Parts;
using Fusi.Tools.Configuration;
using System;

namespace Cadmus.Seed.Epigraphy.Parts;

/// <summary>
/// Seeder for <see cref="EpiScriptsPart"/>.
/// Tag: <c>seed.it.vedph.epigraphy.scripts</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.epigraphy.scripts")]
public sealed class EpiScriptsPartSeeder : PartSeederBase
{
    private static EpiScript GetEpiScript()
    {
        return new Faker<EpiScript>()
           .RuleFor(p => p.System, f => f.PickRandom("latn", "grek"))
           .RuleFor(p => p.Script, f => f.PickRandom("merchant", "gothic"))
           .RuleFor(p => p.Casing, f => f.PickRandom("uppercase", "lowercase"))
           .RuleFor(p => p.Features, f => [f.PickRandom("abbreviations", "ligatures")])
           .RuleFor(p => p.Note, f => f.Random.Bool(0.25f) ? f.Lorem.Sentence() : null)
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

        EpiScriptsPart part = new();
        part.Scripts.Add(GetEpiScript());
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
