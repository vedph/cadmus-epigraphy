# Epigraphic Support Fragments

🔑 `it.vedph.epigraphy.support-frr`.

- fragments (`EpiSupportFr[]`):
  - id\* (`string`): the unique fragment identifier (e.g. `A`). This is unique in the context of its part.
  - shelfmark (`string`): the shelfmark number for this fragment.
  - isLost (`boolean`)
  - size (`PhysicalSize`):
    - tag (string 📚 `physical-size-tags`)
    - w (`PhysicalDimension`):
      - value\* (number)
      - unit\* (string 📚 `physical-size-units`)
      - tag (string 📚 `physical-size-dim-tags`)
    - h (`PhysicalDimension`)
    - d (`PhysicalDimension`)
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
