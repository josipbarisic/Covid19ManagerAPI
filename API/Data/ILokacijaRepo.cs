using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public interface ILokacijaRepo
    {
        bool SaveChanges();

        void CreateLokacija(LokacijaPacijenta lokacija);
    }
}
