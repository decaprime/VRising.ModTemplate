# V Rising Mod Template

## Installation
`dotnet new --install VRising.ModTemplate`

## Usage
`dotnet new vrisingmod -n NameOfYourMod --use-wetstone --use-vcf --description "Description of your mod"`

Replace `NameOfYourMod` with the name of your mod and update the description, and optionally add/remove the --use flags as appropriate. Then cd into the directory and run `dotnet build` to build the mod.