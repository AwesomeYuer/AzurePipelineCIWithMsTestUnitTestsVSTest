# Azure Pipeline CI With MsTest UnitTests VSTest CI
## Command Line
```
# MsTest + VSTest + Windows
vstest.console.exe **\*MsTestProject.dll /logger:"console;verbosity=detailed"
# https://github.com/microsoft/vstest/issues/981
vstest.console.exe **\*MsTestProject.dll --logger:trx --ResultsDirectory:.\TestResults2 --Collect:"Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format="Cobertura"

# NUnit + Linux
cd AzurePipelineCIWithUnitTests/

dotnet new tool-manifest --force

dotnet tool install Microsoft.Playwright.CLI

dotnet build AzurePipelineCIWithUnitTests.sln

dotnet tool run playwright install

//for linux
dotnet tool run playwright install --force msedge

dotnet test **/*NUnitTest*.dll

dotnet test **/*UnitTest*.csproj
```

## Linux
[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/AwesomeYuer.AzurePipelineCIWithUnitTests-Linux?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=41&branchName=master)

## Windows
[![Build Status](https://microshaoft.visualstudio.com/AzurePipelines/_apis/build/status/AwesomeYuer.AzurePipelineCIWithUnitTests-Windows?branchName=master)](https://microshaoft.visualstudio.com/AzurePipelines/_build/latest?definitionId=40&branchName=master)

