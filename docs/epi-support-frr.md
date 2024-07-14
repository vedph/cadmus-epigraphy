# Epigraphic Support Fragments

🔑 `it.vedph.epigraphy.support-frr`.

- fragments (`EpiSupportFr[]`):
  - id\* (`string`)
  - shelfmark (`string`)
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
  - rowCount (`short`)
  - columnCount (`short`)
  - location (`string`)
  - cellMappings (`EpiSupportFrCellMapping[]`):
    - location (`string`)
    - headText (`string`)
    - headTextLoc (`string`)
    - tailText (`string`
    - tailTextLoc (`string`)
  - note (`string`)
