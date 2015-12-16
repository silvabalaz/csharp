using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fejs
{


    class Osoba : IComparable<Osoba>
    {

        private string ime;
        private string prezime;

        public string Ime { get { return ime; } }
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

            for (i = 0; i < prijatelji.Count; i++)
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


        public void brisi(Osoba A, int x)
        {

            for (int i = 0; i < prijatelji.Count; i++)
                if (prijatelji[i] == A)
                {
                    prijatelji.RemoveAt(i);
                    break;
                }
            if (x.Equals(0))
                A.brisi(this, 1);

        }

        public static Osoba operator +(Osoba A, Osoba B)
        {
            A.dodaj(B, 0);
            return A;
        }

        public static Osoba operator -(Osoba A, Osoba B)
        {
            A.brisi(B, 0);
            return A;
        }


        public List<Osoba> MeduPrijatelji(Osoba A)
        {

            HashSet<Osoba> hashSet1 = new HashSet<Osoba>(A.prijatelji);
            HashSet<Osoba> hashSet2 = new HashSet<Osoba>(this.prijatelji);

            hashSet1.IntersectWith(hashSet2);
            List<Osoba> intersection = hashSet1.ToList();


            return intersection;
        }

        #region IComparable Members

        public int CompareTo(Osoba o)
        {
            return prezime.CompareTo(o.prezime);
        }

        #endregion

        public enum TipUsporedbe
        {
            BrojPrijatelja,
            Ime,
            Prezime
        };

        class UsporediPoImenu : IComparer<Osoba>
        {

            #region IComparer Members

            public int Compare(Osoba x, Osoba y)
            {

                return x.ime.CompareTo(y.ime);

            }

            #endregion

        }

        class UsporediPoPrezimenu : IComparer<Osoba>
        {
            #region IComparer Members

            public int Compare(Osoba x, Osoba y)
            {

                return x.prezime.CompareTo(y.prezime);

            }

            #endregion
        }

        class UsporediPoBrojuPrijatelja : IComparer<Osoba>
        {
            #region IComparer Members

            public int Compare(Osoba x, Osoba y)
            {

                return x.prijatelji.Count.CompareTo(y.prijatelji.Count);

            }

            #endregion
        }

        internal static IComparer<Osoba> SortBrojPrijatelja
        {
            get
            {
                return ((IComparer<Osoba>)new Osoba.UsporediPoBrojuPrijatelja());
            }
        }

        internal static IComparer<Osoba> SortIme
        {
            get
            {
                return ((IComparer<Osoba>)new Osoba.UsporediPoImenu());
            }
        }

        internal static IComparer<Osoba> SortPrezime
        {
            get
            {
                return ((IComparer<Osoba>)new Osoba.UsporediPoPrezimenu());
            }
        }



    

    }
    class Fejs : IEnumerable<Osoba>{

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

        public void dodaj(Osoba A)
        {
            osobe.Add(A);
        }

        public void dodaj(string i, string p)
        {
            osobe.Add(new Osoba(i, p));
        }


        public void izbaci(Osoba A)
        {
            osobe.Remove(A);
        }

        public void izbaci(string i, string p)
        {
            osobe.Remove(new Osoba(i, p));
        }


        public IEnumerator<Osoba> GetEnumerator()
        {

            foreach (Osoba o in this.osobe)
                yield return o;

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        public void Sort(Osoba.TipUsporedbe tipUsporedbe)
        {
            switch (tipUsporedbe)
            { 
                case Osoba.TipUsporedbe.BrojPrijatelja:
                    osobe.Sort(Osoba.SortBrojPrijatelja);
                    break;
                case Osoba.TipUsporedbe.Ime:
                    osobe.Sort(Osoba.SortIme);
                    break;
                case Osoba.TipUsporedbe.Prezime:
                    osobe.Sort(Osoba.SortPrezime);
                    break;

           }
        
        
        }


        public List<Osoba> this[string prezime]
        {
            get
            {
                List<Osoba> ubaci = new List<Osoba>();
                if (prezime.Equals("*"))
                {
                    foreach (Osoba A in this.osobe)
                        ubaci.Add(A);
                    return ubaci;
                }

                foreach (Osoba A in this.osobe)
                    if (prezime.Equals(A.Prezime))
                        ubaci.Add(A);
                return ubaci;
            }
        }

    
    }



    class Program
    {
        static void Main(string[] args)
        {

            Fejs Facebook = new Fejs();
            
            Osoba A = new Osoba("Ivan", "Celinic");
            Osoba B = new Osoba("Zeljko", "Zec");
            Osoba C = new Osoba("Mario", "Maric");
            Osoba D = new Osoba(A);
            Osoba E = new Osoba("Marko","Kutle");
            Osoba F = new Osoba("Ines","Vujevic");
            Osoba G = new Osoba("Andrea","Mokrovic");
            Osoba H = new Osoba("Sanela","Bisek");

            E.dodaj(B,0);
            E.dodaj(A,0);
            E.dodaj(C,0);

            B.dodaj(A,0);
            B.dodaj(C,0);
            B.dodaj(F, 0);
            B.dodaj(G, 0);
            B.dodaj(H, 0);


            Console.WriteLine("Zajednicki prijatelji (MeduPrijatelji) osoba B i E:" );
            List<Osoba> zajednickiPrijatelji = B.MeduPrijatelji(E);
            foreach(Osoba o in zajednickiPrijatelji)
            { 
              Console.WriteLine("Prijatelji zajednicki" + o.Ime + " " + o.Prezime);
            }

           



            Console.WriteLine("Prijatelji osobe D na fejsu:" );
            List<Osoba> Prijatelji = D.Prijatelji;
            foreach (Osoba o in Prijatelji)
            {
                Console.WriteLine("Prijatelj:" + o.Ime + " " + o.Prezime);
            
            }
            Console.WriteLine("Izbrisani prijatelj A u D:");
            D.brisi(B,1);


            foreach (Osoba o in Prijatelji)
            {
                Console.WriteLine("Prijatelj:" + o.Ime + " " + o.Prezime);

            }


            D += B;

            foreach (Osoba o in Prijatelji)
            {
                Console.WriteLine("Prijatelj:" + o.Ime + " " + o.Prezime);

            }

           
            Facebook.dodaj(A);
            Facebook.dodaj(B);
            Facebook.dodaj("Silva","Haberl");
            Facebook.dodaj("Ana", "Zinic");
            Facebook.dodaj(E);
            Facebook.dodaj(F);
            Facebook.dodaj(G);
            Facebook.izbaci(H);
         
                
                Console.WriteLine("Osobe u Fejsu nakon dodavanja fjama dodaj:");
                foreach(Osoba o in Facebook)
                {
                   Console.WriteLine("Osoba:" + o.Ime + " " + o.Prezime);
                }

                Console.WriteLine("Sort po imenu:");

                Facebook.Sort(Osoba.TipUsporedbe.Ime);
                foreach (Osoba o in Facebook)
                {
                    Console.WriteLine("Osoba:" +  o.Ime + " " + o.Prezime);
                }

                Console.WriteLine("Sort po prezimenu:");

                Facebook.Sort(Osoba.TipUsporedbe.Prezime);
                foreach (Osoba o in Facebook)
                {
                    Console.WriteLine("Osoba:" +  o.Ime + " " + o.Prezime);
                }

                Console.WriteLine("Sort po BrojuPrijatelja:");

                Facebook.Sort(Osoba.TipUsporedbe.BrojPrijatelja);
                foreach (Osoba o in Facebook)
                {
                    Console.WriteLine("Osoba:"  + o.Ime + "  " + o.Prezime);
                }


              
                    
                



                Console.WriteLine("Ispisi sve osobe sa prezimenom Haberl koje su na Fejsu");
                foreach (Osoba o in Facebook["Haberl"]) // ispisi sve ide sa Fejsa
                    Console.WriteLine(o.Ime + " " + o.Prezime);
                Console.WriteLine("--------------------------------------------------------");



                Console.WriteLine("****************************************");
                Console.WriteLine("Sve osobe na facebooku: ");
                foreach (Osoba o in Facebook["*"])
                {
                    Console.WriteLine(o.Ime + " " + o.Prezime);
                }
                Console.WriteLine("****************************************");

            /*
                Console.WriteLine("Ispisi sve osobe sa imenom Silva koje su na Fejsu");
                foreach (Osoba o in Facebook["*"]["Silva"]) 
                    Console.WriteLine(o.ToString());
                Console.WriteLine("--------------------------------------------------------");
            */


                Console.ReadLine();
        }
    }
}
