using System;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public static class TestIcasaMutationServiceData
    {
        public static async Task TestIcasaMutationServiceDataAsync()
        {
            try
            {
                await Task.Run(async () =>
                {
                    Console.WriteLine("TestIcasaMutationServiceData()");
                    await IcasaMutationServiceData.IcasaMutationServiceData.TestAsync();
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message, e.StackTrace);
            }
        }
    }
}
