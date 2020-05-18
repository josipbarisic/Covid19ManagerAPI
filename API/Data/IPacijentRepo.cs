using API.Models;
using System.Collections.Generic;

namespace API.Data
{
    public interface IPacijentRepo
    {
        bool SaveChanges();

        IEnumerable<Pacijent> GetAllPacijenti();
        Pacijent GetPacijentByOIB(long OIB);
        void CreatePacijent(Pacijent pacijent);
        void UpdatePacijent(Pacijent pacijent);
        void DeletePacijent(Pacijent pacijent);
    }
}
