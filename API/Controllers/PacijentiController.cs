using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/pacijenti")]
    [ApiController]
    public class PacijentiController : ControllerBase
    {
        private readonly IPacijentRepo _repository;
        private readonly IMapper _mapper;

        public PacijentiController(IPacijentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<PacijentReadDTO>> GetAllPacijenti()
        {
            var pacijenti = _repository.GetAllPacijenti();
            return Ok(_mapper.Map<IEnumerable<PacijentReadDTO>>(pacijenti));
        }

        [Authorize]
        [HttpGet("{OIB}", Name = "GetPacijentByOIB")]
        public ActionResult<PacijentReadDTO> GetPacijentByOIB(long OIB)
        {
            var pacijent = _repository.GetPacijentByOIB(OIB);
            if (pacijent != null)
            {
                return Ok(_mapper.Map<PacijentReadDTO>(pacijent));
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<PacijentReadDTO> CreatePacijent(PacijentCreateDTO pacijent)
        {
            var pacijentModel = _mapper.Map<Pacijent>(pacijent);
            _repository.CreatePacijent(pacijentModel);
            _repository.SaveChanges();

            var pacijentReadDTO = _mapper.Map<PacijentReadDTO>(pacijentModel);
            return CreatedAtRoute(nameof(GetPacijentByOIB), new { Oib = pacijentReadDTO.Oib }, pacijentReadDTO);
        }

        [Authorize]
        [HttpPut("{OIB}")]
        public ActionResult UpdatePacijent(int OIB, PacijentUpdateDTO pacijent)
        {
            var pacijentModelFromRepo = _repository.GetPacijentByOIB(OIB);
            if (pacijentModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(pacijent, pacijentModelFromRepo);
            _repository.UpdatePacijent(pacijentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [Authorize]
        [HttpPatch("{OIB}")]
        public ActionResult PartialPacijentUpdate(int OIB, JsonPatchDocument<PacijentUpdateDTO> patchDoc)
        {
            var pacijentModelFromRepo = _repository.GetPacijentByOIB(OIB);
            if (pacijentModelFromRepo == null)
            {
                return NotFound();
            }
            var pacijentToPatch = _mapper.Map<PacijentUpdateDTO>(pacijentModelFromRepo);
            patchDoc.ApplyTo(pacijentToPatch, ModelState);
            if (!TryValidateModel(pacijentToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(pacijentToPatch, pacijentModelFromRepo);
            _repository.UpdatePacijent(pacijentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{OIB}")]
        public ActionResult DeletePacijent(long OIB)
        {
            var pacijentModelFromRepo = _repository.GetPacijentByOIB(OIB);
            if (pacijentModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletePacijent(pacijentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}