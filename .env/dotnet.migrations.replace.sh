#! bash

echo $PWD
cd /d/Praca/NetCoreDev/IUIntegrationSystem/src/IUIntegrationSystem.Server.Core && dotnet ef database update 0 && dotnet ef migrations remove && dotnet ef migrations add 1 && dotnet ef database update 1
echo $PWD
