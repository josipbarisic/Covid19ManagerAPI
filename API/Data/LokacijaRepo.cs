using API.EFModels;
using API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class LokacijaRepo : ILokacijaRepo
    {
        private readonly KV_TESTContext _context;
        private readonly IMapper _mapper;

        public LokacijaRepo(KV_TESTContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public void CreateLokacija(LokacijaPacijenta lokacija)
        {
            if (lokacija == null)
            {
                throw new ArgumentNullException(nameof(lokacija));
            }

            _context._02LokacijaPacijenta.Add(_mapper.Map<_02LokacijaPacijenta>(lokacija));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
