# Epigraphic Support

🔑 `it.vedph.epigraphy.support`.

- material\* (`string` 📚 `epi-support-materials`)
- originalFn (`string` 📚 `epi-support-functions`)
- currentFn (`string` 📚 `epi-support-functions`)
- originalType (`string` 📚 `epi-support-types`)
- currentType (`string` 📚 `epi-support-types`)
- objectType (`string` 📚 `epi-support-object-types`)
- indoor (`boolean`)
- supportSize (`PhysicalSize`)
- hasField (`boolean`)
- fieldSize (`PhysicalSize`)
- hasMirror (`boolean`)
- mirrorSize (`PhysicalSize`)
- hasFrame (`boolean`)
- frame (`string`)
- counts (`DecoratedCount[]`, 📚 `epi-support-count-types`): e.g. rows, columns, etc.
- features (📚 `epi-support-features`): e.g. ruling, etc.
- hasDamnatio (`boolean`)
- note (`string`, 5000)

## Old Model

🔑 `it.vedph.epigraphy.support.old`.

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
