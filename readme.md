# Versja

**Versja** is a small CLI tool to manage and automatically increment project versions in `.NET` `.csproj` files.  
It supports pre-release tags (e.g., `-beta`, `-rc`) and respects project-specific markers to avoid updating test or helper projects.

---

## Features

- Increment versions directly in the `<Version>` element of `.csproj` files  
- Supports pre-release identifiers like `-beta.YYYYMMDD.N`, `-rc1`, etc.  
- Works per-project by default; optionally can scan a solution for release projects  

---

## Versioning Strategy

**Versja** uses a simple, deterministic scheme:

`MAJOR.MINOR.BUILD.REVISION[-PRERELEASE_IDENTIFIER][DATE.CADENCE][+RUNTIME_TARGET]`  **(1)**

Components MAJOR, MINOR, BUILD, REVISION are mandatory (that is they are saved and loaded by< the tool), all others are optional.

Examples:

  - 1.1.0.47-beta.20260520.47+net9.0 
  - 1.2.42.47-beta20260518.17 
  - 1.2.42.47-beta20260518 
  - 1.2.42.47

## Correspondence to existing versioning systems.
**Versja** does not support Semantic Versioning model directly. For reasons both historical and technical, it implements a mixed model between SemVer and classical MS versioning scheme.

In format  __(1)__ :
  - MAJOR : breaking changes
  - MINOR : new features, backward-compatible
  - BUILD : bug fixes
  - REVISION : minor updates, fixes, or patches within a specific build.
  - PRERELEASE_IDENTIFIER : denotes the estimation of the version's stability state (such as alpha, beta, release candidates, etc.) Default value: "build".
  - DATE : the date of the version in 8-digit format (20260520).
  - CADENCE : used together with DATE to indicate a version created on the same date. Versions carrying the same date are differentiated by this value.
  - RUNTIME_TARGET : the .NET target of the assembly (such as "net9.0").

## Installation
### Installation package 
An Installation package (self-extracting file like `Versja_Setup-2026-05-20@15-11.exe`) is a NSIS installer. 
Files `Versja.exe, Versja.dll` and possibly a few JSON files will be copied into your target folder (`VERSJA_DIR`). 
You may optionally add `VERSJA_DIR` to the system `PATH`.

## Usage
### As External Tool in Visual Studio
#### Adding Versja tool
In VS menu "Tools -> External Tools" click add ind instead "[New Tool 1]" change the name to "Versja" (or whatever name you prefer).
Your External Tools dialog will look like ![versja-installation-as-tool](versja-installation-as-tool.png).\
**Important:** 
  - The arguments line must look exactly as shown: `$(ProjectFileName)`followed by ` increment`.
  - Checkout the "Use Output Window" box.

Calling this tool results in incrementation of the version of the selected project in VS 2022:
![version-result](version-result.png).

#### Adding Versja Configurator tool
In VS menu "Tools -> External Tools" click add ind instead "[New Tool 1]" change the name to "Versja Configurator" (or whatever name you prefer).

Your External Tools dialog will look like ![versja-configurator-installation-as-tool](versja-configurator-installation-as-tool.png).

Using this tool calls the Version Configuration dialog

![version-configuration-dialog](version-configuration-dialog.png).

In the dialog, one can change major and minor versions, as well as build (an attempt to decrease build is theoretically possible, but user will be warned that she must know what he does.)

Revision and cadence are inreased automatically and are displayed in read-only mode.


## Automated version increasing after build.
<!--### Initialization
To initialize Automated version increasement one should select the project in the solution explorer and call Version configuration dialog as described above.-->
To enable autoincrement, add the following XML element into the project file:
```
  <Target Name="AutoIncrementVersion" AfterTargets="Build">
    <Exec Command="&quot;C:\MyPrograms\Versja\Versja.exe&quot; &quot;$(MSBuildProjectFullPath)&quot; increment" />
  </Target>
```
```C:\MyPrograms\Versja\Versja.exe``` here refers certainly to the location of Version.exe on your local computer.

## Notes
Designed to be simple, deterministic, and safe for daily NuGet and installer builds. \
Flexible enough to expand into solution-wide versioning or more advanced workflows.

This short description tries to be sufficient for the installytion and usage of this tool, but it is clear to the author that it can be not enough. If there is interest, I will produce a YouTube video.