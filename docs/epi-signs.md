# Epigraphic Signs

🔑 `it.vedph.epigraphy.signs`.

- signs (`EpiSign[]`):
  - id\* (`string`)
  - features (`string[]` 📚 `epi-signs-features`)
  - description (`string`, Markdown)
  - measurements (🧱 [PhysicalMeasurement[]](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-measurement.md)):
    - name\* (string 📚 `epi-signs-measure-names`)
    - value\* (number)
    - unit\* (string 📚 `physical-size-units`)
    - tag (string 📚 `physical-size-dim-tags`)
