# Epigraphic Support

🔑 `it.vedph.epigraphy.support`.

- material\* (`string` 📚 `epi-support-materials`)
- originalFn (`string` 📚 `epi-support-functions`)
- currentFn (`string` 📚 `epi-support-functions`)
- objectType (`string` 📚 `epi-support-object-types`)
- supportType (`string` 📚 `epi-support-types`)
- indoor (`boolean`)
- size (`PhysicalSize`):
  - tag (string 📚 `physical-size-tags`)
  - w (`PhysicalDimension`):
    - value\* (number)
    - unit\* (string 📚 `physical-size-units`)
    - tag (string 📚 `physical-size-dim-tags`)
  - h (`PhysicalDimension`)
  - d (`PhysicalDimension`)
  - note (`string`)
- state (`string` 📚 `epi-support-states`)
- lastSeen (`date`)
