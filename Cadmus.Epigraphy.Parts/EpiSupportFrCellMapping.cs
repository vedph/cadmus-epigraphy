using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// Mapping between some cells of an <see cref="EpiSupportFr"/> and the
/// corresponding text in the inscribed surface.
/// </summary>
public class EpiSupportFrCellMapping
{
    /// <summary>
    /// Gets or sets the location of the mapped text in the ideal grid of
    /// the inscribed surface. This is one or more spreadsheet-like coordinates,
    /// as for <see cref="EpiSupportFr.Location"/>.
    /// </summary>
    public string Location { get; set; } = "";

    /// <summary>
    /// Gets or sets the initial portion of the text covered by this fragment,
    /// used for a more human-friendly reference (e.g. <c>dis manibus</c>...).
    /// </summary>
    public string? HeadText { get; set; }

    /// <summary>
    /// Gets or sets the location of the first character of the text covered
    /// by this fragment with reference to the inscription. This is typically
    /// a Cadmus location, e.g. <c>1.3@4</c> meaning line 1, token 3, 4th
    /// character; but it could be anything, or just omitted, especially when
    /// you have no text in the database.
    /// </summary>
    public string? HeadTextLoc { get; set; }

    /// <summary>
    /// Gets or sets the final portion of the text covered by this fragment,
    /// used for a more human-friendly reference (e.g. ...<c>vale</c>).
    /// </summary>
    public string? TailText { get; set; }

    /// <summary>
    /// Gets or sets the location of the last character of the text covered
    /// by this fragment with reference to the inscription. This is typically
    /// a Cadmus location, e.g. <c>2.4@2</c> meaning line 2, token 4, 2nd
    /// character; but it could be anything, or just omitted, especially when
    /// you have no text in the database.
    /// </summary>
    public string? TailTextLoc { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new(Location);

        if (!string.IsNullOrEmpty(HeadTextLoc))
            sb.Append(" [").Append(HeadTextLoc).Append(']');

        if (!string.IsNullOrEmpty(HeadText))
            sb.Append(' ').Append(HeadText);

        if (!string.IsNullOrEmpty(TailTextLoc) || !string.IsNullOrEmpty(TailText))
            sb.Append(" ... ");

        if (!string.IsNullOrEmpty(TailTextLoc))
            sb.Append(" [").Append(TailTextLoc).Append(']');

        if (!string.IsNullOrEmpty(TailText))
            sb.Append(' ').Append(TailText);

        return sb.ToString();
    }
}
