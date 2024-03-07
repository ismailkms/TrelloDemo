using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.KartDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrelloDemoAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class KartController : ControllerBase
    {
        private readonly IKartService _kartService;
        private readonly IMapper _mapper;

        public KartController(IKartService kartService, IMapper mapper)
        {
            _kartService = kartService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListKart()
        {
            var values = _kartService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddKart(KartAddDTO kartAddDTO)
        {
            Kart kart = _mapper.Map<Kart>(kartAddDTO);
            _kartService.Add(kart);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdKart(int id)
        {
            var kart = _kartService.GetById(id);
            if (kart == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(kart);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKart(int id)
        {
            var kart = _kartService.GetById(id);
            if (kart == null)
            {
                return NotFound();
            }
            else
            {
                _kartService.Delete(kart);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateKart(KartUpdateDTO kartUpdateDTO)
        {
            Kart kart = _mapper.Map<Kart>(kartUpdateDTO);
            var kartValue = _kartService.GetById(kart.KartId);
            if (kartValue == null)
            {
                return NotFound();
            }
            else
            {
                kartValue.KartIcerik = kart.KartIcerik;
                kartValue.KartSira = kart.KartSira;
                kart.ListeId = kart.ListeId;
                _kartService.Update(kartValue);
                return Ok();
            }
        }
    }
}
