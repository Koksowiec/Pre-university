#include <iostream>
#include <string>
using namespace std;

int main()
{
    int t = 0;
    int n = 0;
    string napis;

    int liczbaI=0;
    string liczbaS;
    int suma = 0;
    
    cin >> t;

    for (int i = 0; i < t; i++)
    {
        cin >> n;//zmylka ze SPOJ
        
        cin.ignore(); //https://stackoverflow.com/questions/12691316/getline-does-not-work-if-used-after-some-inputs
                      //When cin.getline() reads from the input, there is a newline character left in the input stream, so it doesn't read your c-string. Use cin.ignore() before calling getline().
        
        getline(cin, napis);
       
        for (int i = 0; i <= napis.length(); i++)
        {
            if (napis[i] != ' ' && napis[i] != '\0') //w ostatniej komórce stringa nzajduje się \0, w końcu wiedza o tym się przydała ;)
            {
                liczbaS += napis[i];
            }
            else if (napis[i] == ' ' || napis[i] == '\0')
            {
                liczbaI = stoi(liczbaS);
                //cout << liczbaI << endl;
                suma += liczbaI;

                liczbaS = "";
            }
        }
        cout << suma<<endl;
        suma = 0;
    }
    return 0;
}
