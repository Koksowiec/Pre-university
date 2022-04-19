using System;

namespace Statki
{
    class Plansza
    {
        public string[,] plansza = new string[3,3];

        public void rysuj()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j<3; j++)
                {
                    plansza[i, j] += ".";
                }
            }
        }

        public void wyswietl()
        {
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j< 3;j++)
                {
                    Console.Write(plansza[i, j]);
                    if (j != 2)
                        Console.Write("|");
                    else if(i != 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("-----");
                    }
                }
            }
        }
    }

    class GameMaster : Plansza
    {
        //Plansza pln = new Plansza();
        int x = 0;
        int y = 0;
        public bool koniecGry = false;
        public void rozgrywka()
        {
            
            bool kolejka = false;
            string gracz = string.Empty;

            rysuj();
            
            while (!koniecGry)
            {
                wyswietl();
                Console.WriteLine();

                if (kolejka)
                    gracz = "X";
                else
                    gracz = "O";

                wyborGracza(gracz);

                zasady();

                kolejka = !kolejka;
            }
        }

        public void wyborGracza(string gracz)
        {
            Console.Write("podaj x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("podaj y: ");
            y = Convert.ToInt32(Console.ReadLine());

            if (x > 3 || y > 3 || x < 1 || y < 1)
            {
                Console.WriteLine("Nie ma takiego pola, wybierz jeszcze raz!");
                wyborGracza(gracz);
            }

            if (plansza[y - 1, x - 1] == "X" || plansza[y - 1, x - 1] == "O")
            {
                Console.WriteLine("To pole jest juz zajete, wybierz inne!");
                wyborGracza(gracz);
            }

            plansza[y - 1, x - 1] = gracz;
        }

        public void zasady()
        {
            int counterO = 0;
            int counterX = 0;

            //poziom O i X
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    //Console.WriteLine($"plansza[{i},{j}] = {plansza[i,j]}");

                    if (plansza[i, j] == "O")
                    {
                        counterO++;
                    }
                    else if(plansza[i, j] == "X")
                    {
                        counterX++;
                    }
                    else
                    {
                        counterO = 0;
                        counterX = 0;
                    }
                }

                if (counterO == 3)
                {
                    Console.WriteLine("Wygrywa O!");
                    Console.WriteLine();
                    koniecGry = true;
                    break;
                }
                else if(counterX == 3)
                {
                    Console.WriteLine("Wygrywa X!");
                    Console.WriteLine();
                    koniecGry = true;
                    break;
                }
            }

            counterX = 0;
            counterO = 0;

            //pion O i X
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (plansza[j, i] == "O")
                    {
                        counterO++;
                    }
                    else if (plansza[j, i] == "X")
                    {
                        counterX++;
                    }
                    else
                    {
                        counterO = 0;
                        counterX = 0;
                    }
                }

                if (counterO == 3)
                {
                    Console.WriteLine("Wygrywa O!");
                    Console.WriteLine();
                    koniecGry = true;
                    break;
                }
                else if (counterX == 3)
                {
                    Console.WriteLine("Wygrywa X!");
                    Console.WriteLine();
                    koniecGry = true;
                    break;
                }
            }

            counterO = 0;
            counterX = 0;

            //skos z lewej do prawej O i X
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j && plansza[j, i] == "O")
                    {
                        counterO++;
                    }
                    else if (i == j && plansza[j, i] == "X")
                    {
                        counterX++;
                    }
                    else if (i == j && (plansza[j, i] != "X" || plansza[j, i] != "O"))
                    {
                        counterO = 0;
                        counterX = 0;
                    }
                }

                if (counterO == 3)
                {
                    Console.WriteLine("Wygrywa O!");
                    Console.WriteLine();
                    koniecGry = true;
                    break;
                }
                else if (counterX == 3)
                {
                    Console.WriteLine("Wygrywa X!");
                    Console.WriteLine();
                    koniecGry = true;
                    break;
                }
            }

            counterX = 0;
            counterO = 0;

            //skos z prawej do lewej O i X
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i+j == 2 && plansza[j, i] == "O")
                    {
                        counterO++;
                    }
                    else if (i+j == 2 && plansza[j, i] == "X")
                    {
                        counterX++;
                    }
                    else if (i+j == 2 && (plansza[j, i] != "X" || plansza[j, i] != "O"))
                    {
                        counterO = 0;
                        counterX = 0;
                    }
                }

                if (counterO == 3)
                {
                    Console.WriteLine("Wygrywa O!");
                    Console.WriteLine();
                    koniecGry = true;
                    break;
                }
                else if (counterX == 3)
                {
                    Console.WriteLine("Wygrywa X!");
                    Console.WriteLine();
                    koniecGry = true;
                    break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameMaster gm = new GameMaster();
            gm.rozgrywka();
        }
    }
}
