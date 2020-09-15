using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/poruke")]
    [ApiController]
    public class PorukaController: ControllerBase
    {
        private readonly IPorukaRepo _repository;
        private readonly IMapper _mapper;
        public PorukaController(IPorukaRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<PorukaCreateDTO> CreatePoruka(PorukaCreateDTO poruka)
        {
            var porukaModel = _mapper.Map<Poruka>(poruka);
            _repository.CreatePoruka(porukaModel);
            var status = _repository.SaveChanges();

            if (status)
            {
                return StatusCode(201);
            }
            return StatusCode(503);
        }
    }
}
