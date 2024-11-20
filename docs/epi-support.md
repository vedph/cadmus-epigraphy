# Epigraphic Support

🔑 `it.vedph.epigraphy.support`.

- material\* (`string` 📚 `epi-support-materials`)
- originalFn (`string` 📚 `epi-support-functions`)
- currentFn (`string` 📚 `epi-support-functions`)
- originalType (`string` 📚 `epi-support-types`)
- currentType (`string` 📚 `epi-support-types`)
- objectType (`string` 📚 `epi-support-object-types`)
- inSitu (`boolean`)
- indoor (`boolean`)
- supportSize (`PhysicalSize`):
  - tag (string 📚 `physical-size-tags`)
  - w (`PhysicalDimension`):
    - value\* (number)
    - unit\* (string 📚 `physical-size-units`)
    - tag (string 📚 `physical-size-dim-tags`)
  - h (`PhysicalDimension`)
  - d (`PhysicalDimension`)
  - note (`string`)
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

## Comparison with the Old Model

More granularity has been added to the size: we now have the support size, and optionally also the writing field and writing mirror sizes, when applicable.

Some generic data about frame have been added. Should one need much more details about frames, a dedicated part can be defined.

A counts property with layout-specific counts (e.g. rows or columns number) has been introduced here. For more generic counts not strictly related to the support you can also use the generic [decorated counts part](https://github.com/vedph/cadmus-general/blob/master/docs/decorated-counts.md).

A customizable, thesaurus-backed set of features has been added to add any features you might want to attach to the support description (e.g. the presence of ruling). _Damnatio memoriae_ instead is not defined as a generic features from this set, and has been preserved as a standalone feature, because it is related to the physical preservation status.

A generic free text note has been added.

The last seen date has been moved to the generic [physical preservation states part](https://github.com/vedph/cadmus-general/blob/master/docs/physical-states.md).

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
