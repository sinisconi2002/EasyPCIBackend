using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyPCIBackend.Controllers
{
    [ApiController]
    [Route("cards")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _service;

        public CardController(ICardService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCards() 
        {
            var _cards = _service.GetCards();
            return Ok(_cards);
        }

        [HttpGet("{cardId}")]
        public IActionResult GetCard(Guid cardId)
        {
            var _card = _service.GetCard(cardId);
            return Ok(_card);
        }

        [HttpPost("add_card")]
        public async Task<IActionResult> AddAnnouncement(Card card)
        {
            await _service.AddCard(card);
            return Ok();
        }

        [HttpGet("search_result")]
        public IActionResult GetResultsBySearch([FromQuery] string search)
        {
            var _cards = _service.GetCardsBySearch(search);
            return _cards.Count != 0 ? Ok(_cards) : Ok();
        }
    }
}
