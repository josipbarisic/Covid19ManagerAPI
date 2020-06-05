using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IPacijentRepo
    {
        bool SaveChanges();

        IEnumerable<Pacijent> GetAllPacijenti();
        Pacijent GetPacijentByOIB(long OIB);
        void CreatePacijent(Pacijent pacijent);
        Task UpdatePacijent(Pacijent pacijent);
        void DeletePacijent(Pacijent pacijent);
        Pacijent GetPacijentByID(long ID);
    }
}
