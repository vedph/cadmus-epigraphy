using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Cadmus.Core;
using Cadmus.Mat.Bricks;
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
    /// Gets or sets the original function of the support.
    /// </summary>
    public string? OriginalFn { get; set; }

    /// <summary>
    /// Gets or sets the current function of the support.
    /// </summary>
    public string? CurrentFn { get; set; }

    /// <summary>
    /// Gets or sets the type of the object representing or including
    /// the support.
    /// </summary>
    public string? ObjectType { get; set; }

    /// <summary>
    /// Gets or sets the type of the support.
    /// </summary>
    public string? SupportType { get; set; }

    /// <summary>
    /// Gets or sets the support's material.
    /// </summary>
    public string? Material { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this graffiti is indoor.
    /// </summary>
    public bool Indoor { get; set; }

    /// <summary>
    /// Gets or sets the support's size.
    /// </summary>
    public PhysicalSize? Size { get; set; }

    /// <summary>
    /// Gets or sets a short note about the support's conservation state.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Gets or sets the optional last seen date.
    /// </summary>
    public DateTime? LastSeen { get; set; }

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

        builder.AddValue("original-fn", OriginalFn);
        builder.AddValue("current-fn", CurrentFn);
        builder.AddValue("object-type", ObjectType);
        builder.AddValue("support-type", SupportType);
        builder.AddValue("indoor", Indoor);
        builder.AddValue("material", Material);
        if (Size != null)
        {
            // Currently we assume all the sizes have the same unit.
            // Alternatively, we should know in advance which are the
            // allowed units, and automatically convert them into a unique
            // one.
            if (Size.W?.Value > 0)
            {
                builder.AddValue("width",
                    Size.W.Value.ToString("0.00", CultureInfo.InvariantCulture));
            }
            if (Size.H?.Value > 0)
            {
                builder.AddValue("height",
                    Size.H.Value.ToString("0.00", CultureInfo.InvariantCulture));
            }

            if (Size.D?.Value > 0)
            {
                builder.AddValue("depth",
                    Size.D.Value.ToString("0.00", CultureInfo.InvariantCulture));
            }
        }
        if (LastSeen != null)
            builder.AddValue("last-seen", LastSeen.Value.ToString("yyyy-MM-dd"));

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
            new DataPinDefinition(DataPinValueType.String,
                "original-fn",
                "The original function of the support."),
            new DataPinDefinition(DataPinValueType.String,
                "current-fn",
                "The current function of the support."),
            new DataPinDefinition(DataPinValueType.String,
                "object-type",
                "The type of the support object."),
            new DataPinDefinition(DataPinValueType.String,
                "support-type",
                "The type of the support."),
            new DataPinDefinition(DataPinValueType.Boolean,
                "indoor",
                "True when support is indoor."),
            new DataPinDefinition(DataPinValueType.String,
                "material",
                "The material of the support."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "width",
                "The width of the support."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "height",
                "The height of the support."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "depth",
                "The depth of the support."),
            new DataPinDefinition(DataPinValueType.String,
                "last-seen",
                "The last-seen date in form YYYY-MM-DD."),
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

        sb.Append("[EpiSupport]");

        sb.Append(CurrentFn);
        if (!string.IsNullOrEmpty(OriginalFn))
            sb.Append(" (").Append(OriginalFn).Append(')');
        sb.Append(": ").Append(ObjectType).Append(", ").Append(SupportType);

        if (Size != null) sb.Append(" - ").Append(Size);

        return sb.ToString();
    }
}
