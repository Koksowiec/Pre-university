#include <iostream>
#include <string>
using namespace std;

string Przetworz(string n)
{
    int licznik = 0;

    for (int i = 0; i < n.length(); i++)
    {
        if (n[i] == n[i + 1])
        {
            licznik++;
        }
        else
        {
            if (licznik > 1)
            {
                n.replace(i - (licznik-1), licznik, to_string(licznik + 1));

                i = 0;
            }
            licznik = 0;
        }
    }

    return n;
}

//Wpisz najpierw liczbe ciagow znakow jaka chcesz wprowadzic np. 2
//Nastepnie wpisz ciagi znakow np. AAAAAAAAAABBBBBBBBBBBBBBBB i AAAAABBBCCCDDEEEEE
//Jeżeli obok siebie znajdują się więcej niż 2 litery to program zapisze ich ilość
//w tym wypadku A10B16 i A5B3C3DDE5
//

int main()
{
    int c = 0;
    string napis;

    while (c < 1 || c>50)
    {
        cin >> c;
    }

    for (int i = 0; i < c; i++)
    {
        cin >> napis;
        cout << Przetworz(napis) << endl;
    }

    return 0;
}
