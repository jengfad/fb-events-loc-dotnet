using System;
using System.Threading;
using System.Threading.Tasks;
using FEL.Core;
namespace FEL.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fbClient = new FbClient(FbSettings.AccessToken);
            var fbService = new FbService(fbClient);

            // var placeRequest = new GetPlaceRequest{};

            // placeRequest.Latitude = 40.710803;
            // placeRequest.Longitude = -73.964040;
            // placeRequest.Distance = 100;
            // var token = new CancellationToken();
            var task = fbService.GetEventsByLocation();
            Task.WaitAll(task);

            System.Console.WriteLine("LOL");
            // var getEventsTask = fbService.GetEvents();
            // Task.WaitAll(getEventsTask);

            System.Console.WriteLine($"{task.Result}");

            
        }
    }
}
