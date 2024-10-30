# Epigraphic Writing

🔑 `it.vedph.epigraphy.writing`.

- system (`string` 📚 `epi-writing-systems`, usually ISO 15924 lowercase)
- script (`string` 📚 `epi-writing-scripts`)
- casing (`string` 📚 `epi-writing-casings`)
- features (`string[]` 📚 `epi-writing-features`)
- note (`string`)

## Old Model

🔑 `it.vedph.epigraphy.writing.old`.

- system (`string` 📚 `epi-writing-systems`, usually ISO 15924 lowercase)
- type (`string` 📚 `epi-writing-types`)
- technique (`string` 📚 `epi-writing-techniques`)
- tool (`string` 📚 `epi-writing-tools`)
- frameType (`string` 📚 `epi-writing-frame-types`)
- counts (`DecoratedCount[]`):
  - id\* (`string` 📚 `decorated-count-ids`)
  - tag (`string` 📚 `decorated-count-tags`)
  - value\* (`number`)
  - note (`string`)
- figType (`string` 📚 `epi-writing-fig-types`)
- figFeatures (`string[]` 📚 `epi-writing-fig-features`)
- scriptFeatures (`string[]` 📚 `epi-writing-script-features`)
- languages (`string[]` 📚 `epi-writing-languages`, usually ISO 639-3)
- hasPoetry (`boolean`)
- metres (`string[]` 📚 `epi-writing-metres`)
