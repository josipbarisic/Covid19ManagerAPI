using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IEpidemiologRepo
    {
        IEnumerable<Epidemiolog> GetAllEpidemiolozi();
    }
}
