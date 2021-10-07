#include <iostream>
#include <cstdlib>
#include <time.h>
#include <ctime>
using namespace std;

int main()
{
    int n = 0;
    bool czyPierwsza = true;

    cin >> n;

    int* tablica;
    tablica = new int[n];

    for (int i = 0; i < n; i++)
    {
        cin >> tablica[i];
    }

    for (int i = 0; i < n; i++)
    {
        if (tablica[i] > 1)
        {
            for (int j = 2; j < tablica[i]; j++)
            {
                if (tablica[i] % j == 0)
                {
                    czyPierwsza = false;
                    cout << "NIE" << endl;
                    break;
                }
                else
                {
                    czyPierwsza = true;
                }
            }

            if (czyPierwsza)
            {
                cout << "TAK" << endl;
            }
        }
        else
        {
            cout << "NIE" << endl;
        }
    }

    delete[] tablica;
    return 0;
}