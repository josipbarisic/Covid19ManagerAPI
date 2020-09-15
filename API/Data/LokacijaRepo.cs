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
        private readonly covidContext _context;
        private readonly IMapper _mapper;

        public LokacijaRepo(covidContext ctx, IMapper mapper)
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

        public IEnumerable<LokacijaPacijenta> GetLokacijeByID(long ID)
        {
            return _mapper.Map<IEnumerable<LokacijaPacijenta>>(_context._02LokacijaPacijenta.Where(x => x.KorisnikId == ID).ToList());
        }

        public LokacijaPacijenta GetLastLokacijeByID(long ID)
        {
            var lokacije = GetLokacijeByID(ID);
            if (lokacije.Count() > 0)
            {
                var zadnjaVrijemeLokacije = lokacije.Max(l => l.Vrijeme);
                return _mapper.Map<LokacijaPacijenta>(lokacije.Where(l => l.Vrijeme == zadnjaVrijemeLokacije).FirstOrDefault());
            }
            return new LokacijaPacijenta();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
