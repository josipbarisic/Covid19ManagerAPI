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
    }
}