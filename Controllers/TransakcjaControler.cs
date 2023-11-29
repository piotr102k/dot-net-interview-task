using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using sklepInternetowy.Dto;
using sklepInternetowy.Interface;
using sklepInternetowy.Models;
using sklepInternetowy.Repository;

namespace sklepInternetowy.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TransakcjaControler : Controller
    {
        private readonly ITransakcjaRepository _transakcjaRepository;
        public TransakcjaControler(ITransakcjaRepository transakcjaRepository)
        {
            _transakcjaRepository = transakcjaRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Transakcja>))]
        public IActionResult GetTransakcje()
        {
            var transakcje = _transakcjaRepository.GetTransakcje();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(transakcje);
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Transakcja))]
        [ProducesResponseType(400)]
        public IActionResult GetTransakcja(int Id)
        {
            var transakcje = _transakcjaRepository.GetTransakcja(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(transakcje);


        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTransakcja([FromQuery] int id, [FromQuery] int idPrzedmiotu, [FromQuery] double oferta, [FromQuery] int idKupujacego, [FromQuery] int idSprzedajacego)
        {

            if (!_transakcjaRepository.CreateTransakcja(id, idPrzedmiotu, oferta, idKupujacego, idSprzedajacego))
            {
                ModelState.AddModelError("", "error dodawania");
                return StatusCode(500, ModelState);
            }
            if (oferta * 2 > _transakcjaRepository.GetPrzedmiot(id).Cena)
            {
                ModelState.AddModelError("", "za duza oferta");
                return StatusCode(500, ModelState);
            }
            if (oferta <=0)
            {
                ModelState.AddModelError("", "zla oferta");
                return StatusCode(500, ModelState);
            }

            return Ok("stworzono");
        }
    }
}
