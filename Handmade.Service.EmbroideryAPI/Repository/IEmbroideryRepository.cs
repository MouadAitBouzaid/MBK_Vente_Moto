using Handmade.Service.EmbroideryAPI.Models.Dto;

namespace Handmade.Service.EmbroideryAPI.Repository
{
	public interface IEmbroideryRepository
	{
		Task<IEnumerable<EmbroideryDto>> GetEmbroideries();
		Task<EmbroideryDto> GetEmbroideryById(int Id);
		Task<EmbroideryDto> CreateUpdateProduct(EmbroideryDto embroideryDto);
		Task<bool> DeleteEmbroidery(int Id);
		Task<EmbroideryDto> CreateUpdateEmbroidery(EmbroideryDto emto);
	}
}
