using System;
using System.Collections.Generic;

namespace API.EFModels
{
    public partial class _02StatusSifrarnik
    {
        public _02StatusSifrarnik()
        {
            _02Pacijent = new HashSet<_02Pacijent>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<_02Pacijent> _02Pacijent { get; set; }
    }
}
