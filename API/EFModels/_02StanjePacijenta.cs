using System;
using System.Collections.Generic;

namespace API.EFModels
{
    public partial class _02StanjePacijenta
    {
        public long Id { get; set; }
        public long KorisnikId { get; set; }
        public decimal Temperatura { get; set; }
        public int Kasalj { get; set; }
        public int Umor { get; set; }
        public int BolUMisicima { get; set; }
        public int Vrijeme { get; set; }

        public virtual _02Pacijent Korisnik { get; set; }
    }
}
