using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IStanjeRepo
    {
        bool SaveChanges();

        IEnumerable<StanjePacijenta> GetStanjaByID(long ID);
        StanjePacijenta GetLastStanjeByID(long ID);
        void CreateStanje(StanjePacijenta stanje);
    }
}
