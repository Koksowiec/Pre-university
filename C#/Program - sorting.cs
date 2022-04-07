using System;

namespace lab2_algorytmy_krzysztof_szczepanski
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zad 1
            int liczba = 0;
            int zakresMin = 1;
            int zakresMax = 1000;

            while (true)
            {
                Console.Write("Podaj liczbe od 1 do 1000: ");
                liczba = Convert.ToInt32(Console.ReadLine());

                if (liczba > zakresMax || liczba < zakresMin)
                {
                    Console.WriteLine("Zly zakres!");
                }
                else
                    break;
            }

            Random rand = new Random(zakresMax);

            int strzal = 0;

            while (true)
            {
                strzal = rand.Next(zakresMin, zakresMax);

                Console.Write(strzal + ", ");

                if (strzal > liczba)
                {
                    zakresMax = strzal - 1;
                }
                else if (strzal < liczba)
                {
                    zakresMin = strzal + 1;
                }
                else if (strzal == liczba)
                {
                    break;
                }

                Console.Write($"Zakres min: {zakresMin}, ");
                Console.Write($"Zakres max: {zakresMax}, ");
                Console.WriteLine();
            }

            Console.WriteLine("Trafiony!");

            //Zad 2 - własna implementacja sortowania, prawdopodobnie takowe już istnieje aczkolwiek jedynie takie umiem wymyślić
            //sprawdzam czy liczba obecna jest mniejsza od poprzedniej, jeśli jest, to zamieniam je miejscami, wykonuję działanie tyle razy ile jest liczb w tablicy
            //wszystko wykonuje się jeszcze raz tyle ile jest liczb w tablicy ponieważ jeśli wykonałbym tylko wewnętrzną pętlę działanie wykonało by się tylko raz, wciąż nie dając pożądanego efektu
            int[] tab = new int[20];

            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = rand.Next(1000);
                Console.Write(tab[i] + " ");
            }

            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 1; j < tab.Length; j++)
                {
                    if (tab[j] < tab[j - 1])
                    {
                        int zmiennaPomocnicza = tab[j];
                        tab[j] = tab[j - 1];
                        tab[j - 1] = zmiennaPomocnicza;
                    }
                }
            }

            Console.WriteLine();

            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");
            }

            Console.WriteLine();

            //Zad 3
            Console.Write("Podaj slowo: ");
            string slowo = Console.ReadLine();
            char[] tabCh = new char[slowo.Length];

            for (int i = 0; i < slowo.Length; i++)
            {
                tabCh[i] = slowo[i];
            }

            for (int i = 0; i < tabCh.Length; i++)
            {
                for (int j = i + 1; j < tabCh.Length; j++)
                {
                    //jeśli bedziemy podawac znaki np. abcABC to wykona się prawie dobrze, z tym problemem, że wielka litera zostanie na końcu, jesli jednak zaczniemy od wielkiej program tego nie zamieni
                    if ((int)tabCh[i] > (int)tabCh[j])
                    {
                        if ((int)tabCh[i] - 32 == (int)tabCh[j])
                        {
                            Console.Write($"{tabCh[i]} to: {(int)tabCh[i]} ");
                            Console.Write($"{tabCh[j]} to: {(int)tabCh[j]} ");
                            break;
                        }
                        else if((int)tabCh[i] == (int)tabCh[j]-32)
                        {
                            //Ten etap nie działa tak jak zamierzałem, tutaj chciałem sprawdzić czy wielka litera jest na początku i jeśli tak to to zamienić np. abcABC, zamienić a z A
                            /*
							char zmiennaPomocnicza2 = tabCh[j];
                            tabCh[j] = tabCh[i];
                            tabCh[i] = zmiennaPomocnicza2;
                            break;
							*/
                        }
                        char zmiennaPomocnicza = tabCh[j];
                        tabCh[j] = tabCh[i];
                        tabCh[i] = zmiennaPomocnicza;
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            for (int i = 0; i < slowo.Length; i++)
            {
                Console.Write($"{tabCh[i]} ");
            }
        }
    }
}
