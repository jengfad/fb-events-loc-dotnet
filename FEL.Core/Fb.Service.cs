using System.Threading.Tasks;

namespace FEL.Core
{
    public interface IFbService
    {
        Task<dynamic> GetPlaces(string accessToken);
    }

    public class FbService : IFbService
    {
        private readonly IFbClient _fbClient;

        public FbService(IFbClient fbClient)
        {
            _fbClient = fbClient;
        }

        public async Task<dynamic> GetPlaces(string accessToken)
        {
            return await _fbClient.GetAsync<dynamic>(
                accessToken, "search", "type=place&q=cafe&center=40.7304,-73.9921&distance=1000&fields=name,checkins,picture");

        }
    }
}