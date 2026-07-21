# Cadmus Epigraphy

- parts:
  - [EpiScriptsPart](docs/epi-scripts.md)
  - [EpiSupportPart](docs/epi-support.md)
  - [EpiFormulaPatternsPart](docs/epi-formula-patterns.md)
  - [EpiSignsPart](docs/epi-signs.md)
  - [EpiSupportFrrPart](docs/epi-support-frr.md)
  - [EpiTechniquePart](docs/epi-technique.md)
- fragments:
  - [EpiLigaturesLayerFragment](docs/fr.epi-ligatures.md)

These libraries include some essential epigraphic components for Cadmus. The components will be reused in a wider context.

For instance, an inscription item might include parts like:

(a) general:

- `ExternalIdsPart`: all the IDs linked to the item.
- `MetadataPart`: general purpose metadata.
- `AssertedLocationsPart`: geographical location(s).
- `AssertedToponymsPart`: toponym(s).
- `HistoricalDatePart`: date.
- [EpiSupportPart](docs/epi-support.md)
- [EpiSupportFrrPart](docs/epi-support-frr.md)
- [EpiScriptsPart](docs/epi-scripts.md)
- [EpiSignsPart](docs/epi-signs.md)
- [EpiTechniquePart](docs/epi-technique.md)

(b) classification:

- `CategoriesPart`: general thematic tags from some taxonomy.
- `IndexKeywordsPart`: multiple-language keywords which can be grouped under several sections ("indexes").

(c) comment:

- `CommentPart`: generic comment.
- `NotePart`: free text note. Might be useful for redactional purposes.

(d) references:

- `DocReferencesPart`: short documentary references.
- `BibliographyPart`.

(e) text:

- `TokenTextPart`: text or a part of it when required.
- layer of `ApparatusLayerFragment`'s: critical apparatus.
- layer of `OrthographyLayerFragment`'s: annotate and categorize linguistic phenomena reflected in orthography.
- layer of `CommentLayerFragment`'s: comment specific words of the text.
- layer of [EpiLigaturesLayerFragment](./docs/fr.epi-ligatures.md)'s: annotate ligatures across 2 or more letters.
- layer of `ChronologyLayerFragment`'s: annotate dates on specific dateable expressions.

Also, you might want to add epigraphic formula items, having an [EpiFormulaPatternsPart](docs/epi-formula-patterns.md) to describe its patterns, and other generic parts for its metadata, categories, keywords, datation, etc.
