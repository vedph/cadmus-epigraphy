# Epigraphic Writing

🔑 `it.vedph.epigraphy.writing`.

- system (`string` 📚 `epi-writing-systems`, usually ISO 15924 lowercase)
- script (`string` 📚 `epi-writing-scripts`)
- casing (`string` 📚 `epi-writing-casings`)
- features (`string[]` 📚 `epi-writing-features`)
- note (`string`)

The new model has been streamlined to preserve only the strictly required data for its traditional description:

- a writing system (for cases where e.g. you write Greek with a Latin system; this is backed by a thesaurus, and if no such thesaurus exists, the corresponding UI is simply hidden).
- a script (e.g. gothic, romanesque, etc.; backed by a thesaurus).
- a prevalent casing, when applicable (backed by a thesaurus: e.g. lowercase, uppercase, lowercase and uppercase, etc.)
- a custom set of features, backed by a thesaurus. You can toggle each of these features on or off to describe more details about the script (e.g. the presence of abbreviations, ligatures, included letters, punctuation, etc.). This allows a highly customizable set of descriptors tailored to each project.
- a generic free text note.

## Comparison with the Old Model

The counts of the old model have been moved into the [new support model](epi-support.md), and apply to all those counts which are strictly related to its layout definition, like e.g. the number of rows or columns. Should you have other types of less-related counts, you can just add the generic [decorated counts part](https://github.com/vedph/cadmus-general/blob/master/docs/decorated-counts.md). This avoids "polluting" the writing part with counts if not required.

Techniques and tools have been moved into their [own part](https://github.com/vedph/cadmus-epigraphy/blob/master/docs/epi-technique.md), because this allows this part to optionally grow without affecting the writing part, and also allows users who are not interested in these more technical details to dispose of them without having to define a new part of their own for writing.

The same applies to figurative data, which presently do not require any specific part, as they are already covered by the generic [categories part](https://github.com/vedph/cadmus-general/blob/master/docs/categories.md) for figurative features (which allows for both flat and tree-like hierarchical features), and optionally by the `features` property of the writing part (you just have to enrich the thesaurus if you still want to place figurative features in the same part used to describe the writing).

Languages too can be moved into a [categories part](https://github.com/vedph/cadmus-general/blob/master/docs/categories.md), with its properly defined thesaurus. This also has the benefit that categories allow also for non-flat, tree-like lists, which means that you might even include in the same part several different language code standards, e.g. BCP47 and Glottolog (in this case, these would be two branches of the same tree, each with its own entries).

Finally, the presence of poetry can be just a feature; and metres have been removed, reserving them to a more specialized part which might well include more data about the metrical scheme and relevant prosodical features, and as such is not even limited to the epigraphic realm.

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
