using System.Linq;

namespace FEL.Core.Models.Response
{
    public class GetPlaceResponse
    {
        public Data[] data { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
    }

}