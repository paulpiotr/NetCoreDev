#! bash

echo $PWD
cd /d/Praca/NetCoreDev/WebApplicationNetCoreDev/Resources/ && ./dotnet.publish.release.sh && cd /d/Praca/NetCoreDev/IUIntegrationSystem/src/IUIntegrationSystem.Server.WorkerService/Resources/ && ./dotnet.publish.release.sh &
echo $PWD
