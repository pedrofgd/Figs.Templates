# Dotnet Templates

## Create and install locally

1. Create the template itself
2. Create a `.template.config` directory with a `template.json` file, like:
``` json
{
  "$schema": "http://json.schemastore.org/template",
  "author": "Pedro Figueiredo",
  "classifications": ["C#", "Web API"],
  "identity": "Figs.Templates.API",
  "name": "Figs.Templates.API",
  "shortName": "figs.api",
  "tags": {
    "type": "solution",
    "language": "C#"
  },
  "sourceName": "Figs.Templates.API",
  "preferNameDirectory": true
}
```
3. Run `dotnet new install .` to add the current directory as a template.
    **Run the command at the root directory of the template**, 
    then run `dotnet new list` to check if it worked.

**Obs:** To uninstall local template use: `dotnet new uninstall <TEMPLATE_FILE_DIRECTORY>`

For use the custom template, just run `dotnet new <TEMPLATE_SHORTNAME>`
with flags:
- `-n | --name` for replace the template name in all files

## Publish to GitHub Packages

1. Add a [`nuget.config`](nuget.config) file in the root directory to configure the source (github)
2. Pack with `dotnet pack --no-build --output nupkgs`
3. Push with `dotnet nuget push nupkgs/Figs.Template.API.1.0.0.nupkg" --api-key YOUR_GITHUB_PAT --source "github"`

**Obs:** for the Token, I used GitHub classic (instead of fine-grained)

## Publish to nuget.org

