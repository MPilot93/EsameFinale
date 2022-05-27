using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using MVCGraphic.Models;
using MVCGraphic.SQL;

namespace MVCGraphic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private readonly IHttpClientFactory _client;
        //public string Message { get; set; }
        private  CinemaSQL _cinema;
        private  RoomSQL _room;
        private  FilmSQL _film;
        private  SpectatorSQL _spectator;
        private  TicketSQL _ticket;
        private  string conString= "data source=LAPTOP-6U512VIE\\SQLEXPRESS; database = Cinema; Integrated Security = true; Connection timeout = 3600;";

        public HomeController(ILogger<HomeController> logger)//tolto passaggio client
        {
            _logger = logger;
            //_client = client;
            _cinema = new CinemaSQL(conString);
            _room = new RoomSQL(conString);
            _film = new FilmSQL(conString);
            _spectator = new SpectatorSQL(conString);
            _ticket = new TicketSQL(conString);

            
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _room.GetAll();

            return View(result);
        }

        [HttpGet]
        public IActionResult FilmList()
        {
            var result = _film.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult NewSpectator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewSpectator(SpectatorModel spectator)
        {
            _spectator.Add(spectator);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EmptyRoom(int id)
        {
            var room = _room.GetAll().Where(x => x.IdRoom == id).FirstOrDefault();
            return View(room);
        }
        [HttpPost]
        public IActionResult EmptyRoom(RoomModel room)
        {
        
            var res = _room.GetAll().Where(x => x.IdRoom == room.IdRoom).FirstOrDefault();
            
                _room.Empty(room.IdRoom);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Confirm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmptyAll()
        {

            var res = _room.GetAll();
            _room.EmptyAll();



            return RedirectToAction("index");
        }

        //[HttpGet]
        //public async Task<IActionResult> IndexAsync()
        //{
        //    var client = _client.CreateClient("CinemaApi");
        //    Message = await client.GetStringAsync("Cinema/RoomList");
        //    var M = JsonSerializer.Deserialize<IEnumerable<Rooms>>(Message);
        //    return View(M);
        //}
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