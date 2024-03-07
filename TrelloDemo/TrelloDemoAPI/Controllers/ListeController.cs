using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ListeDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace TrelloDemoAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ListeController : ControllerBase
    {
        private readonly IListeService _listeService;
        private readonly IMapper _mapper;

        public ListeController(IListeService listeService, IMapper mapper)
        {
            _listeService = listeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListListe()
        {
            var values = _listeService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddListe(ListeAddDTO listeAddDTO)
        {
            Liste liste = _mapper.Map<Liste>(listeAddDTO);
            _listeService.Add(liste);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdListe(int id)
        {
            var liste = _listeService.GetById(id);
            if (liste == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(liste);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteListe(int id)
        {
            var liste = _listeService.GetById(id);
            if (liste == null)
            {
                return NotFound();
            }
            else
            {
                _listeService.Delete(liste);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateListe(ListeUpdateDTO listeUpdateDTO)
        {
            Liste liste = _mapper.Map<Liste>(listeUpdateDTO);
            var listeValue = _listeService.GetById(liste.ListeId);
            if (listeValue == null)
            {
                return NotFound();
            }
            else
            {
                listeValue.ListeAdi = liste.ListeAdi;
                listeValue.ListeSira = liste.ListeSira;
                _listeService.Update(listeValue);
                return Ok();
            }
        }
    }
}
