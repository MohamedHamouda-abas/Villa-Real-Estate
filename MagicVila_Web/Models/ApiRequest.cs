using System.Security.AccessControl;
using static Vaila_Utilities.SD;

namespace MagicVila_Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
