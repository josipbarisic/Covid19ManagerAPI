using System;
using System.Collections.Generic;

namespace API.EFModels
{
    public partial class _02LokacijaPacijenta
    {
        public long Id { get; set; }
        public long KorisnikId { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public long Vrijeme { get; set; }

        public virtual _02Pacijent Korisnik { get; set; }
    }
}
