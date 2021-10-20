#include <iostream>
#include <string>
using namespace std;


string ciag, ciagBackup;
bool czyPalindrom = false;
int t, liczba, liczbaOdwrocona, suma, licznik;

//----------------------------------<>----------------------------------//
//Funkcja Zlicz():
//
//przyjmuje stringa ciag
//jako "liczba" wpisuje wartosc ciagu ktora powinna byc liczba
//tworzy zmienna pomocnicza ciagBackup ktora przyjmuje wartosc ciagu
//w pętli zamienia wartość ciagBackup na odwrocona wartosc ciagu (liczby)
//zapisuje odwrocony ciag znakow do inta "liczbaOdwrocona" 
//oblicza sume obu liczb
//do ciagu wpisuje sume
//zwieksza licznik o 1

void Zamien(string c) 
{
        liczba = stoi(c);
        ciagBackup = c;

        for (int i = 0; i < c.length(); i++)
        {
            swap(ciagBackup[i], c[(c.length() - 1) - i]);
        }

        liczbaOdwrocona = stoi(ciagBackup);

        suma = liczba + liczbaOdwrocona;
        ciag = to_string(suma);

        licznik++;
}

//----------------------------------<>----------------------------------//
//Funkcja Sprawdz():
//
//przyjmuje stringa ciag
//po kolei sprawdza czy pierwsza i ostatnia wartosc ciagu są takie same, c.length()-1 ponieważ zawsze ostatnia wartość ciągu to \0, więc chcemy dostać się do tego co jest przed nią
//jeżeli te wartosci sa takie same zmienia boola "czyPalindrom" na true
//jeżeli następuje rozbierzność zmienna bool "czyPalindrom" zostaje zmieniona na false a pętla zostaje przerwana

void Sprawdz(string c) 
{
    for (int i = 0; i < c.length(); i++)
    {
        if (c[i] == c[(c.length() - 1) - i])
        {
            //cout << "sa takie same" << endl;
            czyPalindrom = true;
        }
        else
        {
            //cout << "to nie palindrom" << endl;
            czyPalindrom = false;
            break;
        }
    }
}

//----------------------------------<>----------------------------------//
//funkcja main():
//
//najpierw przyjmuje ile liczb chcemy wprowadzic do zmiennej "t"
//następnie tyle razy wykonuje się pętla for, w której:
//wpisywana jest sprawdzana liczba do zmiennej "ciag"
//while() sprawdza czy zmienna bool "czyPalindrom" ma wartosc fałsz, ma ona domyślnie wartość fałsz dlatego zawsze się wykona
//przekazuje zmienną ciąg do funkcji Sprawdz()
//jeżeli dalej bool "czyPalindrom" ma wartość fałsz to przekazuje ciąg do funkcji Zamien()
//wypisuje ciag i licznik
//resetuje zmienne na ich domyślne wartości
//kończy program

int main()
{
    cin >> t;

    for (int i = 0; i < t; i++)
    {
        cin >> ciag;

        while (!czyPalindrom)
        {
            Sprawdz(ciag);
            if (!czyPalindrom)
            {
                Zamien(ciag);
            }
        }

        cout << ciag << " " << licznik << endl;

        licznik = 0;
        ciag = "";
        czyPalindrom = false;
    }

    return 0;
}

