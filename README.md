# Azure Pipeline CI With MsTest UnitTests VSTest CI
## Command Line
```
# MsTest + VSTest + Windows
vstest.console.exe **\*MsTestProject.dll /logger:"console;verbosity=detailed"
# https://github.com/microsoft/vstest/issues/981
vstest.console.exe **\*MsTestProject.dll --logger:trx --ResultsDirectory:.\TestResults2 --Collect:"Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format="Cobertura"

# NUnit + Linux
cd AzurePipelineCIWithUnitTests/

 dotnet build AzurePipelineCIWithUnitTests.Linux.sln







dotnet test **\*UnitTest*.dll
```


