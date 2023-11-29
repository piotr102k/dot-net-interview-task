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
    public class PrzedmiotControler : Controller
    {
        private readonly IPrzedmiotRepository _przedmiotRepository;
        public PrzedmiotControler(IPrzedmiotRepository transakcjaRepository)
        {
            _przedmiotRepository = transakcjaRepository;
        }
        [HttpGet("{Katalog Produktow}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Przedmiot>))]
        public IActionResult GetPrzedmioty()
        {
            var transakcje = _przedmiotRepository.GetPrzedmioty();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(transakcje);
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Przedmiot))]
        [ProducesResponseType(400)]
        public IActionResult GetPrzedmiot(int Id)
        {
            var transakcje = _przedmiotRepository.GetPrzedmiot(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(transakcje);


        }
        [HttpGet("{Name}")]
        [ProducesResponseType(200, Type = typeof(Przedmiot))]
        [ProducesResponseType(400)]
        public IActionResult GetPrzedmiot(String name)
        {
            var transakcje = _przedmiotRepository.GetPrzedmiot(name);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(transakcje);


        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePrzedmiot([FromQuery] int id, [FromQuery] String nazwa, [FromQuery] double oferta, [FromQuery] int idSprzedajacego)
        {
            if (oferta <= 0)
            {
                ModelState.AddModelError("", "zla cena");
                return StatusCode(500, ModelState);
            }
            if (!_przedmiotRepository.CreatePrzedmiot(id, nazwa, oferta, idSprzedajacego))
            {
                ModelState.AddModelError("", "error dodawania");
                return StatusCode(500, ModelState);
            }

            return Ok("stworzono");
        }
    }
    }
