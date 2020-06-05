using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LokacijaReadDTO
    {
        public long Id { get; set; }
        public long KorisnikId { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public long Vrijeme { get; set; }
    }
}
