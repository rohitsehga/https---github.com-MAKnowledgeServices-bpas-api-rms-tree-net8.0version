dotnet tool install -g dotnet-sonarscanner
dotnet tool install -g dotnetsay
dotnet tool install -g dotnet-reportgenerator-globaltool
dotnet tool install -g coverlet.console
dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools
 
dotnet sonarscanner begin /k:"RM-PRO" /d:sonar.host.url="https://sast.beatapps.net" /d:sonar.branch.name="master"  /d:sonar.verbose="false" /d:sonar.language="cs" /d:sonar.exclusions="**/bin/**/*,**/obj/**/*,**/Migrations/**/*,**/ApplicationDbContextModelSnapshot.cs" /d:sonar.cs.opencover.reportsPaths="./code-coverage/coverage.opencover.xml"
dotnet clean --verbosity quiet
dotnet restore --verbosity quiet
dotnet build --verbosity quiet
 
dotnet sonarscanner end