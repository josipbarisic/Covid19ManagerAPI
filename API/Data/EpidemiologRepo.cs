using API.EFModels;
using API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class EpidemiologRepo : IEpidemiologRepo
    {
        private readonly covidContext _context;
        private readonly IMapper _mapper;

        public EpidemiologRepo(covidContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public IEnumerable<Epidemiolog> GetAllEpidemiolozi()
        {
            return _mapper.Map<List<Epidemiolog>>(_context._02Epidemiolog.ToList());
        }
    }
}
