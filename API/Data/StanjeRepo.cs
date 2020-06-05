using API.EFModels;
using API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class StanjeRepo : IStanjeRepo
    {
        private readonly KV_TESTContext _context;
        private readonly IMapper _mapper;

        public StanjeRepo(KV_TESTContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public void CreateStanje(StanjePacijenta stanje)
        {
            if (stanje == null)
            {
                throw new ArgumentNullException(nameof(stanje));
            }

            _context._02StanjePacijenta.Add(_mapper.Map<_02StanjePacijenta>(stanje));
        }

        public IEnumerable<StanjePacijenta> GetStanjaByID(long ID)
        {
            return _mapper.Map<IEnumerable<StanjePacijenta>>(_context._02StanjePacijenta.Where(x => x.KorisnikId == ID).ToList());
        }

        public StanjePacijenta GetLastStanjeByID(long ID)
        {
            var stanja = GetStanjaByID(ID);
            if (stanja.Count() > 0)
            {
                var zadnjaVrijemeStanja = stanja.Max(s => s.Vrijeme);
                return _mapper.Map<StanjePacijenta>(stanja.Where(s => s.Vrijeme == zadnjaVrijemeStanja).FirstOrDefault());
            }
            return new StanjePacijenta();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
