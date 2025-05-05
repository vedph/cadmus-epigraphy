using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Cadmus.Core;
using Cadmus.Mat.Bricks;
using Cadmus.Refs.Bricks;
using Fusi.Tools.Configuration;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// Epigraphic support.
/// <para>Tag: <c>it.vedph.epigraphy.support</c>.</para>
/// </summary>
[Tag("it.vedph.epigraphy.support")]
public sealed class EpiSupportPart : PartBase
{
    /// <summary>
    /// Gets or sets the support's material, typically from
    /// <c>epi-support-materials</c>.
    /// </summary>
    public string Material { get; set; } = "";

    /// <summary>
    /// Gets or sets the type of the support object (e.g. column, frame, window,
    /// etc.): typically from thesaurus  <c>epi-support-object-types</c>.
    /// </summary>
    public string? ObjectType { get; set; }

    /// <summary>
    /// Gets or sets the support features, like in situ, indoor, damnatio,
    /// etc. Typically from thesaurus <c>epi-support-feats</c>.
    /// </summary>
    public HashSet<string>? Features { get; set; }

    /// <summary>
    /// Gets or sets the support's size.
    /// </summary>
    public PhysicalSize? Size { get; set; }

    /// <summary>
    /// Gets or sets the text areas present in the support.
    /// </summary>
    public List<EpiTextArea>? TextAreas { get; set; }

    /// <summary>
    /// Gets or sets decorated counts for this support. These can be used to
    /// provide counts for support-related things like rows, columns, etc.
    /// Typically from <c>epi-support-count-types</c>.
    /// </summary>
    public List<DecoratedCount> Counts { get; set; } = [];

    /// <summary>
    /// Gets or sets a generic note about the support.
    /// </summary>
    public string? Note { get; set; }

    private static void AddSizePins(string prefix, PhysicalSize size,
        DataPinBuilder builder)
    {
        // Currently we assume all the sizes have the same unit.
        // Alternatively, we should know in advance which are the
        // allowed units, and automatically convert them into a unique
        // one.
        if (size.W?.Value > 0)
        {
            builder.AddValue(prefix + "w",
                size.W.Value.ToString("0.0", CultureInfo.InvariantCulture));
        }
        if (size.H?.Value > 0)
        {
            builder.AddValue(prefix + "h",
                size.H.Value.ToString("0.0", CultureInfo.InvariantCulture));
        }

        if (size.D?.Value > 0)
        {
            builder.AddValue(prefix + "d",
                size.D.Value.ToString("0.0", CultureInfo.InvariantCulture));
        }
    }

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

        builder.AddValue("material", Material);
        builder.AddValue("object-type", ObjectType);

        // size
        if (Size != null) AddSizePins("support-", Size, builder);

        // features
        if (Features != null) builder.AddValues("feature", Features);

        // text areas
        if (TextAreas?.Count > 0)
        {
            HashSet<string> areaEids = [];
            HashSet<string> areaTypes = [];
            HashSet<string> areaLayouts = [];
            HashSet<string> areaFeats = [];
            HashSet<string> frameTypes = [];

            foreach (EpiTextArea area in TextAreas)
            {
                if (!string.IsNullOrEmpty(area.Eid)) areaEids.Add(area.Eid);

                areaTypes.Add(area.Type);
                if (!string.IsNullOrEmpty(area.Layout))
                    areaLayouts.Add(area.Layout);

                if (area.Features != null) areaFeats.UnionWith(area.Features);
                if (area.Size != null)
                    AddSizePins($"area-{area.Type}-", area.Size, builder);
                if (!string.IsNullOrEmpty(area.FrameType))
                    frameTypes.Add(area.FrameType);
            }

            if (areaEids.Count > 0) builder.AddValues("area-eid", areaEids);
            if (areaTypes.Count > 0) builder.AddValues("area-type", areaTypes);
            if (areaLayouts.Count > 0) builder.AddValues("area-layout", areaLayouts);
            if (areaFeats.Count > 0) builder.AddValues("area-feature", areaFeats);
            if (frameTypes.Count > 0) builder.AddValues("frame-type", frameTypes);
        }

        // counts
        foreach (DecoratedCount count in Counts)
            builder.AddValue("c-" + count.Id, count.Value);

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
                "material",
                "The material of the support."),
            new DataPinDefinition(DataPinValueType.String,
                "object-type",
                "The type of the support object."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "support-w",
                "The width of the support."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "support-h",
                "The height of the support."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "support-d",
                "The depth of the support."),
            new DataPinDefinition(DataPinValueType.String,
                "area-type",
                "The type of the text area.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "frame-type",
                "The type of the text area frame.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "area-eid",
                "The text area EID.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "area-layout",
                "The layout of the text area.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "area-feature",
                "A feature of the text area.",
                "M"),
            new DataPinDefinition(DataPinValueType.Decimal,
                "area-TYPE-w",
                "The width of the specified text area TYPE.",
                "M"),
            new DataPinDefinition(DataPinValueType.Decimal,
                "area-TYPE-h",
                "The height of the specified text area TYPE.",
                "M"),
            new DataPinDefinition(DataPinValueType.Decimal,
                "field-d",
                "The depth of the specified text area TYPE.",
                "M"),
            new DataPinDefinition(DataPinValueType.Integer,
                "c-NAME",
                "A count of NAME in this support.",
                "M"),
            new DataPinDefinition(DataPinValueType.String,
                "feature",
                "A feature of the support.",
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

        sb.Append("[EpiSupport]").Append(' ').Append(Material);

        if (!string.IsNullOrEmpty(ObjectType)) sb.Append(": ").Append(ObjectType);

        if (Size != null) sb.Append(" - ").Append(Size);

        return sb.ToString();
    }
}
