using Bogus;
using Cadmus.Core;
using Cadmus.Core.Layers;
using Cadmus.Epigraphy.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Epigraphy.Parts;

/// <summary>
/// Seeder for <see cref="__NAME__LayerFragment"/>'s.
/// Tag: <c>seed.fr.it.vedph.epigraphy.ligatures</c>.
/// </summary>
/// <seealso cref="FragmentSeederBase" />
/// <seealso cref="IConfigurable{EpiLigaturesLayerFragmentSeederOptions}" />
[Tag("seed.fr.it.vedph.epigraphy.ligatures")]
public sealed class EpiLigaturesLayerFragmentSeeder : FragmentSeederBase,
    IConfigurable<EpiLigaturesLayerFragmentSeederOptions>
{
    private EpiLigaturesLayerFragmentSeederOptions? _options;

    /// <summary>
    /// Gets the type of the fragment.
    /// </summary>
    /// <returns>Type.</returns>
    public override Type GetFragmentType() => typeof(EpiLigaturesLayerFragment);

    public void Configure(EpiLigaturesLayerFragmentSeederOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="location">The location.</param>
    /// <param name="baseText">The base text.</param>
    /// <returns>A new fragment.</returns>
    /// <exception cref="ArgumentNullException">location or baseText</exception>
    public override ITextLayerFragment GetFragment(
        IItem item, string location, string baseText)
    {
        ArgumentNullException.ThrowIfNull(location);
        ArgumentNullException.ThrowIfNull(baseText);

        IList<string> types = _options?.Types ?? new List<string>(
            EpiLigaturesLayerFragmentSeederOptions.GetDefaultTypes());

        return new Faker<EpiLigaturesLayerFragment>()
            .RuleFor(fr => fr.Location, location)
            .RuleFor(fr => fr.Eid, f => $"l{f.IndexGlobal}")
            .RuleFor(fr => fr.Types, f => new List<string> { f.PickRandom(types) })
            .RuleFor(fr => fr.GroupId, f => f.Random.Bool(0.25F)? "g" : null)
            .RuleFor(fr => fr.Note,
                f => f.Random.Bool(0.3F) ? f.Lorem.Sentence(10) : null)
            .Generate();
    }
}

public class EpiLigaturesLayerFragmentSeederOptions
{
    public IList<string> Types { get; set; }

    public EpiLigaturesLayerFragmentSeederOptions()
    {
        Types = new List<string>(GetDefaultTypes());
    }

    public static IList<string> GetDefaultTypes()
    {
        return new List<string>()
        {
            // see Manzella 1987 149-151
            // nesso
            "joint",
            // inversione (e.g. R horizontally flipped )
            "inversion",
            // sovrapposizione (e.g. A over V)
            "overlap",
            // sostituzione (e.g. OE where | of E is replaced by O's curve)
            "replacement",
            // innesto (e.g. C with smaller I at upper right corner, like an upside G)
            "graft",
            // inclusione (e.g. smaller O inside C)
            "inclusion",
            // connessione (e.g. continuous overline on ARC)
            "connection"
        };
    }
}
