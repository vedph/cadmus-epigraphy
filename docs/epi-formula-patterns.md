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

This model requires some explanation: a formula consists in 1 or more patterns. Each pattern is composed by 1 or more tokens. A token in this context is any string, whether it consists of a single word or of many words.

A pattern has a set of metadata like optional ID, language, and generic tag for any additional classification purpose.

Tokens are of 2 types: literals, which are just string values; and placeholders, which consist of a single arbitrarily defined ID used as a named placeholder. For instance, in "dis manibus X" X is the placeholder for the deceased person's name.

Each token has an ordered set of tags, which define its coordinates in the knowledge domain used as the reference (e.g. part of speech, case, gender, number, etc.), and one ore more values (typically, each corresponding to a word for literal tokens; placeholders just have a single value representing their ID). Any token can be marked as optional in the pattern.

For instance, say we want to define the patterns of a trivial formula like “dis manibus” + genitive of the deceased. This formula has a single pattern consisting of 3 tokens, summarized as:

1. `<n.case.d dis>`: noun, dative: literal "dis".
2. `<n.case.d manibus>`: noun, dative: literal "manibus".
3. `<n.case.g $deceased_name>`: noun, genitive: placeholder for the name of the deceased person.

For each token, you build a tagset by concatenating entries picked from a hierarchical thesaurus. In the above example, each entry ID picked from this thesaurus is separated by a dot: `n`=noun, `case`, `d`=dative.
