using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/lokacije")]
    [ApiController]
    public class LokacijaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILokacijaRepo _repository;

        public LokacijaController(IMapper mapper, ILokacijaRepo repo)
        {
            _mapper = mapper;
            _repository = repo;
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateLokacija(LokacijaCreateDTO lokacija)
        {
            var pacijentModel = _mapper.Map<LokacijaPacijenta>(lokacija);
            _repository.CreateLokacija(pacijentModel);
            var status = _repository.SaveChanges();
            if (status)
            {
                return StatusCode(201);
            }
            return StatusCode(503);
        }

        [Authorize]
        [HttpGet("GetLokacijeByID/{ID}", Name = "GetLokacijeByID")]
        public ActionResult<IEnumerable<LokacijaReadDTO>> GetLokacijeByID(int ID)
        {
            var lokacije = _repository.GetLokacijeByID(ID);
            if (lokacije != null)
            {
                return Ok(_mapper.Map<IEnumerable<LokacijaReadDTO>>(lokacije));
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("GetLastLokacijeByID/{ID}", Name = "GetLastLokacijeByID")]
        public ActionResult<LokacijaReadDTO> GetLastLokacijeByID(int ID)
        {
            var lokacija = _repository.GetLastLokacijeByID(ID);
            if (lokacija != null)
            {
                return Ok(_mapper.Map<LokacijaReadDTO>(lokacija));
            }
            return NotFound();
        }
    }
}