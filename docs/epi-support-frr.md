# Epigraphic Support Fragments

🔑 `it.vedph.epigraphy.support-frr`.

Description of the fragments of an epigraphic support.

- fragments (`EpiSupportFr[]`):
  - id\* (`string`): the unique fragment identifier (e.g. `A`). This is unique in the context of its part.
  - shelfmark (`string`): the shelfmark number for this fragment.
  - isLost (`boolean`)
  - size (🧱 [PhysicalSize](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-size.md)):
    - tag (string 📚 `physical-size-tags`)
    - w (🧱 [PhysicalDimension](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-dimension.md)):
      - value\* (number)
      - unit\* (string 📚 `physical-size-units`)
      - tag (string 📚 `physical-size-dim-tags`)
    - h (🧱 [PhysicalDimension](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-dimension.md))
    - d (🧱 [PhysicalDimension](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-dimension.md))
    - note (`string`)
  - rowCount (`short`): the count of rows in the ideal grid overlaid as a bounding rectangle over the inscription.
  - columnCount (`short`): the count of columns of the ideal grid overlaid as a bounding rectangle over the inscription.
  - location (`string`): the location. This is represented by one or more spreadsheet-like coordinates (e.g. `A1`) separated by spaces, each corresponding to a grid's cell. Usually their order reflects the reading order of the remnant text.
  - cellMappings (`EpiSupportFrCellMapping[]`): mapping between some cells of a fragment and the corresponding text in the inscribed surface:
    - location (`string`): the location of the mapped text in the ideal grid of the inscribed surface. This is one or more spreadsheet-like coordinates.
    - headText (`string`): the initial portion of the text covered by this fragment, used for a more human-friendly reference (e.g. `dis manibus`...).
    - headTextLoc (`string`): the location of the first character of the text covered by this fragment with reference to the inscription. This is typically a Cadmus location, e.g. `1.3@4` meaning line 1, token 3, 4th character; but it could be anything, or just omitted, especially when you have no text in the database.
    - tailText (`string`): the final portion of the text covered by this fragment, used for a more human-friendly reference (e.g. ...`vale`).
    - tailTextLoc (`string`): the location of the last character of the text covered by this fragment with reference to the inscription. This is typically a Cadmus location, e.g. `2.4@2` meaning line 2, token 4, 2nd character; but it could be anything, or just omitted, especially when you have no text in the database.
  - note (`string`)

Apart from generic metadata, the fragment model location is based on an ideal grid overlaid as a bounding rectangle over the reconstructed surface of the material support. This is a traditional approach for representing the approximate location of fragments on the reconstructed support; for instance, Manzella 1987 fig.205 uses a fixed 3x3 grid and names each resulting cell with a letter from A to I: ABC in the first row, DEF in the second, GHI in the third. Once defined these grid coordinates, the fragments layout can be defined with these letters, e.g. AEC means that the fragment covers the first cell of the first row, the second cell of the second row, and the third cell of the first row, assuming that this 3x3 grid is overlaid on top of the integral surface of the inscription.

In our model, we prefer a more flexible approach, where you can freely define the grid size, and then use alphanumeric coordinates to locate each cell, like in a spreadsheet. So, the model has the rows and columns count defining the grid's size, and a location with one or more coordinates.

> 💡 You can refer to the bricks demo page for the physical grid component to play with a UI representing this model at <https://cadmus-bricks.fusi-soft.com/mat/physical-grid>.
