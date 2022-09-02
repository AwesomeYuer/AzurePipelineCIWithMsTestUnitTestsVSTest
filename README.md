# Azure Pipeline CI With MsTest UnitTests VSTest CI

## Classic Mode Options
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

## Azure Pipeline CI With MsTest Unit Tests VSTest-Github-ASP.NET Core-CI-Classic Mode:
[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/AzurePipelineCIWithMsTestUnitTestsVSTest-ASP.NETCore-CI-Classic-Mode?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=35&branchName=master)


## Azure Pipeline CI With MsTest Unit Tests VSTest-Github-ASP.NET Core-CI-Yaml Mode:
[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/AzurePipelineCIWithMsTestUnitTestsVSTest-ASP.NETCore-CI-Yaml-Mode?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=36&branchName=master)