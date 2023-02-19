using Handmade.Web.Models;
using Handmade.Web.Services;
using Handmade.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Handmade.Web.Controllers
{
	public class EmbroideryController : Controller
	{
		private readonly IEmbroideryService _embroideryService;
		public EmbroideryController(IEmbroideryService embroideryService)
		{
			_embroideryService = embroideryService;


		}
		public async Task<IActionResult> EmbroideryIndex()
		{
			List<EmbroideryDto> list = new();
			var response = await _embroideryService.GetAllEmbroideriesAsync<ResponseDto>();
			if (response != null)
			{
				list = JsonConvert.DeserializeObject<List<EmbroideryDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}
		public async Task<IActionResult> EmbroideryCreate()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EmbroideryCreate(EmbroideryDto model)
		{
			var response = await _embroideryService.CreateEmbroideriesAsync<ResponseDto>(model);
			if (response != null && response.IsSuccess)
			{
				return RedirectToAction(nameof(EmbroideryIndex));
			}
			return View(model);
		}
		public async Task<IActionResult> EmbroideryEdit(int embroideryId)
		{
			List<EmbroideryDto> list = new();
			var response = await _embroideryService.GetEmbroideryByIdAsync<ResponseDto>(embroideryId);
			if (response != null && response.IsSuccess)
			{
				EmbroideryDto model = JsonConvert.DeserializeObject<EmbroideryDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EmbroideryEdit(EmbroideryDto model)
		{
			var response = await _embroideryService.UpdateEmbroideriesAsync<ResponseDto>(model);
			if (response != null && response.IsSuccess)
			{
				return RedirectToAction(nameof(EmbroideryIndex));
			}
			return View(model);
		}

		public async Task<IActionResult> EmbroideryDelete(int embroideryId)
		{
			List<EmbroideryDto> list = new();
			var response = await _embroideryService.GetEmbroideryByIdAsync<ResponseDto>(embroideryId);
			if (response != null && response.IsSuccess)
			{
				EmbroideryDto model = JsonConvert.DeserializeObject<EmbroideryDto>(Convert.ToString(response.Result));

				return View(model);
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EmbroideryDelete(EmbroideryDto model)
		{
			var response = await _embroideryService.DeleteEmbroideriesAsync<ResponseDto>(model.Id);
			if (response.IsSuccess)
			{
				return RedirectToAction(nameof(EmbroideryIndex));
			}
			return View(model);
		}
		public async Task<IActionResult> EmbroideryDetails(int embroideryId)
		{
			List<EmbroideryDto> list = new();
			var response = await _embroideryService.GetEmbroideryByIdAsync<ResponseDto>(embroideryId);
			if (response != null && response.IsSuccess)
			{
				EmbroideryDto model = JsonConvert.DeserializeObject<EmbroideryDto>(Convert.ToString(response.Result));

				return View(model);
			}
			return NotFound();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EmbroideryDetails(EmbroideryDto model)
		{
			var response = await _embroideryService.GetEmbroideryByIdAsync<ResponseDto>(model.Id);
			if (response.IsSuccess)
			{
				return RedirectToAction(nameof(EmbroideryIndex));
			}
			return View(model);
		}


	}
}

