using Cadmus.Mat.Bricks;
using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// A physical fragment of a broken epigraphic material support.
/// </summary>
public class EpiSupportFr
{
    /// <summary>
    /// Gets or sets the unique fragment identifier (e.g. <c>A</c>). This is
    /// unique in the context of its part.
    /// </summary>
    public string Id { get; set; } = "";

    /// <summary>
    /// Gets or sets the shelfmark number for this fragment.
    /// </summary>
    public string? Shelfmark { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this fragment was lost.
    /// </summary>
    public bool IsLost { get; set; }

    /// <summary>
    /// Gets or sets the fragment's size.
    /// </summary>
    public PhysicalSize? Size { get; set; }

    /// <summary>
    /// Gets or sets the row number (1-N) for the relative location of this
    /// fragment in the inscription, represented as a table where each line
    /// is a row.
    /// </summary>
    public short Row { get; set; }

    /// <summary>
    /// Gets or sets the column number (1-N) for the relative location of this
    /// fragment in the inscription, represented as a table where each line
    /// is a row.
    /// </summary>
    public short Column { get; set; }

    /// <summary>
    /// Gets or sets the rows span for this fragment location.
    /// </summary>
    public short RowSpan { get; set; }

    /// <summary>
    /// Gets or sets the columns span for this fragment location.
    /// </summary>
    public short ColumnSpan { get; set; }

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
    /// Gets or sets a short free text note about this fragment.
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
        StringBuilder sb = new(Id);

        if (!string.IsNullOrEmpty(Shelfmark))
            sb.Append(" [").Append(Shelfmark).Append(']');

        if (IsLost) sb.Append('\u2020');

        if (Size != null) sb.Append(": ").Append(Size);

        if (Row > 0)
        {
            sb.Append(" (R").Append(Row);
            if (RowSpan > 0) sb.Append('×').Append(RowSpan);
            sb.Append('C').Append(Column);
            if (ColumnSpan > 0) sb.Append('×').Append(ColumnSpan);
            sb.Append(')');
        }

        return sb.ToString();
    }
}
