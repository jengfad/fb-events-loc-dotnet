using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using FEL.Core.Models.Request;
using FEL.Core.Models.Response;

namespace FEL.Core
{
    public interface IFbService
    {
        Task<GetPlaceResponse> GetPlaces(GetPlaceRequest request);
    }

    public class FbService : IFbService
    {
        private readonly IFbClient _fbClient;

        private int _limit = 100;

        public FbService(IFbClient fbClient)
        {
            _fbClient = fbClient;
        }

        public async Task<dynamic> GetEventsByLocation()
        {
            var placeRequest = new GetPlaceRequest{};

            placeRequest.Latitude = 40.710803;
            placeRequest.Longitude = -73.964040;
            placeRequest.Distance = 100;

            var places = await GetPlaces(placeRequest);

            int groupSize = 50;

            var groups = places.data
                .Select((x, i) => new { Item = x, Index = i/groupSize })
                .GroupBy(x => x.Index, x => x.Item.id);
            
            var results = await Task.WhenAll(groups.Select(i => GetEvents(string.Join(", ", i))));

            string appendedRes = "";

            foreach(var result in results)
            {
                appendedRes = appendedRes + result.ToString();
            }

            return appendedRes;
        }
 
        public async Task<GetPlaceResponse> GetPlaces(GetPlaceRequest request)
        {
            return await _fbClient.GetAsync<GetPlaceResponse>(
                "search", "type=place&q=&center=" + request.Latitude + ", " + request.Longitude + "&distance=" + request.Distance + "&limit=" + _limit + "&fields=id");      
        }

        public async Task<dynamic> GetEvents(string placeIds)
        {   
            return await _fbClient.GetAsync<dynamic>(
                 "", "ids=" + placeIds + "&fields=id,name,about,emails,cover.fields(id,source),picture.type(large),category,category_list.fields(name),location,events.fields(id,type,name,cover.fields(id,source),picture.type(large),description,start_time,end_time,category,attending_count,declined_count,maybe_count,noreply_count).since(1503115498)");
        }
    }
}