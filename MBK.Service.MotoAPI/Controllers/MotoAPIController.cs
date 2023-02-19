using Handmade.Service.EmbroideryAPI.Models.Dto;
using Handmade.Service.EmbroideryAPI.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Handmade.Service.EmbroideryAPI.Controllers
{
	[Route("api/embroideries")]
	[ApiController]
	public class EmbroideryAPIController : ControllerBase
	{
		private IEmbroideryRepository _embroideryRepository;
		protected ResponseDto _response;

		public EmbroideryAPIController(IEmbroideryRepository embroideryRepository)
		{
			_embroideryRepository = embroideryRepository;
			this._response = new ResponseDto();
		}

		[HttpGet]
		public async Task<object> Get()
		{
			IEnumerable<EmbroideryDto> embroideryDtos = await _embroideryRepository.GetEmbroideries();
			_response.Result = embroideryDtos;
			return _response;
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<object> Get(int id)
		{
			try
			{
				EmbroideryDto embroideryDto = await _embroideryRepository.GetEmbroideryById(id);
				_response.Result = embroideryDto;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
		}
		[HttpDelete]
		[Route("{id}")]
		public async Task<bool> Delete(int id)
		{
			try
			{
				await _embroideryRepository.DeleteEmbroidery(id);

				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response.IsSuccess;
		}
		[HttpPost]
		public async Task<object> Create([FromBody] EmbroideryDto emto)
		{
			try
			{
				EmbroideryDto embroideryDto = await _embroideryRepository.CreateUpdateEmbroidery(emto);
				_response.Result = embroideryDto;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
		}
		[HttpPut]
		public async Task<object> Update([FromBody] EmbroideryDto emto)
		{
			try
			{
				EmbroideryDto embroideryDto = await _embroideryRepository.CreateUpdateEmbroidery(emto);
				_response.Result = embroideryDto;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
		}
	}
}