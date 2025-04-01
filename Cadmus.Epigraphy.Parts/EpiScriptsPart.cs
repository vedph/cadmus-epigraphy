using Cadmus.Core;
using Fusi.Tools.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// Epigraphic writings data part.
/// <para>Tag: <c>it.vedph.epigraphy.scripts</c>.</para>
/// </summary>
[Tag("it.vedph.epigraphy.scripts")]
public sealed class EpiScriptsPart : PartBase
{
    /// <summary>
    /// Gets or sets the scripts.
    /// </summary>
    public List<EpiScript> Scripts { get; set; } = [];

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        if (Scripts.Count == 0) return [];

        DataPinBuilder builder = new();

        HashSet<string> systems = [];
        HashSet<string> scripts = [];
        HashSet<string> casings = [];
        HashSet<string> features = [];

        foreach (EpiScript script in Scripts)
        {
            if (!string.IsNullOrEmpty(script.System))
                systems.Add(script.System);

            if (!string.IsNullOrEmpty(script.Script))
                scripts.Add(script.Script);

            if (!string.IsNullOrEmpty(script.Casing))
                casings.Add(script.Casing);

            if (script.Features?.Count > 0)
                features.UnionWith(script.Features);
        }

        foreach (string system in systems)
            builder.AddValue("system", system);

        foreach (string script in scripts)
            builder.AddValue("script", script);

        foreach (string casing in casings)
            builder.AddValue("casing", casing);

        foreach (string feature in features)
            builder.AddValue("feature", feature);

        return builder.Build(this);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(
        [
             new DataPinDefinition(DataPinValueType.String,
                "system",
                "The writing system.",
                "M"),
             new DataPinDefinition(DataPinValueType.String,
                "script",
                "The writing script.",
                "M"),
             new DataPinDefinition(DataPinValueType.String,
                "casing",
                "The prevalent casing, when applicable.",
                "M"),
             new DataPinDefinition(DataPinValueType.String,
                "feature",
                "The script features.",
                "M"),
        ]);
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append("[EpiScripts]");

        if (Scripts?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (EpiScript script in Scripts)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(script);
            }
            if (Scripts.Count > 3)
                sb.Append("...(").Append(Scripts.Count).Append(')');
        }

        return sb.ToString();
    }
}
