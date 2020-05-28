namespace API.Models
{
    public class Pacijent
    {
        public long Id { get; set; }
        public long Oib { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string AdresaSi { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public int Status { get; set; } = 2;
    }
}
