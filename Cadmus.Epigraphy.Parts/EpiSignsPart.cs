using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// Epigraphy writing signs paleographic description.
/// <para>Tag: <c>it.vedph.epigraphy.signs</c>.</para>
/// </summary>
[Tag("it.vedph.epigraphy.signs")]
public sealed class EpiSignsPart : PartBase
{
    /// <summary>
    /// Gets or sets the signs.
    /// </summary>
    public List<EpiSign> Signs { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpiSignsPart"/> class.
    /// </summary>
    public EpiSignsPart()
    {
        Signs = [];
    }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins with
    /// these keys: <c>id</c>, <c>feature</c>.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        builder.Set("tot", Signs?.Count ?? 0, false);

        if (Signs?.Count > 0)
        {
            foreach (EpiSign sign in Signs)
            {
                builder.AddValue("id", sign.Id);
                if (sign.Features?.Count > 0)
                    builder.AddValues("feature", sign.Features);
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
                "The sign(s) ID(s).",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "feature",
                "The sign feature(s).",
                "M"),
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of signs.")
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

        sb.Append("[EpiSigns]");

        if (Signs?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Signs)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Signs.Count > 3)
                sb.Append("...(").Append(Signs.Count).Append(')');
        }

        return sb.ToString();
    }
}