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

        Osoba(string _ime, string _prezime)
        {

            ime = _ime;
            prezime = _prezime;

        }



     
    
    }


    class Program
    {
        static void Main(string[] args)
        {


        }
    }
}
