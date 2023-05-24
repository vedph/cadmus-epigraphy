# Cadmus Epigraphy

- [Cadmus Epigraphy](#cadmus-epigraphy)
  - [Models](#models)
    - [EpiWritingPart](#epiwritingpart)
    - [EpiSupportPart](#episupportpart)
    - [EpiFormulaPatternsPart](#epiformulapatternspart)
    - [EpiLigaturesLayerFragment](#epiligatureslayerfragment)
  - [History](#history)
    - [2.0.0](#200)
    - [1.0.1](#101)
    - [1.0.0](#100)
    - [0.0.2](#002)
    - [0.0.1](#001)

These libraries include some essential epigraphic components for Cadmus. The components will be reused in a wider context.

For instance, an inscription item might include parts like:

(a) general:

- `ExternalIdsPart`: all the IDs linked to the item.
- `MetadataPart`: general purpose metadata.
- `AssertedLocationsPart`: geographical location(s).
- `AssertedToponymsPart`: toponym(s).
- `HistoricalDatePart`: date.
- [EpiSupportPart](#episupportpart)
- [EpiWritingPart](#epiwritingpart)

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
- layer of [EpiLigaturesLayerFragment](#epiligatureslayerfragment)'s: annotate ligatures across 2 or more letters.
- layer of `ChronologyLayerFragment`'s: annotate dates on specific dateable expressions.

Also, you might want to add epigraphic formula items, having an [EpiFormulaPatternsPart](#epiformulapatternspart) to describe its patterns, and other generic parts for its metadata, categories, keywords, datation, etc.

## Models

### EpiWritingPart

Tag: `it.vedph.epigraphy.writing`.

- `system` (string, thesaurus: `epi-writing-systems`, usually ISO 15924 lowercase)
- `type` (string, thesaurus: `epi-writing-types`)
- `technique` (string, thesaurus: `epi-writing-techniques`)
- `tool` (string, thesaurus: `epi-writing-tools`)
- `frameType` (string, thesaurus: `epi-writing-frame-types`)
- `counts` (DecoratedCount[]):
  - `id`\* (string, thesaurus: `decorated-count-ids`)
  - `tag` (string, thesaurus: `decorated-count-tags`)
  - `value`\* (number)
  - `note` (string)
- `figType` (string, thesaurus: `epi-writing-fig-types`)
- `figFeatures` (string[], thesaurus: `epi-writing-fig-features`)
- `scriptFeatures` (string[], thesaurus, `epi-writing-script-features`)
- `languages` (string[], thesaurus: `epi-writing-languages`, usually ISO 639-3)
- `hasPoetry` (boolean)
- `metres` (string[], thesaurus: `epi-writing-metres`)

### EpiSupportPart

Tag: `it.vedph.epigraphy.support`.

- `material`\* (string, thesaurus: `epi-support-materials`)
- `originalFn` (string, thesaurus: `epi-support-functions`)
- `currentFn` (string, thesaurus: `epi-support-functions`)
- `objectType` (string, thesaurus: `epi-support-object-types`)
- `supportType` (string, thesaurus: `epi-support-types`)
- `indoor` (boolean)
- `size` (`PhysicalSize`):
  - `tag` (string, thesaurus: `physical-size-tags`)
  - `w` (PhysicalSize):
    - `value`\* (number)
    - `unit`\* (string, thesaurus: `physical-size-units`)
    - `tag` (string, thesaurus: `physical-size-dim-tags`)
  - `h` (PhysicalSize)
  - `d` (PhysicalSize)
  - `note` (string)
- `state` (string, thesaurus: `epi-support-states`)
- `lastSeen` (date)

### EpiFormulaPatternsPart

Tag: `it.vedph.epigraphy.formula-patterns`.

- `patterns` (`EpiFormulaPattern[]`):
  - `eid` (string)
  - `language`\* (string; `epi-formula-pattern-languages`)
  - `tag` (string; `epi-formula-pattern-tags`)
  - `tokens` (`EpiFormulaToken[]`):
    - `tags` (string[]; `epi-formula-token-tags`, hierarchical)
    - `values` (string[])
    - `isOptional` (bool)
    - `isPlaceholder` (bool)
    - `note` (string)

### EpiLigaturesLayerFragment

Tag: `fr.it.vedph.epigraphy.ligatures`.

- `location`\* (string)
- `eid` (string)
- `types` (string[], thesaurus: `epi-ligature-types`)
- `groupId` (string)
- `note` (string)

## History

### 2.0.0

- 2023-05-24: updated packages (breaking change in general parts introducing [AssertedCompositeId](https://github.com/vedph/cadmus-bricks-shell/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-id)).
- 2023-03-21: fix to writing part pins.

### 1.0.2

- 2023-03-09: fix to formula token seeder.

### 1.0.1

- 2023-03-08: added epigraphic formulas part.
- 2023-03-02: updated test projects packages.

### 1.0.0

- 2023-02-02: migrated to new components factory. This is a breaking change for backend components, please see [this page](https://myrmex.github.io/overview/cadmus/dev/history/#2023-02-01---backend-infrastructure-upgrade). Anyway, in the end you just have to update your libraries and a single namespace reference. Benefits include:
  - more streamlined component instantiation.
  - more functionality in components factory, including DI.
  - dropped third party dependencies.
  - adopted standard MS technologies for DI.

### 0.0.2

- namespace fixes.

### 0.0.1

- initial release.
