using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/stanja")]
    [ApiController]
    public class StanjeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStanjeRepo _repository;

        public StanjeController(IMapper mapper, IStanjeRepo repo)
        {
            _mapper = mapper;
            _repository = repo;
        }

        [Authorize]
        [HttpGet("GetStanjaByID/{ID}", Name = "GetStanjaByID")]
        public ActionResult<IEnumerable<StanjePacijentaReadDTO>> GetStanjaByID(int ID)
        {
            var stanja = _repository.GetStanjaByID(ID);
            if (stanja != null)
            {
                return Ok(_mapper.Map<IEnumerable<StanjePacijentaReadDTO>>(stanja));
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("GetLastStanjeByID/{ID}", Name = "GetLastStanjeByID")]
        public ActionResult<IEnumerable<StanjePacijentaReadDTO>> GetLastStanjeByID(int ID)
        {
            var stanje = _repository.GetLastStanjeByID(ID);
            if (stanje != null)
            {
                return Ok(_mapper.Map<StanjePacijentaReadDTO>(stanje));
            }
            return NotFound();
        }
    }
}
