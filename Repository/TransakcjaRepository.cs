using sklepInternetowy.Dane;
using sklepInternetowy.Interface;
using sklepInternetowy.Models;

namespace sklepInternetowy.Repository
{
    public class TransakcjaRepository : ITransakcjaRepository
    {
        private readonly DaneContekst _contekst;

        public TransakcjaRepository(DaneContekst contekst)
        {
            _contekst = contekst;
        }

        public bool CreateTransakcja(int id, int IdPrzedmiotu,double Oferta,int IdKupujacego,int IdSprzedawcy)
        {
            Transakcja transakcja = new Transakcja();
            transakcja.Id = id;
            transakcja.IdPrzedmiotu = IdPrzedmiotu;
            transakcja.Oferta = Oferta;
            transakcja.IdSprzedawcy = IdSprzedawcy;
            transakcja.IdKupujacego = IdKupujacego;
            _contekst.Transakcje.Add(transakcja);
            return Save();
        }

        public ICollection<Transakcja> GetTransakcje()
        {
            return _contekst.Transakcje.OrderBy(p => p.Id).ToList();
        }
        public Przedmiot GetPrzedmiot(int id)
        {
            return _contekst.Przedmioty.Where(p => p.Id == id).FirstOrDefault();
        }

        public Transakcja GetTransakcja(int id)
        {
            return _contekst.Transakcje.Where(p => p.Id == id).FirstOrDefault();
        }



        public bool Save()
        {
            var saved = _contekst.SaveChanges();
            return saved > 0 ? true : false;

        }


    }
}
