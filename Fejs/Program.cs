using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fejs
{

    
    class Osoba {

        private string ime;
        private string prezime;

        public string Ime { get; set; }
        public string Prezime { get; set; }

        private Osoba() { }

        public Osoba(string _ime, string _prezime)
        {

            ime = _ime;
            prezime = _prezime;

        }


      }

    class Fejs {

        public List<Osoba> osobe;

        public Fejs()
        {
            osobe = new List<Osoba>();
        }


        public Fejs(List<Osoba> A)
        {
            osobe = new List<Osoba>(A);
        }

        public Fejs(Osoba A)
        {
            osobe = new List<Osoba>();
            osobe.Add(A);
        }

        public Fejs(string _ime, string _prezime)
        {
            osobe = new List<Osoba>();
            osobe.Add(new Osoba(_ime, _prezime));

        }


    
    
    }



    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
        }
    }
}
