using sklepInternetowy.Models;

namespace sklepInternetowy.Interface
{
    public interface ITransakcjaRepository
    {
        ICollection<Transakcja> GetTransakcje();
        Transakcja GetTransakcja(int id);
        Przedmiot GetPrzedmiot(int id);
        bool CreateTransakcja(int id, int idPrzedmiotu,double cena,int idKupujacego,int idSprzedawcy);
        bool Save();

    }
}
