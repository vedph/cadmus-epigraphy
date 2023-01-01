using Cadmus.Core;
using Cadmus.Refs.Bricks;
using Fusi.Tools.Config;
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
    /// Gets or sets the writing system (usually ISO 15924, lowercased).
    /// </summary>
    public string? System { get; set; }

    /// <summary>
    /// Gets or sets the writing type.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the writing technique.
    /// </summary>
    public string? Technique { get; set; }

    /// <summary>
    /// Gets or sets the writing tool.
    /// </summary>
    public string? Tool { get; set; }

    /// <summary>
    /// Gets or sets the type of the frame.
    /// </summary>
    public string? FrameType { get; set; }

    /// <summary>
    /// Gets or sets a set of specific counts, like e.g. rows, columns,
    /// characters per line, etc. The count types usually depend on a
    /// thesaurus.
    /// </summary>
    public List<DecoratedCount> Counts { get; set; }

    /// <summary>
    /// Gets or sets the type of the main figurative element if applicable.
    /// </summary>
    public string? FigType { get; set; }

    /// <summary>
    /// Gets or sets the figurative features: these are usually drawn from a
    /// closed set, e.g. hedera, chrismon, fish, dove, etc.
    /// </summary>
    public List<string> FigFeatures { get; set; }

    /// <summary>
    /// Gets or sets the script features: these are usually drawn from a
    /// closed set, e.g. text, digits, punctuations, ligatures,
    /// abbreviations, monograms, single-letter, undefined-letters,
    /// undefined-drawings.
    /// </summary>
    public List<string> ScriptFeatures { get; set; }

    /// <summary>
    /// Gets or sets the text language(s) (usually ISO 639-3).
    /// </summary>
    public List<string> Languages { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this inscription contains
    /// some poetic text.
    /// </summary>
    public bool HasPoetry { get; set; }

    /// <summary>
    /// Gets or sets the metre(s) used in the poetic text if any.
    /// </summary>
    public List<string> Metres { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GrfWritingPart"/> class.
    /// </summary>
    public EpiWritingPart()
    {
        Counts = new List<DecoratedCount>();
        FigFeatures = new List<string>();
        ScriptFeatures = new List<string>();
        Languages = new List<string>();
        Metres= new List<string>();
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

        builder.AddValue("system", System);
        builder.AddValue("type", Type);
        builder.AddValue("technique", Technique);
        builder.AddValue("tool", Tool);
        builder.AddValue("frame-type", FrameType);
        builder.AddValue("fig-type", FigType);

        builder.AddValue("poetic", HasPoetry);
        builder.AddValues("language", Languages);
        builder.AddValues("metre", Metres);

        if (Counts?.Count > 0)
        {
            foreach (DecoratedCount count in Counts)
                builder.AddValue($"c-{count.Id}", count.Value);
        }
       
        if (FigFeatures?.Count > 0)
            builder.AddValues("fig-feat", FigFeatures);

        if (ScriptFeatures?.Count > 0)
            builder.AddValues("script-feat", ScriptFeatures);

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
                "system",
                "The writing system."),
             new DataPinDefinition(DataPinValueType.String,
                "type",
                "The writing type."),
             new DataPinDefinition(DataPinValueType.String,
                "technique",
                "The writing technique."),
             new DataPinDefinition(DataPinValueType.String,
                "tool",
                "The writing tool."),
             new DataPinDefinition(DataPinValueType.String,
                "frame-type",
                "The frame type."),
             new DataPinDefinition(DataPinValueType.String,
                "fig-type",
                "The main figurative type."),
             new DataPinDefinition(DataPinValueType.String,
                "poetic",
                "True if contains poetic text."),
             new DataPinDefinition(DataPinValueType.String,
                "metre",
                "The metre(s) used in the poetic text."),
             new DataPinDefinition(DataPinValueType.String,
                "language",
                "The language(s) used in the text."),
             new DataPinDefinition(DataPinValueType.String,
                "fig-feat",
                "The figurative feature(s) present."),
             new DataPinDefinition(DataPinValueType.String,
                "script-feat",
                "The script feature(s) present."),
             new DataPinDefinition(DataPinValueType.Integer,
                "c-...",
                "The counts. Each count type has its name."),
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

        sb.Append("[EpiWriting] ").Append(System).Append(' ').Append(Type);
        if (Languages?.Count > 0)
            sb.Append(": ").AppendJoin(", ", Languages);

        return sb.ToString();
    }
}
