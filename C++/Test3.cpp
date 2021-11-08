#include <iostream>
using namespace std;

int main()
{
    int liczba = 0, pomocnik = 0, licznik = 0;

    while (cin>>liczba)
    {
        cout << liczba << endl;
        if (liczba == 42 && pomocnik == 1)
        {
            licznik++;
        }

        if (liczba != 42)
        {
            pomocnik = 1;
        }
        else {
            pomocnik = 0;
        }

        if (licznik == 3)
        {
            break;
        }
    }

    return 0;
}
