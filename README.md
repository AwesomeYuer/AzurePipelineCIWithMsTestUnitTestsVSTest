# Azure Pipeline CI with UnitTests VSTest CI

## Classic Mode Options
1. Build solution **/*.sln (MSBuild):
```
Project:
    **/*.sln
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

# AzurePipelineCIwithUnitTestsVSTest-Classic-CI-Github
[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/AzurePipelineCIwithUnitTestsVSTest-Classic-CI-Github?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=34&branchName=master)


# AzurePipelineCIwithUnitTestsVSTest-yml-CI-Github
[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/AzurePipelineCIwithUnitTestsVSTest-yml-CI-Github?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=30&branchName=master)