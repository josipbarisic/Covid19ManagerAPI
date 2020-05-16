using System;
using System.Collections.Generic;

namespace API.EFModels
{
    public partial class _02Pacijent
    {
        public _02Pacijent()
        {
            _02LokacijaPacijenta = new HashSet<_02LokacijaPacijenta>();
            _02StanjePacijenta = new HashSet<_02StanjePacijenta>();
        }

        public long Id { get; set; }
        public long Oib { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string AdresaSi { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public int Status { get; set; }

        public virtual _02StatusSifrarnik StatusNavigation { get; set; }
        public virtual ICollection<_02LokacijaPacijenta> _02LokacijaPacijenta { get; set; }
        public virtual ICollection<_02StanjePacijenta> _02StanjePacijenta { get; set; }
    }
}
