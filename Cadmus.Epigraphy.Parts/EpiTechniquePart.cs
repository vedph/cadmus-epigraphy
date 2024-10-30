using Cadmus.Core;
using Fusi.Tools.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// Epigraphic techniques and tools part.
/// Tag: <c>it.vedph.epigraphy.technique</c>.
/// </summary>
/// <seealso cref="PartBase" />
[Tag("it.vedph.epigraphy.technique")]
public sealed class EpiTechniquePart : PartBase
{
    /// <summary>
    /// Gets or sets the techniques (e.g. "incision", "engraving"), typically
    /// from <c>epi-technique-types</c>.
    /// </summary>
    public HashSet<string> Techniques { get; set; } = [];

    /// <summary>
    /// Gets or sets the tools (e.g. "chisel", "ink"), typically from
    /// <c>epi-technique-tools</c>.
    /// </summary>
    public HashSet<string> Tools { get; set; } = [];

    /// <summary>
    /// Gets or sets an optional note.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        builder.AddValues("technique", Techniques);
        builder.AddValues("tool", Tools);

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
                "technique",
                "The inscription technique.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "tool",
                "The inscription tool.",
                "M")
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

        sb.Append("[EpiTechnique] ");
        sb.AppendJoin(", ", Techniques);

        return sb.ToString();
    }
}
