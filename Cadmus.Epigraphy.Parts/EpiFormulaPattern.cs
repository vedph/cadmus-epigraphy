using System.Collections.Generic;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// A single pattern in an epigraphic formula, built of
/// <see cref="EpiFormulaToken"/>'s.
/// </summary>
public class EpiFormulaPattern
{
    /// <summary>
    /// Gets or sets the optional EID eventually used to identify this pattern.
    /// </summary>
    public string? Eid { get; set; }

    /// <summary>
    /// Gets or sets the language. Usually this is an ISO639-3 identifier.
    /// </summary>
    public string Language { get; set; }

    /// <summary>
    /// Gets or sets an optional tag.
    /// </summary>
    public string? Tag { get; set; }

    /// <summary>
    /// Gets or sets the token(s) this formula is built of.
    /// </summary>
    public List<EpiFormulaToken> Tokens { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpiFormulaPattern"/> class.
    /// </summary>
    public EpiFormulaPattern()
    {
        Language = "";
        Tokens = new List<EpiFormulaToken>();
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"{Language}: " + (Tokens?.Count > 0? string.Join("; ", Tokens) : "");
    }
}
