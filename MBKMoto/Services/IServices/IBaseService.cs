using Handmade.Web.Models;

namespace Handmade.Web.Services.IServices
{
	public interface IBaseService : IDisposable
	{
		ResponseDto responseModel { get; set; }
		Task<T> SendAsync<T>(ApiRequest apiRequest);
	}
}
