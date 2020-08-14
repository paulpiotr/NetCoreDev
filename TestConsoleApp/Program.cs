using PortalApiGusApiRegonData;
using System;
using System.IO;

namespace TestConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByKrs("b65986a6300044a0b7fb", krs: "0000349095");
            await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByKrsy("b65986a6300044a0b7fb", krsy: "0000349095,0000387233");
            await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNip("b65986a6300044a0b7fb", nip: "5730207319");
            await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNipy("b65986a6300044a0b7fb", nipy: "5730207319,5321052523");
            await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegon("b65986a6300044a0b7fb", regon: "001337730");
            await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9zn ("b65986a6300044a0b7fb", regony9zn: "001337730,366316484");
            await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14zn("b65986a6300044a0b7fb", regony14zn: "001337730,366316484");
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByKrs("b65986a6300044a0b7fb", krs: "0000349095");
            //Inergis
            //await DanePobierzPelnyRaport.DanePobierzPelnyRaportAsync("b65986a6300044a0b7fb", nip: "5730207319");
            //Isk
            //await DanePobierzPelnyRaport.DanePobierzPelnyRaportAsync("b65986a6300044a0b7fb", krs: "0000349095");
            //Stylmeb
            //await DanePobierzPelnyRaport.DanePobierzPelnyRaportAsync("b65986a6300044a0b7fb", nip: "5321052523");
            //5321052523
        }
    }
}
