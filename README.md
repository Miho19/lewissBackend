# Lewis's Backend Test

Simple backend to mimic GRAPH API used by frontend

## Controllers

### Staff

    GET

#### Folder

    GET

### File

    GET

### Pricing Schedule

    GET

## Replicating

| METHOD | ACTION       | Param    | Substitute |
| ------ | ------------ | -------- | ---------- |
| POST   | downloadJson | itemId   | GET File   |
| GET    |              |          | GET Staff  |
| POST   | listFolder   | folderId | GET Folder |
