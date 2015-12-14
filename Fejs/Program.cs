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
        public string Prezime { get { return prezime; } }

        public List<Osoba> prijatelji;

       

        private Osoba() { }
        
        public Osoba(string _ime, string _prezime)
        {

            ime = _ime;
            prezime = _prezime;
            prijatelji = new List<Osoba>();

        }

        public Osoba(Osoba A)
        {
            ime = A.ime;
            prezime = A.prezime;
            prijatelji = A.prijatelji;
        }


        public void dodaj(Osoba A, int x)
        {

            int i;

            for ( i = 0; i < prijatelji.Count; i++)
            {
                if (A.ime.CompareTo(prijatelji[i].ime) > 0)
                {
                    prijatelji.Insert(i, A);
                    break;
                }
                else
                {
                    if (A.ime.CompareTo(prijatelji[i].ime) == 0)
                    {
                        if (A.prezime.CompareTo(prijatelji[i].prezime) > 0)
                        {
                            prijatelji.Insert(i, A);
                            break;
                        }
                    }
                }
            }
            if (i.Equals(prijatelji.Count))
            {
                prijatelji.Add(A);
            }

            if (x.Equals(0))
                A.dodaj(this, 1);

        }

        public List<Osoba> Prijatelji { get { return prijatelji; } }  

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

            Fejs Facebook = new Fejs();

            Osoba A = new Osoba("Ivan", "Ivic");
            Osoba B = new Osoba("Zeljko", "Zec");
            Osoba C = new Osoba("Mario", "Maric");
            Osoba D = new Osoba(A);
            D.dodaj(B,2);
            D.dodaj(A,3);
            D.dodaj(B,2);

            Console.WriteLine("Prijatelji osobe D na fejsu:" );
            List<Osoba> Prijatelji = D.Prijatelji;
            foreach (Osoba o in Prijatelji)
            {
                Console.WriteLine("Prijatelj:" + o.Ime + " " + o.Prezime);
            
            }
            Console.ReadLine();
        }
    }
}
