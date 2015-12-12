# csharp

Osoba,Fejs

Klasa Osoba koja ima ime, prezime te privatni konstruktor.

Klasa Fejs koja predstavlja skupinu Osoba. osobe dodajemo funkcijom Dodaj, koja kao parametar prima ime i prezime osobe. 
(Pretpostavka: Nece biti dvije osobe s istim imenom i prezimenom).
Postoji operator indeksiranja, klasu je moguce koristiti u foreach iskazima te u sortiranju 
(sortirati osobe po broju prijatelja, pa po prezimenu, pa po imenu).
Funkcija Izbaci omogućuje izbacivanje osobe sa fejsa. Ukoliko koristimo izbačenu osobu treba generirati iznimku.
Operator indeksiranja treba vratiti skup svih osoba kojima je prezime jednako indeksu. Na takvom skupu treba biti moguće 
koristiti indeksiranje koje će kao indeks koristiti indeks osobe.


Klasa osoba sadrzi funkcije BrojPrijatelja, te Prijatelji koja ce vratiti skup svih prijatelja određene osobe.
Funkcija MedjuPrijatelji koja će vratiti skup svih međuprijatelja između dvije osobe.
Operatorom += sprijateljujemo dvije osobe, a operatorom -= posvađamo.
Ukoliko je neka osoba ostala bez prijatelja , treba ju izbaciti sa fejsa. Ukoliko koristimo izbačenu osobu ,treba generirati iznimku.
Main demonstrira njihovu upotrebu.




