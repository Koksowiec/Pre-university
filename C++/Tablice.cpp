#include <iostream>
#include <string>
using namespace std;

int main()
{
    int t,n, *tab;

    cin >> t;

    for (int i = 0; i < t; i++)
    {
        cin >> n;
        tab = new int[n];
        for (int j = 0; j < n; j++)
        {
            cin >> tab[j];
        }

        for (int j = (n-1); j >= 0; j--)
        {
            cout << tab[j] << " ";
        }

        cout << endl;
    }

    delete [] tab;

    return 0;
}
