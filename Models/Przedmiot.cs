namespace sklepInternetowy.Models
{
    public class Przedmiot
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public int idSprzedajacego { get; set; }

    }
}
