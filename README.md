# Azure Pipeline CI With MsTest UnitTests VSTest CI
## Command Line
```
vstest.console.exe ConsoleApp1Tests\bin\Debug\net6.0\ConsoleApp1Tests.dll /logger:"console;verbosity=detailed"
# https://github.com/microsoft/vstest/issues/981
vstest.console.exe ConsoleApp1Tests\bin\Debug\net6.0\ConsoleApp1Tests.dll --logger:trx --ResultsDirectory:.\TestResults2 --Collect:"Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format="Cobertura"
```

## Yaml mode azure-pipelines.yml:
https://stackoverflow.com/questions/57177772/azure-pipelines-where-is-the-codecoverage-generated-by-vstest2
```yaml
# ASP.NET Core (.NET Framework)
# Build and test ASP.NET Core projects targeting the full .NET Framework.
# Add steps that publish symbols, save build artifacts, and more:
# https://docs.microsoft.com/azure/devops/pipelines/languages/dotnet-core

trigger:
- master

pool:
  vmImage: 'windows-latest'

variables:
  solution: '**/*.sln'
  buildPlatform: 'Any CPU'
  buildConfiguration: 'Release'

parameters:
  - name: RestoreBuildProjects
    type: string
    default: '**/*.csproj'

steps:
# - task: DotNetCoreCLI@2
#   displayName: Restore
#   inputs:
#     command: restore
#     projects: '$(Parameters.RestoreBuildProjects)'

- task: DotNetCoreCLI@2
  displayName: Restore Packages
  inputs:
      command: restore
      # feedsToUse: config
      # nugetConfigPath: 'nuget.config'
      projects: '**/*.csproj'
      noCache: true

- task: NuGetToolInstaller@1

- task: NuGetCommand@2
  inputs:
    restoreSolution: '$(solution)'

- task: VSBuild@1
  inputs:
    solution: '$(solution)'
    msbuildArgs: '/p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:SkipInvalidConfigurations=true /p:DesktopBuildPackageLocation="$(build.artifactStagingDirectory)\WebApp.zip" /p:DeployIisAppPath="Default Web Site"'
    platform: '$(buildPlatform)'
    configuration: '$(buildConfiguration)'

- task: DotNetCoreCLI@2
  displayName: Build
  inputs:
    projects: |
     **/*.csproj
     !**/*[Tt]ests.csproj
    arguments: '--configuration $(BuildConfiguration)'

- task: VSTest@2
  inputs:
    testSelector: 'testAssemblies'
    testAssemblyVer2: |
      **\*[Tt]ests.dll
      !**\*TestAdapter.dll
      !**\obj\**
    searchFolder: '$(System.DefaultWorkingDirectory)'
    resultsFolder: '$(build.ArtifactStagingDirectory)/TestResults/'
    otherConsoleOptions: '/collect:"Code Coverage;Format=Cobertura"'
    codeCoverageEnabled: true

# vv Then add publish coverage manually vv
- task: PublishCodeCoverageResults@1
  inputs:
    codeCoverageTool: 'Cobertura'
    summaryFileLocation: '$(build.ArtifactStagingDirectory)/TestResults/**/*.Cobertura.xml'

- task: DotNetCoreCLI@2
  displayName: Publish
  inputs:
    command: publish
    publishWebProjects: false
    projects: |
     **/*.csproj
     !**/*[Tt]ests.csproj
    arguments: '--configuration $(BuildConfiguration) --output $(build.artifactstagingdirectory)'
    zipAfterPublish: True

- task: PublishBuildArtifacts@1
  displayName: 'Publish Artifact'
  inputs:
    PathtoPublish: '$(build.artifactstagingdirectory)'
  condition: succeededOrFailed()
```

## Classic Mode Options:
1. Build solution **/*.sln (MSBuild):
```
Project:
    **/*.sln

MSBuild Architecture:
    MSBuild x64
```

2. Build (.NET Core):
```
Path to project(s):
    **/*.csproj
    !**/*[Tt]ests.csproj
```

3. VsTest - testAssemblies (Visual Studio Test):
```
Test files:
    **\*[Tt]ests.dll
    !**\*TestAdapter.dll
    !**\obj\**
```

4. Publish (.NET Core):
```
X publish web projects

Path to project(s):
    **/*.csproj
    !**/*[Tt]ests.csproj
```

## Azure Pipeline CI With MsTest Unit Tests VSTest-Github-ASP.NET Core-CI-Yaml Mode:
[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/Azure%20Pipeline%20CI%20With%20MsTest%20Unit%20Tests%20VSTest-Github-ASP.NET%20Core-CI-Yaml%20Mode?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=38&branchName=master)

## Azure Pipeline CI With MsTest Unit Tests VSTest-Github-ASP.NET Core-CI-Classic Mode:
[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/Azure%20Pipeline%20CI%20With%20MsTest%20Unit%20Tests%20VSTest-Github-ASP.NET%20Core-CI-Classic%20Mode?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=35&branchName=master)
