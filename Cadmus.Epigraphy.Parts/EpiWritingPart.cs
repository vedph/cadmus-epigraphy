using Cadmus.Core;
using Fusi.Tools.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// Epigraphic writing data part.
/// <para>Tag: <c>it.vedph.epigraphy.writing</c>.</para>
/// </summary>
[Tag("it.vedph.epigraphy.writing")]
public sealed class EpiWritingPart : PartBase
{
    /// <summary>
    /// Gets or sets the writing system (usually from <c>epi-writing-systems</c>,
    /// mostly ISO 15924, lowercased, e.g. <c>latn</c>, <c>grek</c>).
    /// </summary>
    public string? System { get; set; }

    /// <summary>
    /// Gets or sets the script type (e.g. gothic, merchant, etc.), typically
    /// from <c>epi-writing-scripts</c>.
    /// </summary>
    public string Script { get; set; } = "";

    /// <summary>
    /// Gets or sets the prevalent casing, when applicable (e.g. uppercase,
    /// lowercase, uppercase + lowercase, etc.), typically from
    /// <c>epi-writing-casings</c>.
    /// </summary>
    public string? Casing { get; set; }

    /// <summary>
    /// Gets or sets the script features (e.g. abbreviations, ligatures,
    /// punctuation, etc.), typically from <c>epi-writing-features</c>.
    /// </summary>
    public HashSet<string> Features { get; set; } = [];

    /// <summary>
    /// Gets or sets a generic note.
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

        builder.AddValue("system", System);
        builder.AddValue("script", Script);
        builder.AddValue("casing", Casing);

        if (Features?.Count > 0) builder.AddValues("feature", Features);

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
                "The writing system."),
             new DataPinDefinition(DataPinValueType.String,
                "script",
                "The writing script."),
             new DataPinDefinition(DataPinValueType.String,
                "casing",
                "The prevalent casing, when applicable."),
             new DataPinDefinition(DataPinValueType.String,
                "feature",
                "The script features.", "M"),
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

        sb.Append("[EpiWriting] ");
        if (!string.IsNullOrEmpty(System)) sb.Append(System).Append(' ');
        if (!string.IsNullOrEmpty(Script)) sb.Append(Script);

        return sb.ToString();
    }
}
