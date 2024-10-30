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
    /// Gets or sets the original function of the support structure
    /// (e.g. private, public, etc.: typically from <c>epi-support-functions</c>).
    /// </summary>
    public string? OriginalFn { get; set; }

    /// <summary>
    /// Gets or sets the current function of the support structure.
    /// (e.g. private, public, etc.: typically from <c>epi-support-functions</c>).
    /// </summary>
    public string? CurrentFn { get; set; }

    /// <summary>
    /// Gets or sets the original type of the support structure (e.g. house,
    /// library, castle, etc.: typically from <c>epi-support-types</c>).
    /// </summary>
    public string? OriginalType { get; set; }

    /// <summary>
    /// Gets or sets the current type of the support structure (e.g. house,
    /// library, castle, etc.: typically from <c>epi-support-types</c>).
    /// </summary>
    public string? CurrentType { get; set; }

    /// <summary>
    /// Gets or sets the type of the support object (e.g. column, frame, window,
    /// etc.): typically from <c>epi-support-object-types</c>.
    /// </summary>
    public string? ObjectType { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the support is indoor.
    /// </summary>
    public bool Indoor { get; set; }

    /// <summary>
    /// Gets or sets the support's size.
    /// </summary>
    public PhysicalSize? SupportSize { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this support has a writing
    /// field.
    /// </summary>
    public bool HasField { get; set; }

    /// <summary>
    /// Gets or sets the writing field's size in the support.
    /// </summary>
    public PhysicalSize? FieldSize { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this support has a writing
    /// mirror.
    /// </summary>
    public bool HasMirror { get; set; }

    /// <summary>
    /// Gets or sets the writing mirror's size in the support.
    /// </summary>
    public PhysicalSize? MirrorSize { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the support mirror has a frame.
    /// </summary>
    public bool HasFrame { get; set; }

    /// <summary>
    /// Gets or sets a short description of the support mirror frame.
    /// </summary>
    public string? Frame { get; set; }

    /// <summary>
    /// Gets or sets decorated counts for this support. These can be used to
    /// provide counts for support-related things like rows, columns, etc.
    /// Typically from <c>epi-support-count-types</c>.
    /// </summary>
    public List<DecoratedCount> Counts { get; set; } = [];

    /// <summary>
    /// Gets or sets the support features (e.g. monogram, single letter, etc.),
    /// typically from <c>epi-support-features</c>.
    /// </summary>
    public HashSet<string> Features { get; set; } = [];

    /// <summary>
    /// Gets or sets a value indicating whether this support is damaged by
    /// the presence of a damnatio memoriae.
    /// </summary>
    public bool HasDamnatio { get; set; }

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
        builder.AddValue("original-fn", OriginalFn);
        builder.AddValue("current-fn", CurrentFn);
        builder.AddValue("original-type", OriginalType);
        builder.AddValue("current-type", CurrentType);
        builder.AddValue("object-type", ObjectType);
        builder.AddValue("indoor", Indoor);

        if (HasField) builder.AddValue("has-field", true);
        if (HasMirror) builder.AddValue("has-mirror", true);
        if (HasFrame) builder.AddValue("has-frame", true);

        if (SupportSize != null) AddSizePins("support-", SupportSize, builder);
        if (FieldSize != null) AddSizePins("field-", FieldSize, builder);
        if (MirrorSize != null) AddSizePins("mirror-", MirrorSize, builder);
        if (HasDamnatio) builder.AddValue("has-damnatio", true);

        // counts
        foreach (DecoratedCount count in Counts)
            builder.AddValue("c-" + count.Id, count.Value);

        // features
        foreach (string feature in Features)
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
                "material",
                "The material of the support."),
            new DataPinDefinition(DataPinValueType.String,
                "original-fn",
                "The original function of the support."),
            new DataPinDefinition(DataPinValueType.String,
                "current-fn",
                "The current function of the support."),
            new DataPinDefinition(DataPinValueType.String,
                "original-type",
                "The original type of the support object."),
            new DataPinDefinition(DataPinValueType.String,
                "current-type",
                "The current type of the support object."),
            new DataPinDefinition(DataPinValueType.String,
                "object-type",
                "The type of the support object."),
            new DataPinDefinition(DataPinValueType.Boolean,
                "indoor",
                "True when support is indoor."),
            new DataPinDefinition(DataPinValueType.Boolean,
                "has-field",
                "True when support has writing field."),
            new DataPinDefinition(DataPinValueType.Boolean,
                "has-mirror",
                "True when support has writing mirror."),
            new DataPinDefinition(DataPinValueType.Boolean,
                "has-frame",
                "True when support mirror has a frame."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "support-w",
                "The width of the support."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "support-h",
                "The height of the support."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "support-d",
                "The depth of the support."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "field-w",
                "The width of the writing field."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "field-h",
                "The height of the writing field."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "field-d",
                "The depth of the writing field."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "mirror-w",
                "The width of the writing mirror."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "mirror-h",
                "The height of the writing mirror."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "mirror-d",
                "The depth of the writing mirror."),
            new DataPinDefinition(DataPinValueType.Boolean,
                "has-damnatio",
                "True when support has a damnatio memoriae."),
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

        if (!string.IsNullOrEmpty(CurrentFn)) sb.Append(": ").Append(CurrentFn);
        if (!string.IsNullOrEmpty(OriginalFn))
            sb.Append(" (").Append(OriginalFn).Append(')');

        sb.Append(": ").Append(CurrentType).Append(", ").Append(OriginalType);

        if (SupportSize != null) sb.Append(" - ").Append(SupportSize);

        return sb.ToString();
    }
}
