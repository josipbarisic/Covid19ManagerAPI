using System.Collections.Generic;
using API.Data;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/epidemiolozi")]
    [ApiController]
    public class EpidemiologController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEpidemiologRepo _repository;

        public EpidemiologController(IMapper mapper, IEpidemiologRepo repo)
        {
            _mapper = mapper;
            _repository = repo;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Epidemiolog>> GetAllPacijenti()
        {
            var epidemiologs = _repository.GetAllEpidemiolozi();

            return Ok(epidemiologs);
        }
    }
}