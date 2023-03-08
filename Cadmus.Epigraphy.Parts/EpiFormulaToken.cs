using System.Collections.Generic;
using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// A single token inside an epigraphic formula. This can be a literal value
/// (or values), or a placeholder, and in both cases it can be optional or
/// required in the context of the formula. It usually has one or more linguistic
/// tags, and may include an optional free text note.
/// </summary>
public class EpiFormulaToken
{
    /// <summary>
    /// Gets or sets the linguistic tags for this token. Usually these tags
    /// are hierarchically sorted.
    /// </summary>
    public List<string> Tags { get; set; }

    /// <summary>
    /// Gets or sets one or more alternative values for this token. When the
    /// token is a placeholder, there will be just a single value.
    /// </summary>
    public List<string> Values { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this token is optional in the
    /// context of its formula.
    /// </summary>
    public bool IsOptional { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this token is a placeholder.
    /// In this case its value represents the placeholder name (an arbitrary
    /// identifier).
    /// </summary>
    public bool IsPlaceholder { get; set; }

    /// <summary>
    /// Gets or sets an optional note.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EpiFormulaToken"/> class.
    /// </summary>
    public EpiFormulaToken()
    {
        Tags = new List<string>();
        Values = new List<string>();
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

        sb.Append(IsOptional ? '[' : '<');
        if (Tags?.Count > 0)
        {
            sb.AppendJoin(".", Tags);
            sb.Append(' ');
        }
        if (IsPlaceholder) sb.Append('$');
        if (Values?.Count > 0) sb.AppendJoin("/", Values);
        sb.Append(IsOptional ? ']' : '>');
        if (!string.IsNullOrEmpty(Note)) sb.Append(" {").Append(Note).Append('}');

        return sb.ToString();
    }
}
