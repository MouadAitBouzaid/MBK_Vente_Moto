using static Handmade.Web.SD;

namespace Handmade.Web.Models
{
	public class ApiRequest
	{
		public ApiType apiType { get; set; }
		public string url { get; set; }
		public object data { get; set; }
		public string AccessToken { get; set; }
	}
}
