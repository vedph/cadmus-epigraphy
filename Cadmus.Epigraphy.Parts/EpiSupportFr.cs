using Cadmus.Mat.Bricks;
using System.Collections.Generic;
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
    /// Gets or sets the count of rows in the ideal grid overlaid as a bounding
    /// rectangle over the inscription.
    /// </summary>
    public short RowCount { get; set; }

    /// <summary>
    /// Gets or sets the count of columns of the ideal grid overlaid as a
    /// bounding rectangle over the inscription.
    /// </summary>
    public short ColumnCount { get; set; }

    /// <summary>
    /// Gets or sets the location. This is represented by one or more
    /// spreadsheet-like coordinates (e.g. A1) separated by spaces, each
    /// corresponding to a grid's cell. Usually their order reflects the
    /// reading order of the remnant text.
    /// </summary>
    public string Location { get; set; } = "";

    /// <summary>
    /// Gets or sets the cell mappings.
    /// </summary>
    public List<EpiSupportFrCellMapping>? CellMappings { get; set; }

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

        if (RowCount > 0)
        {
            sb.Append(" [").Append(RowCount).Append('x').Append(ColumnCount).Append(']');
            if (!string.IsNullOrEmpty(Location)) sb.Append(' ').Append(Location);
        }

        return sb.ToString();
    }
}
