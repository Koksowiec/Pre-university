#include <iostream>
#include <string>
using namespace std;

int main()
{
    int tab[100];
    int i = 0;

    do 
    {
        cin >> tab[i];
        i++;
    } 
    while (cin.get() != '\n');


    for (int j = i-1; j >=0; j--)
    {
        cout<<tab[j]<<" ";
    }
    


    return 0;
}