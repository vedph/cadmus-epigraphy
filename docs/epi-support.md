# Epigraphic Support

🔑 `it.vedph.epigraphy.support`.

- material\* (`string` 📚 `epi-support-materials`)
- originalFn (`string` 📚 `epi-support-functions`)
- currentFn (`string` 📚 `epi-support-functions`)
- originalType (`string` 📚 `epi-support-types`)
- currentType (`string` 📚 `epi-support-types`)
- objectType (`string` 📚 `epi-support-object-types`)
- features (📚 `epi-support-features`): e.g. indoor, damnatio, in-situ, etc.
- size (🧱 [PhysicalSize](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-size.md)):
  - tag (string 📚 `physical-size-tags`)
  - w (🧱 [PhysicalDimension](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-dimension.md)):
    - value\* (number)
    - unit\* (string 📚 `physical-size-units`)
    - tag (string 📚 `physical-size-dim-tags`)
  - h (🧱 [PhysicalDimension](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-dimension.md))
  - d (🧱 [PhysicalDimension](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-dimension.md))
  - note (`string`)
- textAreas (`EpiTextArea[]`):
  - eid (`string`)
  - type\* (`string`, 📚 `epi-support-text-area-types`)
  - layout (`string`, 📚 `epi-support-text-area-layouts`)
  - size (`PhysicalSize`)
  - features (`string[]`, 📚 `epi-support-text-area-features`)
  - frameType (`string`, 📚 `epi-support-text-area-frame-types`)
  - frameDescription (`string`)
  - note (`string`)
- counts (🧱 [DecoratedCount[]](https://github.com/vedph/cadmus-bricks/blob/master/docs/decorated-count.md), 📚 `epi-support-count-types`): e.g. rows, columns, etc.
- note (`string`, 5000)

## Old Model 2 (v5)

- material\* (`string` 📚 `epi-support-materials`)
- originalFn (`string` 📚 `epi-support-functions`)
- currentFn (`string` 📚 `epi-support-functions`)
- originalType (`string` 📚 `epi-support-types`)
- currentType (`string` 📚 `epi-support-types`)
- objectType (`string` 📚 `epi-support-object-types`)
- inSitu (`boolean`)
- indoor (`boolean`)
- supportSize (🧱 [PhysicalSize](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-size.md)):
  - tag (string 📚 `physical-size-tags`)
  - w (🧱 [PhysicalDimension](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-dimension.md)):
    - value\* (number)
    - unit\* (string 📚 `physical-size-units`)
    - tag (string 📚 `physical-size-dim-tags`)
  - h (🧱 [PhysicalDimension](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-dimension.md))
  - d (🧱 [PhysicalDimension](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-dimension.md))
  - note (`string`)
- hasField (`boolean`)
- fieldSize (🧱 [PhysicalSize](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-size.md))
- hasMirror (`boolean`)
- mirrorSize (🧱 [PhysicalSize](https://github.com/vedph/cadmus-bricks/blob/master/docs/physical-size.md))
- hasFrame (`boolean`)
- frame (`string`)
- counts (🧱 [DecoratedCount[]](https://github.com/vedph/cadmus-bricks/blob/master/docs/decorated-count.md), 📚 `epi-support-count-types`): e.g. rows, columns, etc.
- features (📚 `epi-support-features`): e.g. ruling, etc.
- hasDamnatio (`boolean`)
- note (`string`, 5000)

👉 Migration from old model 2 (v5) to current model (v6):

- `inSitu`, `indoor`, `hasDamnatio` => `features` (must be in thesaurus)
- `hasFrame`: remove
- `hasField`: remove
- `fieldSize`: add `EpiTextArea`:
  - `type`=corresponding to campo
  - `size`=`fieldSize`
- `hasMirror`: remove
- `mirrorSize`: add `EpiTextArea`:
  - `type`=corresponding to specchio
  - `size`=`mirrorSize`
  - `frameType`=`frame` if single word, else `frameDescription`=`frame`
- `supportSize`: rename in `size`.

## Old Model 1

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
