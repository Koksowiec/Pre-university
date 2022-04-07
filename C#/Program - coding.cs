using System;

namespace lab4_algorytmy_szczepanski_krzysztof
{
    class Program
    {
        //Zad1
        static int[] ciagCezara(string ciag, int przesuniecieCezara)
        {
            int[] literyCiagu = new int[ciag.Length];

            for (int i = 0; i < ciag.Length; i++)
            {
                int pomoc = ciag[i] + przesuniecieCezara;

                if (ciag[i] <= 90 && pomoc > 90)
                {
                    int reszta = pomoc - 90;
                    pomoc = 64 + reszta;
                }
                else if (ciag[i] >= 97 && pomoc > 122)
                {
                    int reszta = pomoc - 122;
                    pomoc = 96 + reszta;
                }

                literyCiagu[i] = pomoc;

                Console.Write((char)literyCiagu[i]);
            }

            return(literyCiagu);
        }

        static void Main(string[] args)
        {
            int[] tab = new int[25];

            Console.Write("Podaj ciąg do zakodowania: ");
            string ciag = Console.ReadLine();

            int przesuniecieCezara = 26;

            Console.Write("Podaj liczbę Cezara z zakresu od 1 do 25: ");
            przesuniecieCezara = Convert.ToInt32(Console.ReadLine());

            while (przesuniecieCezara > 25 || przesuniecieCezara <= 0)
            {
                Console.Write("Zły zakres, podaj jeszcze raz: ");
                przesuniecieCezara = Convert.ToInt32(Console.ReadLine());
            }

            ciagCezara(ciag, przesuniecieCezara);
        }
        

        //Zad2
        /*
        static char[] zakodujZdekoduj(string ciag)
        {
            char[] nowyCiag = new char[ciag.Length];

            for(int i = 0; i < ciag.Length; i++)
            {
                nowyCiag[i] = ciag[ciag.Length - 1 - i];
            }

            Console.WriteLine(nowyCiag);

            for (int i = 0; i < ciag.Length; i++)
            {
                nowyCiag[i] = ciag[i];
            }

            Console.WriteLine(nowyCiag);

            return nowyCiag;
        }

        static void Main(string[] args)
        {
            Console.Write("Podaj ciąg do zakodowania: ");
            string ciag = Console.ReadLine();
            zakodujZdekoduj(ciag);
        }
        */

        //Zad3
        /*
        static void zamianaLiczbyNaInnySystem(int liczba, int system)
        {
            int[] tab = new int[32];

            for (int i = 0; liczba != 0; i++)
            {
                tab[i] = liczba % system;
                liczba = liczba / system;
            }

            bool napotkalemLiczbe = false;//Zmienna pomocnicza aby wyswietlana tablica na koncu nie zaczynala sie od np.30 zer tylko od pierwszej liczby jaka napotka

            for (int i = tab.Length - 1; i >= 0; i--)
            {
                if (tab[i] != 0)
                {
                    napotkalemLiczbe = true;
                }

                if (napotkalemLiczbe)
                {
                    Console.Write(tab[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Podaj system: ");
            int system = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj liczbę w systemie dziesiętnym: ");
            int liczba = Convert.ToInt32(Console.ReadLine());
            zamianaLiczbyNaInnySystem(liczba, system);
        }
        */
    }
}
