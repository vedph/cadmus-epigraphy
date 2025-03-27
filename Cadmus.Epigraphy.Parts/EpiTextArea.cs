using Cadmus.Mat.Bricks;
using System.Collections.Generic;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// The area including the text of an inscription, whether it has been
/// prepared for this purpose, or it was just used without preparation.
/// For instance, this corresponds to Italian terms like campo and specchio,
/// with their various sub-types (campo aperto, specchio, specchio di corredo,
/// specchio aggiunto, specchio rupestre, and the like).
/// </summary>
public class EpiTextArea
{
    /// <summary>
    /// Gets or sets the optional entity ID for this area.
    /// </summary>
    public string? Eid { get; set; }

    /// <summary>
    /// Gets or sets the area type. Usually from thesaurus
    /// <c>epi-support-text-area-types</c>.
    /// </summary>
    public string Type { get; set; } = "";

    /// <summary>
    /// Gets or sets the layout (e.g. 2-columns, sparse lines, etc.). Usually
    /// from thesaurus <c>epi-support-text-area-layouts</c>.
    /// </summary>
    public string? Layout { get; set; }

    /// <summary>
    /// Gets or sets the area size.
    /// </summary>
    public PhysicalSize? Size { get; set; }

    /// <summary>
    /// Gets or sets the area features, usually from thesaurus
    /// <c>epi-support-text-area-features</c>.
    /// </summary>
    public HashSet<string>? Features { get; set; }

    /// <summary>
    /// Gets or sets the type of the frame, when there is any. Usually from
    /// thesaurus <c>epi-support-text-area-frame-types</c>.
    /// </summary>
    public string? FrameType { get; set; }

    /// <summary>
    /// Gets or sets the frame description.
    /// </summary>
    public string? FrameDescription { get; set; }

    /// <summary>
    /// Gets or sets an optional short note about the area.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"{Type}" + (Size != null ? $": {Size}" : "");
    }
}
