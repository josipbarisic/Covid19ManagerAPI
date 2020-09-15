using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Poruka
    {
        public long Id { get; set; }
        public long Posiljatelj { get; set; }
        public long Vrijeme { get; set; }
        public string Text_poruke { get; set; }
    }
}
