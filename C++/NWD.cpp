#include <iostream>
#include <string>
using namespace std;

int a = 0, b = 0;
int t = 0;

int nwd(int a, int b)
{
    //niezoptymalizowany dla dużych liczb
    /*for (int i = 1; i <= max(a, b); i++)
    {
        if (a % i == 0 && b % i == 0)
        {
            dzielnik = i;
        }
    }

    return dzielnik;*/

    while (a != b)
        if (a > b)
            a -= b;
        else
            b -= a;

    return a;
}

int main()
{
    cin >> t;  
    cin.ignore();
    
    for (int i = 0; i < t; i++)
    {      
        cin >> a;
        if (cin.peek() == ' ')
            cin >> b;

        cout << nwd(a, b) << endl;
        
        a = 0;
        b = 0;
    }
    
}

