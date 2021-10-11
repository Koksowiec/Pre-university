#include <iostream>
#include <string>
#include <sstream>
using namespace std;

int d = 0;
int wynik = 1;
string wynikSTR;
stringstream ss;

int main()
{
    cin >> d;
    while(d < 1 || d>30)
    {
        cin >> d;
    }

    unsigned int* tablica;
    tablica = new unsigned int [d];

    for (int i = 0; i < d; i++)
    {
        cin >> tablica[i];
    }

    for (int i = 0; i < d; i++)
    {
        wynik = 1;
        ss.str("");

        if (tablica[i] == 0 || tablica[i] == 1)
        {
            wynik = 1;
        }
        else 
        {
            for (int j = 1; j <= tablica[i]; j++)
            {
                wynik = wynik * j;
            }
        }
  
        ss << wynik;
        wynikSTR = ss.str();

        for (int j = 0; j < wynikSTR.length(); j++)
        {
            if (wynikSTR.length() <= 1)
            {
                cout << "0";
                cout << " ";
            }
            cout << wynikSTR[j];
            cout << " ";
        }

        cout << endl;
    }

    delete[] tablica;
    
    return 0;
}