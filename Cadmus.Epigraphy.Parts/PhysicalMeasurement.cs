using Cadmus.Mat.Bricks;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// A single physical measurement with the name of the measured object.
/// </summary>
/// <seealso cref="PhysicalDimension" />
public class PhysicalMeasurement : PhysicalDimension
{
    /// <summary>
    /// Gets or sets the name of the measured object.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return Name + "=" + base.ToString();
    }
}
