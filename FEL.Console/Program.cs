using System;
using System.Threading.Tasks;
using FEL.Core;

namespace FEL.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fbClient = new FbClient();
            var fbService = new FbService(fbClient);

            var getPlacesTask = fbService.GetPlaces(FbSettings.AccessToken);
            Task.WaitAll(getPlacesTask);

            var getEventsTask = fbService.GetEvents(FbSettings.AccessToken);
            Task.WaitAll(getEventsTask);

            System.Console.WriteLine($"{getPlacesTask.Result}");
            System.Console.WriteLine($"{getEventsTask.Result}");
        }

    }
}
