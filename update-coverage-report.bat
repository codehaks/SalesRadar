echo off
cd ..\..\
coverlet .\test\SalesRadar.Tests\bin\Debug\net8.0\SalesRadar.Tests.dll --target "dotnet" --targetargs "test --no-build" -f OpenCover
reportgenerator -reports:"coverage.opencover.xml" -targetdir:"coverage-results" -reportTypes:HtmlInline