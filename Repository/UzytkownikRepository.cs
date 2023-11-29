using sklepInternetowy.Dane;
using sklepInternetowy.Interface;
using sklepInternetowy.Models;

namespace sklepInternetowy.Repository
{
    public class UzytkownikRepository : IUzytkownikRepository
    {
        private readonly DaneContekst _contekst;
        public UzytkownikRepository(DaneContekst contekst)
        {
            _contekst= contekst;
        }

        public bool CreateUzytkownik(int id,string name)
        {
            Uzytkownik uzytkownik = new Uzytkownik();
            uzytkownik.Id = id;
            uzytkownik.Name = name; 
            _contekst.Uzytkownicy.Add(uzytkownik);
            return Save();
        }

        public bool DecyzjaTransakcji(int idTransakcji,bool decyzja)
        {
            if (decyzja)
            {
                _contekst.Przedmioty.Remove(GetPrzedmiot(GetTransakcja(idTransakcji).Id));
                _contekst.Transakcje.Remove(GetTransakcja(idTransakcji));
                return Save();
            }
            else
            {
                _contekst.Transakcje.Remove(GetTransakcja(idTransakcji));
                return Save();
            }
        }

        public Przedmiot GetPrzedmiot(int id)
        {
            return _contekst.Przedmioty.Where(p => p.Id == id).FirstOrDefault();
        }

        public Transakcja GetTransakcja(int id)
        {
            return _contekst.Transakcje.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Uzytkownik> GetUzytkownicy()
        {
            return _contekst.Uzytkownicy.OrderBy(p => p.Id).ToList();
        }

        public Uzytkownik GetUzytkownik(int id)
        {
            return _contekst.Uzytkownicy.Where(p=>p.Id==id).FirstOrDefault();
        }

        public Uzytkownik GetUzytkownik(string name)
        {
            return _contekst.Uzytkownicy.Where(p => p.Name == name).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _contekst.SaveChanges();
            return saved > 0 ? true : false;
            
        }
    }
}
