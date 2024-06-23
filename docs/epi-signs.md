# Epigraphic Signs

🔑 `it.vedph.epigraphy.signs`.

- signs (`EpiSign[]`):
  - id\* (`string`)
  - features (`string[]` 📚 `epi-signs-features`)
  - description (`string`, Markdown)
  - measurements (`PhysicalMeasurement[]`):
    - name\* (string 📚 `epi-signs-measure-names`)
    - value\* (number)
    - unit\* (string 📚 `physical-size-units`)
    - tag (string 📚 `physical-size-dim-tags`)
