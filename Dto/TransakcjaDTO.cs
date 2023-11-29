using sklepInternetowy.Models;

namespace sklepInternetowy.Dto
{
    public class TransakcjaDTO
    {
        public int Id { get; set; }
        public int IdPrzedmiotu { get; set; }
        public double Oferta { get; set; }
        public int IdKupujacego { get; set; }
        public int IdSprzedawcy { get; set; }
    }
}
