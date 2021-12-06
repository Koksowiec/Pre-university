#include <iostream>
#include <string>
using namespace std;

string plansza[] = { "1", "|", "2", "|", "3",
                     "-----",
                     "4", "|", "5", "|", "6",
                     "-----",
                     "7", "|", "8", "|", "9"
};

int doTrzechX = 0;
int doTrzechO = 0;
bool koniecGry = false;

void rysujPlansze() {
    for (int i = 0; i < (sizeof(plansza) / sizeof(plansza[0])); i++)
    {
        if ((i + 1) % 6 == 0)
        {
            cout << endl;
            cout << plansza[i];
            cout << endl;
        }
        else
        {
            cout << plansza[i];
        }
    }
}

void czyPlanszaPelna() {
    int czyZajete = 0;
    for (int i = 0; i < sizeof(plansza) / sizeof(plansza[0]); i++) {
        if (plansza[i] == "X" || plansza[i] == "O")
        {
            czyZajete++;
        }
    }
    if (czyZajete == 9)
    {
        cout << "Plansza pelna! Remis!" << endl;
        koniecGry = true;
        return;
    }
}

int czyZajete(string pole) {
    if (pole == "O" || pole == "X")
    {
        cout << "To pole jest zajete!" << endl;
        return 0;
    }
    else {
        return 1;
    }
}

void wpiszDoPlanszy(bool XczyO) {
    string wybor;
    string XO;

    if (XczyO)
    {
        cout << "Gracz X, Wybor: ";
        XO = "X";
    }
    else
    {
        cout << "Gracz O, Wybor: ";
        XO = "O";
    }
    cin >> wybor;

    switch (stoi(wybor)) {
    case 1:
        if (czyZajete(plansza[0]) == 0)
        {
            wpiszDoPlanszy(XczyO);
        }
        else {
            plansza[0] = XO;
        }
        
        break;
    case 2:
        if (czyZajete(plansza[2]) == 0)
        {
            wpiszDoPlanszy(XczyO);
        }
        else {
            plansza[2] = XO;
        }
        break;
    case 3:
        if (czyZajete(plansza[4]) == 0)
        {
            wpiszDoPlanszy(XczyO);
        }
        else {
            plansza[4] = XO;
        }
        break;
    case 4:
        if (czyZajete(plansza[6]) == 0)
        {
            wpiszDoPlanszy(XczyO);
        }
        else {
            plansza[6] = XO;
        }
        break;
    case 5:
        if (czyZajete(plansza[8]) == 0)
        {
            wpiszDoPlanszy(XczyO);
        }
        else {
            plansza[8] = XO;
        }
        break;
    case 6:
        if (czyZajete(plansza[10]) == 0)
        {
            wpiszDoPlanszy(XczyO);
        }
        else {
            plansza[10] = XO;
        }
        break;
    case 7:
        if (czyZajete(plansza[12]) == 0)
        {
            wpiszDoPlanszy(XczyO);
        }
        else {
            plansza[12] = XO;
        }
        break;
    case 8:
        if (czyZajete(plansza[14]) == 0)
        {
            wpiszDoPlanszy(XczyO);
        }
        else {
            plansza[14] = XO;
        }
        break;
    case 9:
        if (czyZajete(plansza[16]) == 0)
        {
            wpiszDoPlanszy(XczyO);
        }
        else {
            plansza[16] = XO;
        }
        break;
    default:
        cout << "Niepoprawny wybor! Wybierz jeszcze raz: ";
        wpiszDoPlanszy(XczyO);
        break;
    }
}

