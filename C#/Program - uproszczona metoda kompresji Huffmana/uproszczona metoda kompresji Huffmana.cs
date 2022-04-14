﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        // To posłuży mi do zapisu ciągu w systemie binarnym i wypisania tego później na ekran
        public static string wypiszCiagBinarny = "";

        // Zmienna, którą wykorzystam po to aby ładniej wyświetlało wynik na ekran
        public static bool pobranoDaneZPliku = false;

        public static string Dec2Bin(int dec, int n)
        {
            string bin = "";

            while (dec != 0)
            {
                bin += (byte)(dec % 2);
                dec /= 2;
            }

            // Dopisuje brakujące liczby jako 0
            if (bin.Length < n)
            {
                for (int i = bin.Length; i < n; i++)
                {
                    bin += "0";
                }
            }

            // Odwracam wynik dla poprawności
            char[] tab = bin.ToCharArray();
            Array.Reverse(tab);
            bin = new string(tab);

            return bin;
        }

        public static int Bin2Dec(string bin)
        {
            // Do tej sytuacji powinno dojść tylko raz, na końcu
            if(bin.Length < 8)
            {
                bin = dopiszBrakujaceBityJako1(bin);
            }

            wypiszCiagBinarny += bin;

            // Odwracam liczbe poniewaz zamieniamy ją potęgując od końca tzn.  <- 2^4 2^3 2^2 2^1 <-
            char[] tab = bin.ToCharArray();
            Array.Reverse(tab);
            bin = new string(tab);

            double dec = 0;

            // Jeżeli liczba nie jest zerem to podnosimy ją do potęgi
            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] != '0')
                {
                    dec += Math.Pow(2, i);
                }
            }

            return (int)dec;
        }

        // Tutaj dopisuję brakujące bity jako 1
        public static string dopiszBrakujaceBityJako1(string ciag)
        {
            int dlugosc = ciag.Length;
            int oczekiwanaDlugosc = 8;

            for(int i = 0; i < oczekiwanaDlugosc - dlugosc; i++)
            {
                ciag += '1';
            }

            return ciag;
        }

        // Tutaj sprawdzam jaki indeks ma litera z tekstu w słowniku, w przypakdu tekstu AABBABBC dla słownika ABC indeks A będzie 0 itd.
        public static int indeksWCiagu(char literaTekstu, string slownik)
        {
            int indeks = 0;

            for (int i = 0; i < slownik.Length; i++)
            {
                if (literaTekstu == slownik[i])
                {
                    indeks = i;
                    break;
                }
            }

            return indeks;
        }

        // Tutaj sortuje słownik za pomocą tablicy charów
        public static string sortowanieSlownika(char[] slownik)
        {
            string slownikStr = new string(slownik);
            StringBuilder sb = new StringBuilder(slownikStr);

            for (int i = 0; i < sb.Length; i++)
            {
                for (int j = 1; j < sb.Length; j++)
                {
                    if ((int)sb[j] < (int)sb[j - 1])
                    {
                        char zmiennaPomocnicza = sb[j];
                        sb[j] = sb[j - 1];
                        sb[j - 1] = zmiennaPomocnicza;
                    }
                }
            }

            slownikStr = sb.ToString();

            return slownikStr;
        }

        // Tutaj tworzę Dictionary, w którym jednocześnie zliczam powtórzenia konkretnych liter
        public static void stworzSlownik(string tekst, Dictionary<char, int> slownikZLiczbaPowtorzen)
        {
            for (int i = 0; i < tekst.Length; i++)
            {
                int licznik = 0;

                for (int j = 0; j < tekst.Length; j++)
                {
                    if ((tekst[i] == tekst[j]))
                    {
                        licznik++;
                    }
                }
                if (slownikZLiczbaPowtorzen.ContainsKey(tekst[i]) == false)
                {
                    slownikZLiczbaPowtorzen.Add(tekst[i], licznik);
                }
            }
        }

        // Funkcja pomocnicza do wypisywania kolorowych tekstów na konsolę
        public static void kolorujTekst(ConsoleColor kolor, string? tekstPrzed, string tekst)
        {
            if(tekstPrzed!= null)
            {
                Console.Write(tekstPrzed);
            }
            Console.ForegroundColor = kolor;
            Console.Write(tekst);
            Console.ResetColor();
        }

        public static string zamienLiteryNaBityPotemNaChar(int r, int n, string tekst, string slownik)
        {
            // Tutaj zamieniam litery na liczby binarne a następnie 8 bitów na liczby dziesiętne a potem te liczby na chary
            // Tutaj są kodowane 3 pierwsze bity
            string ciagTymczasowy = Dec2Bin(r, 3);

            string zkompresowanaWartosc = "";

            Console.Write("\n\n");

            for (int i = 0; i < tekst.Length; i++)
            {
                ciagTymczasowy += Dec2Bin(indeksWCiagu(tekst[i], slownik), n);

                if (ciagTymczasowy.Length >= 8)
                {
                    string przyciecie = ciagTymczasowy.Substring(0, 8);

                    ciagTymczasowy = ciagTymczasowy.Remove(0, 8);

                    int wypisz = Bin2Dec(przyciecie);

                    kolorujTekst(ConsoleColor.Green, null, wypisz.ToString() + " ");

                    zkompresowanaWartosc += (char)wypisz;
                }
            }

            // Tutaj sprawdzam czy zostają jakieś bity na końcu, jeżeli tak to je również dodaje do wyniku końcowego
            if (ciagTymczasowy.Length != 0)
            {
                int wypisz = Bin2Dec(ciagTymczasowy);

                kolorujTekst(ConsoleColor.Green, " ", wypisz.ToString());

                zkompresowanaWartosc += (char)wypisz;
            }

            return zkompresowanaWartosc;
        }

        public static string utworzPlikJesliNieIstnieje_OtworzJesliIstniejeIWykonajDzialania_ZwrocZawartoscPliku(string tekst, string plik)
        {
            // Tworzę plik jeśli nie istnieje, do któego zapisuję wprowadzony ciąg, następnie ciąg pobieram z pliku
            StreamWriter sw;

            if (!File.Exists(plik))
            {
                sw = File.CreateText(plik);

                kolorujTekst(ConsoleColor.Green, $"Tworzę plik o nazwie \"", plik);
                kolorujTekst(ConsoleColor.Yellow, $"\" w tej lokalizacji: \"", Directory.GetCurrentDirectory());
                Console.Write($"\"...\n\n");
                Console.Write("Podaj tekst do kompresji: ");

                tekst = Console.ReadLine();
                Console.Clear();

                sw.Write(tekst); // Zapisuję do pliku
                sw.Close();
            }
            else
            {
                if(!pobranoDaneZPliku)
                {
                    kolorujTekst(ConsoleColor.Green, $"Plik \"", plik);
                    kolorujTekst(ConsoleColor.Yellow, $"\" w lokalizacji \"", Directory.GetCurrentDirectory());
                    Console.Write($"\" juz istnieje, wykorzystam tekst, ktory sie w nim znajduje...\n\n");
                }
                
                sw = new StreamWriter(plik, true); // Nowy tekst będzie dołączany do pliku
                sw.Write(tekst); // Zapisuję do pliku
                sw.Close();
            }

            // Odczytuję zawartość pliku
            StreamReader sr = File.OpenText(plik);

            tekst = sr.ReadToEnd();

            sr.Close();

            pobranoDaneZPliku = true;

            return tekst;
        }

        public static void metodaHuffmana(string tekst, string plik)
        {
            string zawartoscPliku = "";

            kolorujTekst(ConsoleColor.Red, "Tekst do kompresji: ", tekst);

            Console.WriteLine("\n");

            int l = tekst.Length;

            // Tutaj tworzę słownik
            Dictionary<char, int> slownikZLiczbaPowtorzen = new Dictionary<char, int>();

            stworzSlownik(tekst, slownikZLiczbaPowtorzen);

            // Tutaj wypisuję wszystkie niezbędne informacje:
            char[] litery = new char[slownikZLiczbaPowtorzen.Keys.Count];
            slownikZLiczbaPowtorzen.Keys.CopyTo(litery, 0); // Kopiuję klucze do tablicy charow litery zaczynajac od 0 w tablicy charow

            string slownik = sortowanieSlownika(litery);

            kolorujTekst(ConsoleColor.Yellow, "Slownik: ", slownik);

            Console.Write("\nWystępowanie liter: ");
            foreach (KeyValuePair<char, int> kvp in slownikZLiczbaPowtorzen)
            {
                Console.Write("{0}x{1} ", kvp.Key, kvp.Value);
            }
            Console.Write("\n");

            int x = slownik.Length;

            // Tutaj zapisuję do pliku długość słownika rzutując na char tzn. dla słownika ABC będzie to (char)3
            zawartoscPliku = utworzPlikJesliNieIstnieje_OtworzJesliIstniejeIWykonajDzialania_ZwrocZawartoscPliku(((char)x).ToString(), plik);
            zawartoscPliku = utworzPlikJesliNieIstnieje_OtworzJesliIstniejeIWykonajDzialania_ZwrocZawartoscPliku(slownik, plik);

            double n = Math.Ceiling(Math.Log2(x));

            kolorujTekst(ConsoleColor.Cyan, "\nDlugosc tekstu przed kompresja: ", l.ToString());
            kolorujTekst(ConsoleColor.Cyan, "\nUnikalnych liter: ", x.ToString());
            kolorujTekst(ConsoleColor.Cyan, "\nLiczba bitów na znak: ", n.ToString());

            double r = (8 - (l * n + 3) % 8) % 8;

            kolorujTekst(ConsoleColor.Cyan, "\nLiczba nadmiarowych 1: ", r.ToString());

            // Tutaj tworzę zkompresowaną wartość
            string zkompresowanaWartosc = zamienLiteryNaBityPotemNaChar((int)r, (int)n, tekst, slownik);

            // Tutaj dodaję do zawartości pliku zakompresowaną wartość
            zawartoscPliku = utworzPlikJesliNieIstnieje_OtworzJesliIstniejeIWykonajDzialania_ZwrocZawartoscPliku(zkompresowanaWartosc, plik);

            // Wypisuję z kolorami ciąg binarny
            // Najpierw dodaję spacje co 8 miejsc
            StringBuilder sb = new StringBuilder(wypiszCiagBinarny);

            for (int i = 8; i < sb.Length; i += 8 + 1) //Dzięki dodaniu 1 dobrze nadaje spacje
            {
                sb.Insert(i, " ");
            }
            wypiszCiagBinarny = sb.ToString();

            kolorujTekst(ConsoleColor.Magenta, "\n", wypiszCiagBinarny.Substring(0, 3));
            Console.Write(wypiszCiagBinarny.Substring(3, wypiszCiagBinarny.Length - 3 - (int)r));
            kolorujTekst(ConsoleColor.Magenta, null, wypiszCiagBinarny.Substring(wypiszCiagBinarny.Length - (int)r, (int)r));

            // Tutaj wypisuję ostateczny wynik, niektóre znaki są kodowane jako "?" po wypisaniu na konsolę, jednak w zmiennej zakodowane są w odpowiedni sposób, prawdopodobnie jest to związane z kodowaniem znaków powyżej 127 przez VisualStudio/C#
            Console.Write("\n");
            kolorujTekst(ConsoleColor.Green, "\nSkompresowany tekst: ", zawartoscPliku);
            kolorujTekst(ConsoleColor.Cyan, "\nDlugosc tekstu po kompresji: ", zkompresowanaWartosc.Length.ToString());
            kolorujTekst(ConsoleColor.White, "\n\n", "Niektore dane moga byc zle wyswietlane np. jako \"?\" jednak w pliku zapisywane sa poprawnie.");
            Console.Write("\n");

            kolorujTekst(ConsoleColor.Green, $"\n\nPlik \"", plik);
            kolorujTekst(ConsoleColor.Yellow, $"\" znajdziesz w tej lokalizacji \"", Directory.GetCurrentDirectory());
            Console.Write($"\"\n\n");
        }

        static void Main(string[] args)
        {

            string tekst = "";
            string plik = @"uproszczona_metoda_huffmana.txt";

            tekst = utworzPlikJesliNieIstnieje_OtworzJesliIstniejeIWykonajDzialania_ZwrocZawartoscPliku(tekst, plik);

            File.WriteAllText(plik, string.Empty); // Czyszczę zawartość pliku aby zrobić miejsce na zakodowany ciąg

            if(tekst != "")
            {
                metodaHuffmana(tekst, plik);
            }
            else
            {
                Console.WriteLine();
                kolorujTekst(ConsoleColor.Red, "\n", $"Znaleziono plik \"{plik}\" jednak jest on pusty lub nie nadaje sie do odczytu, dodaj do pliku tekst i sprobuj jeszcze raz... \n\n");
            }
        }
    }
}
