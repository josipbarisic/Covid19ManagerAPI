using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IPorukaRepo
    {
        bool SaveChanges();

        void CreatePoruka(Poruka poruka);
    }
}
