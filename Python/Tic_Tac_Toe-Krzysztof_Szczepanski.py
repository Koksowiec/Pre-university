plansza = ["1","2","3","4","5","6","7","8","9"]
plansza_wykluczenia = []
graczX = 'X'
graczO = 'O'

def RysujPlansze():
    for i in range(1,10):
        print(" " + plansza[i-1] + " ", end='')
        if i % 3 == 0:
            print()



def Ruch(user, user_input):  
    if user_input >= 1 and user_input <= 9 :
        plansza[user_input-1] = user
        plansza_wykluczenia.append(user_input);
    else:
        print("Nie ma takiego pola!")
        Ruch(user, user_input)

def PoleZajete(user_input):
    if int(user_input) in plansza_wykluczenia:
        print("To pole jest juz zajete")   
        return False
    return True
    
def SprawdzWygrana():
    wygrany = SprawdzPoziom()  
    if wygrany != False:
        return wygrany
    wygrany = SprawdzPion()
    if wygrany != False:
        return wygrany
    wygrany = SprawdzSkos()
    if wygrany != False:
        return wygrany
    
    return ""
    

def SprawdzPoziom():
    gracz = graczX
    for j in range (1,2):
        if(j%2 == 0):
            gracz = graczO
        for i in range (0,8,3):
            if(plansza[i] == gracz and plansza[i+1] == gracz and plansza[i+2] == gracz):
                return gracz
    return False

def SprawdzPion():
    gracz = graczX
    for j in range (1,2):
        if(j%2 == 0):
            gracz = graczO
        for i in range (3):
            if(plansza[i] == gracz and plansza[i+3] == gracz and plansza[i+6] == gracz):
                return gracz
    return False

def SprawdzSkos():
    gracz = graczX
    for j in range (1,2):
        if(j%2 == 0):
            gracz = graczO
            
        if(plansza[0] == gracz and plansza[4] == gracz and plansza[8] == gracz):
            return gracz
        elif(plansza[2] == gracz and plansza[4] == gracz and plansza[6] == gracz):
            return gracz
    
    return False

def Graj():
    print("---------Gra w Kolko i krzyzyk---------")
    
    runda = 1
    koniec = False
    while koniec == False:
        user = graczX
        if runda % 2 == 0:
            user = graczO
            
        RysujPlansze()    
        
        print("\nTeraz gra: " + user)
        user_input = ''
        
        flaga = False
        while  flaga == False:
            user_input = int(input("Wybierz pole na które chcesz zagrać: "))
            if PoleZajete(user_input) == True:
                flaga = True       
            
        Ruch(user, user_input)
        
        print("\n---------Koniec rundy " + str(runda) + "---------\n")
        
        if runda == 9 or len(plansza_wykluczenia) >= 9:
            print("Remis")
            koniec = True
        
        if SprawdzWygrana() != "":
            RysujPlansze()
            print("Wygrywa " + user + "!")
            koniec = True
            
        runda += 1
        

        
Graj()