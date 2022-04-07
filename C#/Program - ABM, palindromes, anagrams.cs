using System;
using System.Collections.Generic;
using System.IO;

namespace lab3_algorytmy_szczepanski_krzysztof
{
    class Program
    {
        //Zad1
        /*
        const int K = 26 * 2 + 2 * 2 + 1; //ZnakiASCII + polskie litery + odstep
        static int[] shift = new int[K];

        static int indeks(char c)
        {
            switch(c)
            {
                case ' ': return 0;
                case 'ę': return 53;
                case 'Ę': return 54;
                case 'ł': return 55;
                case 'Ł': return 56;
                //tu można kolejno doddać resztę polskich znaków,
                //ze względu na brak czasu nie robię tego

                default:
                    if(c>=97 && c<=122)
                    {
                        return c - 'a' + 1;
                    }
                    else
                    {
                        return c - 'A' + 27;
                    }
            }
        }

        static int BM(string w, string t)
        {
            int i, j, N = t.Length, M = w.Length;
            for(i=M-1, j=M-1; j>=0; i--, j--)
            {
                while (t[i]!=w[j])
                {
                    int x = shift[indeks(t[i])];

                    if(M-j > x)
                    {
                        i += M - j;
                    }
                    else
                    {
                        i += x;
                    }

                    if (i>=N)
                    {
                        return -1;
                    }

                    j = M - 1;
                }            
            }
            return i + 1;
        }

        static void Main(string[] args)
        {
;           string t = "Z pamiętnika młodej lekarki";
            Console.WriteLine(t);
            Console.WriteLine("Szukam slowa 'lek'");
            Console.WriteLine("Szukana fraza znajduje się na pozycji: " + BM("lek", t));
        }
        /*

        //Zad2
        /*
        static bool czy_palindrom(string wyraz)
        {
            for(int i = 0; i < wyraz.Length; i++)
            {
                if(wyraz[i] != wyraz[wyraz.Length-1-i])
                {
                    return false;
                }
            }

            return true;
        }
        static void Main(string[] args)
        {
            string[] wyrazy = System.IO.File.ReadAllLines(@"C:\Users\szcze\source\repos\lab3-algorytmy-szczepanski-krzysztof\lab3-algorytmy-szczepanski-krzysztof\palindromy.txt");
            List<string> palindromy = new List<string>();
            int licznik = 0;
            for(int i = 0; i < wyrazy.Length; i++)
            {
                if(czy_palindrom(wyrazy[i]))
                {
                    Console.WriteLine(wyrazy[i]);
                    palindromy.Add(wyrazy[i]);
                    licznik++;
                }
            }

            Console.WriteLine(licznik);

            TextWriter plik = File.CreateText("wszystkie_palindromy.txt");
            foreach (String wyraz in palindromy)
            {
                plik.WriteLine(wyraz);
            }
            plik.Close();
        }
        */

        //Zad3
        
        static bool czy_anagram(string a, string b)
        {
            int dlugosc1 = a.Length, dlugosc2 = b.Length;

            //jesli ilosc znakow sie nie zgadza to zwroc false
            if (dlugosc1 != dlugosc2)
            {
                return false;
            }

            int[] licz = new int[256];

            //Zliczamy litery pierwszego wyrazu
            for(int i = 0; i<dlugosc1; i++)
            {
                licz[a[i]]++;
            }

            //Zliczamy litery drugiego wyrazu
            for (int i = 0; i < dlugosc1; i++)
            {
                licz[b[i]]--;
            }

            for(int i = 0; i<licz.Length; i++)
            {
                //Jesli licznik sie nie wyzerowal
                if(licz[i]!=0)
                {
                    return false;
                }    
            }

            return true;
        }

        static void Main(string[] args)
        {
            string[] wyrazy = System.IO.File.ReadAllLines(@"C:\Users\szcze\source\repos\lab3-algorytmy-szczepanski-krzysztof\lab3-algorytmy-szczepanski-krzysztof\anagramy.txt");
            List<string> anagramy = new List<string>();
            int licznik = 0;

            for (int i = 1; i < wyrazy.Length; i++)
            {
                /*
                 * Tutaj chciałem pozbyć się spacji z każdego ciągu
                 * Jednak nie udało mi się tego zrobić
                char spacja = ' ';
                string wyraz_aktualny = wyrazy[i];
                string wyraz_poprzedni = wyrazy[i - 1];

                for (int j = 0; j < wyraz_aktualny.Length; j++)
                {
                    if (wyraz_aktualny[j] == spacja)
                    {
                        wyraz_aktualny.Trim(spacja);
                    }
                }

                for (int j = 0; j < wyraz_poprzedni.Length; j++)
                {
                    if (wyraz_poprzedni[j] == spacja)
                    {
                        wyraz_poprzedni.Trim(spacja);
                    }
                }
                */

                if (czy_anagram(wyrazy[i], wyrazy[i-1]))
                {
                    Console.WriteLine(wyrazy[i]);
                    anagramy.Add(wyrazy[i]);
                    licznik++;
                }
            }

            Console.WriteLine(licznik);

            TextWriter plik = File.CreateText("wszystkie_anagramy.txt");
            foreach (String wyraz in anagramy)
            {
                plik.WriteLine(wyraz);
            }
            plik.Close();
        }
        
    }
}
