using sklepInternetowy.Models;

namespace sklepInternetowy.Interface
{
    public interface IUzytkownikRepository
    {
        ICollection<Uzytkownik> GetUzytkownicy();
        Uzytkownik GetUzytkownik(int id);
        Uzytkownik GetUzytkownik(string name);
        Transakcja GetTransakcja(int id);
        Przedmiot GetPrzedmiot(int id);
        bool CreateUzytkownik(int id,string name);
        bool DecyzjaTransakcji(int idTransakcji,bool decyzja);
        bool Save();
    }
}
