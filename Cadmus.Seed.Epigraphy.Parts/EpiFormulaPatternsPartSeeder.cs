using Bogus;
using Cadmus.Core;
using Fusi.Tools.Configuration;
using System;
using Cadmus.Epigraphy.Parts;
using System.Collections.Generic;
using System.Linq;

namespace Cadmus.Seed.Epigraphy.Parts;

/// <summary>
/// Seeder for <see cref="EpiFormulaPatternsPart"/> part.
/// Tag: <c>seed.it.vedph.epigraphy.formula-patterns</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.epigraphy.formula-patterns")]
public class EpiFormulaPatternsPartSeeder : PartSeederBase
{
    private static List<EpiFormulaToken> GetTokens(int count, Faker f)
    {
        List<EpiFormulaToken> tokens = new(count);

        for (int i = 0; i < count; i++)
        {
            bool placeholder = f.Random.Bool(0.25f);
            int tagCount = f.Random.Number(1, 3);

            tokens.Add(new EpiFormulaToken
            {
                Tags = new List<string>
                {
                    string.Join(".",
                        Enumerable.Range(1, tagCount).Select(n => $"t{n}"))
                },
                IsOptional = f.Random.Bool(0.25f),
                IsPlaceholder = placeholder,
                Values = new List<string> { f.Lorem.Word() },
                Note = f.Random.Bool(0.25f)? f.Lorem.Sentence() : ""
            });
        }
        return tokens;
    }

    private static List<EpiFormulaPattern> GetPatterns(int count, Faker f)
    {
        List<EpiFormulaPattern> patterns = new(count);

        for (int i = 0; i < count; i++)
        {
            patterns.Add(new EpiFormulaPattern
            {
                Eid = $"p{i + 1}",
                Language = "lat",
                Tokens = GetTokens(f.Random.Number(1, 3), f)
            });
        }
        return patterns;
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
        if (item == null) throw new ArgumentNullException(nameof(item));

        EpiFormulaPatternsPart part = new Faker<EpiFormulaPatternsPart>()
            .RuleFor(p => p.Patterns, f => GetPatterns(f.Random.Number(1, 3), f))
            .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
