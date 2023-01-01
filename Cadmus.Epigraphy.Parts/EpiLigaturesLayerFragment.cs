using Cadmus.Core;
using Cadmus.Core.Layers;
using Fusi.Tools.Config;
using System.Collections.Generic;
using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// Epigraphic ligatures layer fragment.
/// <para>Tag: <c>fr.it.vedph.epigraphy.ligatures</c>.</para>
/// </summary>
[Tag("fr.it.vedph.epigraphy.ligatures")]
public sealed class EpiLigaturesLayerFragment : ITextLayerFragment
{
    /// <summary>
    /// Gets or sets the location of this fragment.
    /// </summary>
    /// <remarks>
    /// The location can be expressed in different ways according to the
    /// text coordinates system being adopted. For instance, it might be a
    /// simple token-based coordinates system (e.g. 1.2=second token of
    /// first block), or a more complex system like an XPath expression.
    /// </remarks>
    public string Location { get; set; }

    /// <summary>
    /// Gets or sets the optional entity ID for the ligature.
    /// </summary>
    public string? Eid { get; set; }

    /// <summary>
    /// Gets or sets the ligature's type(s). Usually derived from a
    /// thesaurus.
    /// </summary>
    public List<string> Types { get; set; }

    /// <summary>
    /// Gets or sets the optional group identifier. This can be used
    /// to group ligatures.
    /// </summary>
    public string? GroupId { get; set; }

    /// <summary>
    /// Gets or sets an optional note.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpiLigaturesLayerFragment"/>
    /// class.
    /// </summary>
    public EpiLigaturesLayerFragment()
    {
        Location = "";
        Types = new List<string>();
    }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins.</returns>
    public IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        builder.AddValue(PartBase.FR_PREFIX + "count", Types.Count);
        builder.AddValues(PartBase.FR_PREFIX + "type", Types);
        if (!string.IsNullOrEmpty(Eid))
            builder.AddValue(PartBase.FR_PREFIX + "eid", Eid);

        return builder.Build(null);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(new[]
        {
            new DataPinDefinition(DataPinValueType.Integer,
               "count",
               "The count of ligature types."),
            new DataPinDefinition(DataPinValueType.String,
               "type",
               "The type(s) of ligature.",
               "M"),
            new DataPinDefinition(DataPinValueType.String,
               "eid",
               "The ligature EID.")
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

        sb.Append("[EpiLigatures]");

        if (!string.IsNullOrEmpty(Eid)) sb.Append(" #").Append(Eid);
        sb.AppendJoin(", ", Types);

        return sb.ToString();
    }
}
