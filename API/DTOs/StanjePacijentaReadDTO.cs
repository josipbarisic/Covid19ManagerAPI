using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class StanjePacijentaReadDTO
    {
        public long Id { get; set; }
        public long KorisnikId { get; set; }
        public decimal Temperatura { get; set; }
        public int Kasalj { get; set; }
        public int Umor { get; set; }
        public int BolUMisicima { get; set; }
        public int Vrijeme { get; set; }
    }
}
