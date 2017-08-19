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

        public async Task<dynamic> GetEvents(string accessToken)
        {
            return await _fbClient.GetAsync<dynamic>(
                accessToken, "", "ids=79343886503,460616340718401,199000097510,680680525377232,339365006197398,370207406498524,31415981614,531259070328537,117863411725881,744476885633534,24101810764,1461447887207116,1650110555242928,352496761527317,170690276300266,214099775687018,958545184208767,131524323549740,316507601696554,699963723457567,322243664536714,162591080435323,204260646761642,216376065069684,113487422017817,138762776172236,1634735200172196,215519268546441,173696359828104,171699599508294,120209958035758,688794871149770,358454667505135,814660221943073,189622644511070,147797361910626,100860576625307,1508531459420612,102797816763159,226206031191796,196578187425091,109886079566505,143344645725733,1288329671204582,110429805966734,119627178376048,120357644969569,1580026135634673,1884830821737091,156362151557488&access_token=286408841767341|d3b640e9034164e5eab868d6e4925291&fields=id,name,about,emails,cover.fields(id,source),picture.type(large),category,category_list.fields(name),location,events.fields(id,type,name,cover.fields(id,source),picture.type(large),description,start_time,end_time,category,attending_count,declined_count,maybe_count,noreply_count).since(1503115498)");

        }
    }
}