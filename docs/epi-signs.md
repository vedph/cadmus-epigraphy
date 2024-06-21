# Epigraphic Signs

🔑 `it.vedph.epigraphy.signs`.

- signs (`EpiSign[]`):
- id\* (`string`)
- features (`string[]` 📚 `epi-signs-features`)
- description (`string`, Markdown)
- sizes (dictionary of `PhysicalSize` keyed by `string`):
  - tag (string 📚 `physical-size-tags`)
  - w (`PhysicalDimension`):
    - value\* (number)
    - unit\* (string 📚 `physical-size-units`)
    - tag (string 📚 `physical-size-dim-tags`)
  - h (`PhysicalDimension`)
  - d (`PhysicalDimension`)
  - note (`string`)
