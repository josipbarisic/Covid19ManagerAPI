using API.EFModels;
using API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class PacijentRepo : IPacijentRepo
    {
        private readonly covidContext _context;
        private readonly IMapper _mapper;

        public PacijentRepo(covidContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public void CreatePacijent(Pacijent pacijent)
        {
            if (pacijent == null)
            {
                throw new ArgumentNullException(nameof(pacijent));
            }

            _context._02Pacijent.Add(_mapper.Map<_02Pacijent>(pacijent));
        }

        public void DeletePacijent(Pacijent pacijent)
        {
            if (pacijent == null)
            {
                throw new ArgumentNullException(nameof(pacijent));
            }

            _context._02Pacijent.Remove(_mapper.Map<_02Pacijent>(pacijent));
        }

        public IEnumerable<Pacijent> GetAllPacijenti()
        {
            return _mapper.Map<List<Pacijent>>(_context._02Pacijent.ToList());
        }

        public Pacijent GetPacijentByOIB(long OIB)
        {
            return _mapper.Map<Pacijent>(_context._02Pacijent.Where(x => x.Oib == OIB).FirstOrDefault());
        }

        public Pacijent GetPacijentByID(long ID)
        {
            return _mapper.Map<Pacijent>(_context._02Pacijent.Where(x => x.Id == ID).FirstOrDefault());
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task UpdatePacijent(Pacijent pacijent)
        {
            var entity = _context._02Pacijent.First(g => g.Id == pacijent.Id);
            _context.Entry(entity).CurrentValues.SetValues(pacijent);
            await _context.SaveChangesAsync();
        }
    }
}
