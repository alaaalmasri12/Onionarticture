using static Booky.Utility.StaticDetails;

namespace Booky.MVC.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object data { get; set; }
    }
}
