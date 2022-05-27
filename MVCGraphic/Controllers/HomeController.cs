using Microsoft.AspNetCore.Mvc;
using Cinema.Api.Models;
using System.Diagnostics;
using System.Text.Json;
using MVCGraphic.Models;

namespace MVCGraphic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _client;
        public string Message { get; set; }

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client;
            
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var client = _client.CreateClient("CinemaApi");
            Message = await client.GetStringAsync("Cinema/RoomList");
            var M = JsonSerializer.Deserialize<IEnumerable<Rooms>>(Message);
            return View(M);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}