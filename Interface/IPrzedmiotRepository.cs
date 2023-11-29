using sklepInternetowy.Models;

namespace sklepInternetowy.Interface
{
    public interface IPrzedmiotRepository
    {
        ICollection<Przedmiot> GetPrzedmioty();
        Przedmiot GetPrzedmiot(int id);
        Przedmiot GetPrzedmiot(string name);

        bool CreatePrzedmiot(int id, string name,double cena,int idSprzedajacego);
        bool Save();
    }
}
