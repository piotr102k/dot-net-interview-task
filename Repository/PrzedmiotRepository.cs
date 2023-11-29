using sklepInternetowy.Dane;
using sklepInternetowy.Interface;
using sklepInternetowy.Models;

namespace sklepInternetowy.Repository
{
    public class PrzedmiotRepository : IPrzedmiotRepository
    {
        private readonly DaneContekst _contekst;
        public PrzedmiotRepository(DaneContekst contekst)
        {
            _contekst = contekst;
        }

        public bool CreatePrzedmiot(int id, String nazwa, double cena,  int idSprzedajacego)
        {
            Przedmiot przedmiot = new Przedmiot();
            przedmiot.Id = id;
            przedmiot.Nazwa = nazwa;
            przedmiot.Cena = cena;
            przedmiot.idSprzedajacego = idSprzedajacego;

            _contekst.Przedmioty.Add(przedmiot);
            return Save();
        }

        public ICollection<Przedmiot> GetPrzedmioty()
        {
            return _contekst.Przedmioty.OrderBy(p => p.Id).ToList();
        }

        public Przedmiot GetPrzedmiot(int id)
        {
            return _contekst.Przedmioty.Where(p => p.Id == id).FirstOrDefault();
        }
        public Przedmiot GetPrzedmiot(String nazwa)
        {
            return _contekst.Przedmioty.Where(p => p.Nazwa == nazwa).FirstOrDefault();
        }


        public bool Save()
        {
            var saved = _contekst.SaveChanges();
            return saved > 0 ? true : false;

        }
    }
}
