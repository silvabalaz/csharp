# csharp
(Računarski praktikum 3, kolegij)
Osoba,Fejs

Klasa Osoba ima ime, prezime te privatni konstruktor.

Klasa Fejs predstavlja skupinu Osoba. Osobe dodajemo funkcijom Dodaj, koja kao parametar prima ime i prezime osobe. 
(Pretpostavka: Nece biti dvije osobe s istim imenom i prezimenom).
Postoji operator indeksiranja, klasu je moguce koristiti u foreach iskazima te u sortiranju 
(sortirati osobe po broju prijatelja, pa po prezimenu, pa po imenu).
Funkcija Izbaci omogućuje izbacivanje osobe sa fejsa. Ukoliko koristimo izbačenu osobu generirana je iznimka.
Operator indeksiranja vraca skup svih osoba kojima je prezime jednako indeksu. Na takvom skupu moguće je 
koristiti indeksiranje koje kao indeks koristi indeks osobe.


Klasa Osoba sadrzi funkcije BrojPrijatelja, te Prijatelji vraca skup svih prijatelja određene osobe.
Funkcija MedjuPrijatelji vraca skup svih međuprijatelja između dvije osobe.
Operator += sprijateljuje dvije osobe, a operatorom -= posvađa.
Ukoliko je neka osoba ostala bez prijatelja, izbacena je sa fejsa. Ukoliko koristimo izbačenu osobu ,generirana je iznimka.
Main demonstrira njihovu upotrebu.




