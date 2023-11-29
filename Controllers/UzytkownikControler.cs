using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sklepInternetowy.Dto;
using sklepInternetowy.Interface;
using sklepInternetowy.Models;

namespace sklepInternetowy.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UzytkownikControler : Controller
    {
        private readonly IUzytkownikRepository _uzytkownikRepository;
        public UzytkownikControler(IUzytkownikRepository uzytkownikRepository)
        {
            _uzytkownikRepository = uzytkownikRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Uzytkownik>))]
        public IActionResult GetUzytkownicy()
        {
            var uzytkownicy = _uzytkownikRepository.GetUzytkownicy();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(uzytkownicy);
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type=typeof(Uzytkownik))]
        [ProducesResponseType(400)]
        public IActionResult GetUzytkownik(int Id)
        {
            var uzytkownik = _uzytkownikRepository.GetUzytkownik(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(uzytkownik);


        }
        [HttpGet("{Name}")]
        [ProducesResponseType(200, Type = typeof(Uzytkownik))]
        [ProducesResponseType(400)]
        public IActionResult GetUzytkownik(String name)
        {
            var uzytkownik = _uzytkownikRepository.GetUzytkownik(name);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(uzytkownik);
        }

        [HttpPut("Negocjacje")]
        [ProducesResponseType(200, Type = typeof(Uzytkownik))]
        [ProducesResponseType(400)]
        public IActionResult DecyzjaTransakcji( [FromQuery]  bool decyzjaTransakcji, [FromQuery] int idTransakcji)
        {
            var deyczja = _uzytkownikRepository.DecyzjaTransakcji(idTransakcji, decyzjaTransakcji);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(deyczja);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUzytkownik([FromQuery] int id, [FromQuery] string name)
        {
            if (name.IsNullOrEmpty())
            {
                ModelState.AddModelError("", "brak nazwy");
                return StatusCode(500, ModelState);
            }
            if (!_uzytkownikRepository.CreateUzytkownik(id,name))
            {
                ModelState.AddModelError("", "error dodawania");
                return StatusCode(500, ModelState);
            }
            return Ok("stworzono");
        }
    }
}
