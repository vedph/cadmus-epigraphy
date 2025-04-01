using System.Collections.Generic;
using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// The writing system and script used in an inscription.
/// </summary>
public class EpiScript
{
    /// <summary>
    /// Gets or sets the writing system (usually from <c>epi-script-systems</c>,
    /// mostly ISO 15924, lowercased, e.g. <c>latn</c>, <c>grek</c>).
    /// </summary>
    public string? System { get; set; }

    /// <summary>
    /// Gets or sets the script type (e.g. gothic, merchant, etc.), usually
    /// from <c>epi-scripts</c>.
    /// </summary>
    public string Script { get; set; } = "";

    /// <summary>
    /// Gets or sets the prevalent casing, when applicable (e.g. uppercase,
    /// lowercase, uppercase + lowercase, etc.), usually from
    /// <c>epi-script-casings</c>.
    /// </summary>
    public string? Casing { get; set; }

    /// <summary>
    /// Gets or sets the script features (e.g. abbreviations, ligatures,
    /// punctuation, etc.), usually from <c>epi-script-features</c>.
    /// </summary>
    public HashSet<string> Features { get; set; } = [];

    /// <summary>
    /// Gets or sets a generic note.
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
        StringBuilder sb = new();

        if (!string.IsNullOrEmpty(System)) sb.Append(System).Append(' ');
        if (!string.IsNullOrEmpty(Script)) sb.Append(Script);

        return sb.ToString();
    }
}
