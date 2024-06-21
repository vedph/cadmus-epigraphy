using Cadmus.Mat.Bricks;
using System.Collections.Generic;
using System.Text;

namespace Cadmus.Epigraphy.Parts;

/// <summary>
/// A graphical sign in an epigraphic text. This is a sign of any sort,
/// either alphabetic or not.
/// </summary>
public class EpiSign
{
    /// <summary>
    /// Gets or sets the sign identifier. This is a string uniquely identifying
    /// the sign, e.g. <c>A</c> or <c>alpha</c> for letter alpha, or a more
    /// refined classification like <c>alpha_broken_stroke</c>. If you have
    /// multiple hands, use a naming convention for hands, e.g. <c>A @hand1</c>
    /// to represent sign <c>A</c> as written by hand 1. The identifier must
    /// be unique in the scope of its part.
    /// </summary>
    /// <remarks>
    /// Should you want to provide images, you can just use the sign ID plus
    /// the inscription ID for naming your image file(s). If inscription ID is
    /// <c>X</c> and sign ID is <c>Y</c>, and we name 2 photographs and 1
    /// drawing like e.g. <c>X.Y_ph_001.jpg</c>, <c>X.Y_ph_002.jpg</c>,
    /// <c>X.Y_dr_001.png</c>, we will already have an implicit linking without
    /// touching the database whenever collecting new images.
    /// </remarks>
    public string Id { get; set; } = "";

    /// <summary>
    /// Gets or sets the features, an optional set of predefined features from
    /// a thesaurus where you might want to collect recurring graphical features
    /// you want to use as tags for this sign.This can be a convenient way for
    /// summarizing the salient points stated in the free text description,
    /// thus making them searchable.
    /// </summary>
    public List<string>? Features { get; set; }

    /// <summary>
    /// Gets or sets a free text description with formatting (usually Markdown).
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the sizes keyed by measured element: you can add as many
    /// sizes as you want for each specific trait you are measuring.For instance,
    /// a size for vertical ascender, another size for total width, etc.Keys
    /// are either free or come from a thesaurus when defined.
    /// </summary>
    public Dictionary<string, PhysicalSize>? Sizes { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new(Id);

        if (Features?.Count > 0)
            sb.Append(": ").AppendJoin(", ", Features);

        if (Sizes?.Count > 0)
            sb.Append($" - sizes: {Sizes.Count}");

        return sb.ToString();
    }
}
