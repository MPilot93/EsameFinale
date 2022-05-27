using Microsoft.AspNetCore.Mvc;
using Cinema.Api.Models;
using Cinema.Api.SQL;
namespace Cinema.Api.Controllers
{
    [ApiController]
    [Route(template: "Cinema")]
    public class CinemaApiController : ControllerBase
    {
        private readonly ILogger<CinemaApiController> _logger;
        private readonly CinemaSQL _cinemaDB;
        private readonly RoomSQL _roomDB;
        private readonly FilmSQL _film;
        private readonly SpectatorSQL _spectator;
        private readonly TicketSQL _ticket;


        public CinemaApiController(ILogger<CinemaApiController> logger,
                                   CinemaSQL cinemaDB,
                                   RoomSQL roomDB,
                                   FilmSQL film,
                                   SpectatorSQL spectator,
                                   TicketSQL ticket)
        {
            _logger = logger;
            _cinemaDB = cinemaDB;
            _roomDB = roomDB;
            _film = film;
            _spectator = spectator;
            _ticket = ticket;

        }

        [HttpGet(template: "RoomList")]
        public IEnumerable<Rooms> GetList()
        {
         

            return _roomDB.GetAll();
        }
    }
}
