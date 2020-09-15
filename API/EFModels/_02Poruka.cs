using System;
using System.Collections.Generic;

namespace API.EFModels
{
    public partial class _02Poruka
    {
        public long Id { get; set; }
        public long Posiljatelj { get; set; }
        public long Vrijeme { get; set; }
        public string Poruka { get; set; }
    }
}
