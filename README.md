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

Use command:

`dotnet nuget push nupkgs/Figs.Templates.API.1.0.0.nupkg --api-key <API_KEY> --source https://api.nuget.org/v3/index.json`

## Proper configuration for template

Create a `templates` directory to store everything that is actually template files.

Then create a `.csproj` at the root, with packages configurations, such as the version, type, author, id etc. In this file set up a `Content` Tag to specify with files will be part of the package, in this case, everything in `templates`. Also specify the files to compile, that in that case will have any:

``` C#
<ItemGroup>
  <Content Include="templates\**\*" Exclude="templates\**\bin\**;templates\**\obj\**" />
  <Compile Remove="**\*" />
</ItemGroup>
```

Details:
- [Microsoft docs](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates#pack-a-template-into-a-nuget-package-nupkg-file)
- [TemplatePackage.csproj](./TemplatePackage.csproj)

Use `dotnet pack --no-build --output nupkgs` to pack.
