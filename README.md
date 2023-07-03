# V Rising Mod Template

## Installation
`dotnet new --install VRising.ModTemplate`

## Example usage
`dotnet new vrisingmod -n NameOfYourMod --use-vcf --description "Description of your mod"`

Replace `NameOfYourMod` with the name of your mod and update the description, and optionally add/remove the --use flags as appropriate. Then cd into the directory and run `dotnet build` to build the mod.

## Resources
- Wiki: https://wiki.vrisingmods.com
- Discord: https://vrisingmods.com/discord

---

## Contributing to Template
You can use any directory, but there's a workflow using `QTemplateTest` included in a script and the gitignore. This script will clean up that direcotry, build, and reinstall the template locally. The workflow looks like:
### Reinstall locally:
`.Reinstall-Template.ps1`
### Test and Develop ex:
```ps1
dotnet new vrisingmod -n "QTemplateTest" -vcf -bloodstone
dotnet build QTemplateTest
```