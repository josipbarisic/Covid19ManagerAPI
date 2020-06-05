using System.ComponentModel.DataAnnotations;

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
        [Required]
        public int Status { get; set; }
    }
}
