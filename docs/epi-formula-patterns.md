# Epigraphic Formula Patterns

🔑 `it.vedph.epigraphy.formula-patterns`.

- patterns (`EpiFormulaPattern[]`):
  - eid (`string`)
  - language\* (`string` 📚 `epi-formula-pattern-languages`)
  - tag (`string` 📚 `epi-formula-pattern-tags`)
  - tokens (`EpiFormulaToken[]`):
    - tags (`string[]` 📚 `epi-formula-token-tags`, hierarchical)
    - values (`string[]`)
    - isOptional (`bool`)
    - isPlaceholder (`bool`)
    - note (`string`)
