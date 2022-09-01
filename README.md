# Azure Pipeline CI with UnitTests VSTest CI

1. msbuild: 
```
Project:
    **/*.sln
```
2. vstest:
```
Test files:
    **\*tests.dll
    !**\*TestAdapter.dll
    !**\obj\**
```
3. publish: 
```
X publish web projects

Path to project(s):
    **/*.csproj
    !**/*Tests.csproj
```

[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/AzurePipelineCIwithUnitTestsVSTest-Classic-CI-Github?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=34&branchName=master)

[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/AzurePipelineCIwithUnitTestsVSTest-yml-CI-Github?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=30&branchName=master)