void warunkiZwyciestwa() {

    //Czy plansza pelna
    czyPlanszaPelna();
    if (koniecGry)
        return;

    //Rzedy horyzontalnie
    for (int i = 0; i < (sizeof(plansza) / sizeof(plansza[0])); i+=2)
    {
        //pierwszy rzad
        if (/*i % 2 == 0 &&*/ i < 6)
        {
            //dla X
            if (plansza[i] == "X")
                doTrzechX++;
            else
                doTrzechX = 0;

            //dla O
            if (plansza[i] == "O")
                doTrzechO++;
            else
                doTrzechO = 0;
        }
        
        //drugi rząd
        if (/*i % 2 == 0 &&*/ (i >= 6 && i < 12))
        {
            //dla X
            if (plansza[i] == "X")
                doTrzechX++;
            else
                doTrzechX = 0;

            //dla O
            if (plansza[i] == "O")
                doTrzechO++;
            else
                doTrzechO = 0;
        }

        //trzeci rzad
        if (/*i % 2 == 0 &&*/ i >= 12)
        {
            //dla X
            if (plansza[i] == "X")
                doTrzechX++;
            else
                doTrzechX = 0;

            //dla O
            if (plansza[i] == "O")
                doTrzechO++;
            else
                doTrzechO = 0;
        }

        //sprawdz wygraną
        if (doTrzechX == 3)
        {
            cout << "Rzad! ";
            cout << "X wygrywa! "<<endl;
            koniecGry = true;
            break;
        }
        else if (doTrzechO == 3)
        {
            cout << "Rzad! ";
            cout << "O wygrywa! "<<endl;
            break;
            koniecGry = true;
        }
    }
    
    //Rzedy pionowo
    for(int j = 0; j<=16; j+=6)/*while (j != 16)*/ {
        //j += 6;
        //cout << j << endl;
         
        //dla X
        if (plansza[j] == "X")
        {
            doTrzechX++;
            //cout << "Dodaje X " << doTrzechX << endl;
        }
        else
        {
            //cout << "Zeruje X" << endl;
            doTrzechX = 0;
        }

        //dla O
        if (plansza[j] == "O")
            doTrzechO++;
        else
            doTrzechO = 0;

        //sprawdz wygraną
        if (doTrzechX == 3)
        {
            cout << "Kolumna! ";
            cout << "X wygrywa! " << endl;
            koniecGry = true;
            break;
        }
        else if (doTrzechO == 3)
        {
            cout << "Kolumna! ";
            cout << "O wygrywa! " << endl;
            break;
            koniecGry = true;
        }

        //automatyzacja
        if (j == 12)
        {
            doTrzechO = 0;
            doTrzechX = 0;
            j = 2 - 6;
            continue;
        }
        else if (j == 14)
        {
            doTrzechO = 0;
            doTrzechX = 0;
            j = 4 - 6;
            continue;
        }
    }

    //Rzedy na skos
    //Lewy górny, środek, prawy dolny
    if (plansza[0] == "X" && plansza[8] == "X" && plansza[16] == "X")
    {
        cout << "Skos! ";
        cout << "X wygrywa!" << endl;
        koniecGry = true;
    }
    else if (plansza[0] == "O" && plansza[8] == "O" && plansza[16] == "O")
    {
        cout << "Skos! ";
        cout << "O wygrywa!" << endl;
        koniecGry = true;
    }
    //Prawy górny, środek, lewy dolny
    if (plansza[4] == "X" && plansza[8] == "X" && plansza[12] == "X")
    {
        cout << "Skos! ";
        cout << "X wygrywa!" << endl;
        koniecGry = true;
    }
    else if (plansza[4] == "O" && plansza[8] == "O" && plansza[12] == "O")
    {
        cout << "Skos! ";
        cout << "O wygrywa!" << endl;
        koniecGry = true;
    }
}

int main()
{
    //string wybor = "0";
    bool XczyO = true;   
    cout << "WITAJ W GRZE W KOLKO I KRZYZYK!" << endl;

    while (!koniecGry/*wybor != "exit"*/)
    {
        cout << endl;
        rysujPlansze();

        cout << endl;
        cout << endl;
        
        wpiszDoPlanszy(XczyO);

        warunkiZwyciestwa();

        XczyO = !XczyO;
    }
    cout << endl;
    rysujPlansze();
    cout << endl << "Koniec gry!";
    
}