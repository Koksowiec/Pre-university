#include <iostream> 
using namespace std;

int main()
{
	int t, n, tab[2];

	cin >> t;
	for (int a = 0; a < t; a++)
	{
		cin >> n;
		for (int i = 0; i < 2; i++)
		{
			cin >> tab[i];
		}

		for (int i = 1; i < n; i++)
		{
			if ((i % tab[0] == 0) && (i % tab[1] != 0))
			{
				cout << i << " ";
			}
		}

		cout << endl;
	}

	return 0;
}