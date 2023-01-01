# Cadmus Epigraphy

- [Cadmus Epigraphy](#cadmus-epigraphy)
  - [Models](#models)
    - [EpiWritingPart](#epiwritingpart)
    - [EpiSupportPart](#episupportpart)
    - [EpiLigaturesLayerFragment](#epiligatureslayerfragment)

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

## Models

### EpiWritingPart

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

### EpiLigaturesLayerFragment

- `location`\* (string)
- `eid` (string)
- `types` (string[], thesaurus: `epi-ligature-types`)
- `groupId` (string)
- `note` (string)
