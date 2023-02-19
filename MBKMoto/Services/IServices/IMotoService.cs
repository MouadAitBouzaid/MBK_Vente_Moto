using Handmade.Web.Models;

namespace Handmade.Web.Services.IServices
{
    public interface IEmbroideryService:IBaseService
    {
        Task<T> GetAllEmbroideriesAsync<T>();
        Task<T> GetEmbroideryByIdAsync<T>(int id);
        Task<T> CreateEmbroideriesAsync<T>(EmbroideryDto embroideryDto);
        Task<T> UpdateEmbroideriesAsync<T>(EmbroideryDto embroideryDto);
        Task<T> DeleteEmbroideriesAsync<T>(int id);

    }
}
