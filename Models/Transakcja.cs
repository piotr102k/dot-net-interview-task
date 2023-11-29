namespace sklepInternetowy.Models
{
    public class Transakcja
    {   
        public int Id { get; set; }
        public int IdPrzedmiotu { get; set; }
        public double Oferta { get; set; }
        public int IdKupujacego {  get; set; }
        public int IdSprzedawcy {  get; set; }

    }
}
