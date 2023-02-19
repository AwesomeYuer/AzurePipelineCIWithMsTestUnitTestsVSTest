# Azure Pipeline CI With MsTest UnitTests VSTest CI
## Command Line
```
vstest.console.exe ConsoleApp1Tests\bin\Debug\net6.0\ConsoleApp1Tests.dll /logger:"console;verbosity=detailed"
# https://github.com/microsoft/vstest/issues/981
vstest.console.exe **\*TestProject.dll --logger:trx --ResultsDirectory:.\TestResults2 --Collect:"Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format="Cobertura"

# NUnit + xUnit + Linux
dotnet test **\*UnitTest*.dll
```


