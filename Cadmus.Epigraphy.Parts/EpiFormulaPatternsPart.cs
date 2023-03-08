using Cadmus.Core;
using Fusi.Tools.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// Epigraphic formula patterns part.
/// <para>Tag: <c>it.vedph.epigraphy.formula-patterns</c>.</para>
/// </summary>
[Tag("it.vedph.epigraphy.formula-patterns")]
public sealed class EpiFormulaPatternsPart : PartBase
{
    /// <summary>
    /// Gets or sets the entries.
    /// </summary>
    public List<EpiFormulaPattern> Patterns { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpiFormulaPatternsPart"/>
    /// class.
    /// </summary>
    public EpiFormulaPatternsPart()
    {
        Patterns = new List<EpiFormulaPattern>();
    }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins with
    /// these keys: <c>eid</c>, <c>language</c>, <c>tag</c>, and for tokens
    /// <c>token-tags</c>, <c>token-value</c> (multiple).</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        builder.Set("tot", Patterns?.Count ?? 0, false);

        if (Patterns?.Count > 0)
        {
            foreach (EpiFormulaPattern pattern in Patterns)
            {
                builder.AddValue("eid", pattern.Eid);
                builder.AddValue("language", pattern.Language);
                builder.AddValue("tag", pattern.Tag);

                if (pattern.Tokens?.Count > 0)
                {
                    foreach (EpiFormulaToken token in pattern.Tokens)
                    {
                        if (token.Tags?.Count > 0)
                        {
                            builder.AddValue("token-tags",
                                string.Join(".", token.Tags));
                        }
                        if (token.Values?.Count > 0)
                        {
                            builder.AddValues("token-value",
                                token.IsPlaceholder
                                ? token.Values.Select(s => $"${s}") : token.Values);
                        }
                    }
                }
            }
        }

        return builder.Build(this);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(new[]
        {
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of patterns."),
            new DataPinDefinition(DataPinValueType.String,
                "eid",
                "The pattern's EID.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "language",
                "The pattern's languages.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "tag",
                "The pattern's tag.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "token-tags",
                "The pattern's token tag(s) separated by dot."),
            new DataPinDefinition(DataPinValueType.String,
                "token-value",
                "The pattern's values, prefixed with $ if placeholders.",
                "M"),
        });
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

        sb.Append("[EpiFormulaPatterns]");

        if (Patterns?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Patterns)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Patterns.Count > 3)
                sb.Append("...(").Append(Patterns.Count).Append(')');
        }

        return sb.ToString();
    }
}
