using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Epidemiolog
    {

        public int Id { get; set; }
        public string Zzjz { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public string BrojTelefona { get; set; }
    }
}
