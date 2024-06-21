using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// Epigraphic support fragments part.
/// <para>Tag: <c>it.vedph.epigraphy.support-frr</c>.</para>
/// </summary>
[Tag("it.vedph.epigraphy.support-frr")]
public sealed class EpiSupportFrrPart : PartBase
{
    /// <summary>
    /// Gets or sets the fragments.
    /// </summary>
    public List<EpiSupportFr> Fragments { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpiSupportFrrPart"/> class.
    /// </summary>
    public EpiSupportFrrPart()
    {
        Fragments = [];
    }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins with
    /// these keys: <c>id</c> and <c>shelfmark</c>.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        builder.Set("tot", Fragments?.Count ?? 0, false);

        if (Fragments?.Count > 0)
        {
            foreach (EpiSupportFr fr in Fragments)
            {
                builder.AddValue("id", fr.Id);
                builder.AddValue("shelfmark", fr.Shelfmark);
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
        return new List<DataPinDefinition>(
        [
            new DataPinDefinition(DataPinValueType.String,
               "id",
               "The fragment(s) identifier(s).",
               "M"),
            new DataPinDefinition(DataPinValueType.String,
               "shelfmark",
               "The fragment(s) shelfmark(s).",
               "M"),
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of entries.")
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

        sb.Append("[EpiSupportFrr]");

        if (Fragments?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Fragments)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Fragments.Count > 3)
                sb.Append("...(").Append(Fragments.Count).Append(')');
        }

        return sb.ToString();
    }
}