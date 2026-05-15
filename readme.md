# Versja

**Versja** is a small CLI tool to manage and automatically increment project versions in `.NET` `.csproj` files.  
It supports pre-release tags (e.g., `-beta`, `-rc`) and respects project-specific markers to avoid updating test or helper projects.

---

## Features

- Increment versions directly in the `<Version>` element of `.csproj` files  
- Supports pre-release identifiers like `-beta.YYYYMMDD.N`, `-rc1`, etc.  
- Works per-project by default; optionally can scan a solution for release projects  
- Skips non-release projects automatically via `<IsReleaseProject>true</IsReleaseProject>` marker  

---

## Versioning Strategy

**Versja** uses a simple, deterministic scheme:

`MAJOR.MINOR.PATCH[-PRERELEASE][+BUILD_METADATA]`

Examples:
   - 1.2.0-beta.20260515.3 → daily beta build (the 3rd for that date)
   - 1.2.0-beta.20260515.3+net6.0 → daily beta build for a specific runtime target
   - 1.2.0-rc1 → release candidate
   - 1.2.0 → stable release
   - 1.2.0-sha98281f305928e4cb8c1451c259074639d8d31117 → stable release with Git SHA-1 code

## Installation
(to be added)

## Notes
Designed to be simple, deterministic, and safe for daily NuGet and installer builds. \
Flexible enough to expand into solution-wide versioning or more advanced workflows.