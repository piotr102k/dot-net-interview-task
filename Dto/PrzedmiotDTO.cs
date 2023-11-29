namespace sklepInternetowy.Dto
{
    public class PrzedmiotDTO
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public int idSprzedajacego { get; set; }
    }
}
