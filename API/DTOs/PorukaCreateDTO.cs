using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PorukaCreateDTO
    {
        public long Posiljatelj { get; set; }
        public long Vrijeme { get; set; }
        public string Text_poruke { get; set; }
    }
}
