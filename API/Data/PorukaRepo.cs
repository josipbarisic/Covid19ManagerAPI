using API.EFModels;
using API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class PorukaRepo : IPorukaRepo
    {
        private readonly covidContext _context;
        private readonly IMapper _mapper;

        public PorukaRepo(covidContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public void CreatePoruka(Poruka poruka)
        {
            if (poruka == null)
            {
                throw new ArgumentNullException(nameof(poruka));
            }

            _context._02Poruka.Add(_mapper.Map<_02Poruka>(poruka));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
