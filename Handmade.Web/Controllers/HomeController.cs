using Handmade.Web.Models;
using Handmade.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Handmade.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmbroideryService _embroideryService;
        public HomeController(ILogger<HomeController> logger,IEmbroideryService embroideryService)
        {
            _logger = logger;
            _embroideryService = embroideryService;
        }

        public async Task <IActionResult> Index()
        {
            List<EmbroideryDto> list = new();
            var response = await _embroideryService.GetAllEmbroideriesAsync<ResponseDto>();
            if(response!=null)
            {
                list = JsonConvert.DeserializeObject<List<EmbroideryDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}