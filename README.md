# Cadmus Epigraphy

- parts:
  - [EpiWritingPart](docs/epi-writing.md)
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
- [EpiWritingPart](docs/epi-writing.md)
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

## History

### 5.0.3

- 2025-01-28: updated packages.

### 5.0.2

- 2024-11-30: updated packages.

### 5.0.1

- 2024-11-20: added `InSitu` to support.

## 5.0.0

- 2024-11-18: ⚠️ upgraded to .NET 9.

## 4.0.1

- 2024-10-30: minor adjustments in new models.

## 4.0.0

- 2024-10-29: ⚠️ breaking changes on models:
  - `EpiSupport` and its related seeders and tests renamed in `EpiSupportOld` and marked as obsolete. The corresponding identifiers are now `it.vedph.epigraphy.support.old` and `seed.it.vedph.epigraphy.support.old`.
  - `EpiWriting` and its related seeders and tests renamed in `EpiWritingOld` and marked as obsolete. The corresponding identifiers are now `it.vedph.epigraphy.writing.old` and `seed.it.vedph.epigraphy.writing.old`.
  - new models replaced them: `EpiSupport` (`it.vedph.epigraphy.support`) and `EpiWriting` (`it.vedph.epigraphy.writing`) with their related seeders and tests. This allows merging graffiti models into epigraphic models, while also making some models more composable via parts composition rather than part complication.

The only projects planning to use these affected parts are Febo and Gisarc. Should they want to stick to the old models, they will later have to copy them (with their editors) into their project-specific parts, as in future obsolete parts will be removed from Cadmus epigraphy.

The changes are limited to 2 parts: [writing](docs/epi-writing.md) and [support](docs/epi-support.md). The driving **principles** behind these changes were two:

- try to be as close as possible to the **traditional** models of big collections, like IMAI, while generalizing them for wider usage and compliance, even embracing graffiti.
- make the model **more modular**, so that it can be more easily customized to every project's requirements. This essentially means making smaller parts, which can be better handled either separately and in combination. In the Cadmus model, in the end each record is an item, our "box": the dynamic nature of its model derives from the objects we put in that box, our parts. So, parts which include data which can be effectively represented by another part model and are logically distinct, can be dismembered into smaller parts. This makes them more reusable, and allows users build their own models with much more effective customization, because they can decide to include or exclude whole subsections of data, right because they are separated into different, composable objects.

## 3.1.2

- 2024-09-27: updated packages.
- 2024-09-16: updated test packages.

### 3.1.1

- 2024-07-17: moved `PhysicalMeasurement` to bricks.

### 3.1.0

- 2024-07-14:
  - refactored epigraphic fragment location model.
  - updated test packages.

### 3.0.7

- 2024-06-24: round size values in seeders.

### 3.0.6

- 2024-06-23: improved new sign model.

### 3.0.5

- 2024-06-22: added new models for writing signs and support fragments.

### 3.0.4

- 2024-06-09: updated packages.

### 3.0.3

- 2024-05-24: updated packages.
- 2024-04-13: updated test packages.
- 2024-02-01: updated documentation.

### 3.0.1

- 2023-11-21: updated packages.

### 3.0.0

- 2023-11-18: ⚠️ Upgraded to .NET 8.

### 2.0.4

- 2023-11-07: updated packages.

### 2.0.3

- 2023-09-04: updated packages.

### 2.0.2

- 2023-06-21: updated packages.

### 2.0.1

- 2023-06-17: updated packages.
- 2023-06-02: updated test packages.

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
