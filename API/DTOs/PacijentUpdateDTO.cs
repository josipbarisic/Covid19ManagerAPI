using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PacijentUpdateDTO
    {
        [Required]
        public long Oib { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string AdresaSi { get; set; }
        [Required]
        public decimal Lat { get; set; }
        [Required]
        public decimal Long { get; set; }
    }
}
