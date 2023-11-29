using Microsoft.EntityFrameworkCore;
using sklepInternetowy.Models;

namespace sklepInternetowy.Dane
{
    public class DaneContekst : DbContext
    {
        public DaneContekst(DbContextOptions<DaneContekst> options): base(options)
        {

        }

        public DbSet<Uzytkownik> Uzytkownicy {  get; set; }
        public DbSet<Transakcja> Transakcje { get; set; }
        public DbSet<Przedmiot> Przedmioty { get; set; }
       
    }
}
