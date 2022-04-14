# English Description

This program is the simplistic version of Huffmans compression method. This is a task given by my "Algorithms and Data structures" teacher.

## What it is supposed to do:

This program doesn't genereate a char tree and 0/1 strings, it takes a certain number of bits as char, that comes out of the number of diffrent characters in the text. When we hae 2 chars, 1 bit is enought (the value of the first one is 0, the second one is 1), when we have 3-4 chars, we have to use 2 bits (start from 00, 01, 10, 11 so the 0,1,2,3), for 5-8 chars we have to use 3 bits and so on. The number of the bits we get from log2 out of the number of diffrent chars in the text.

## What each method does from top to bottom:

**Dec2Bin(int dec, int n)** -> converts decimal number to binary, it takes decimal number and if it's length is smaller than n then it adds "0" to it


**Bin2Dec(int bin)** -> converts binary number into decimal, it takes binary number


**dopiszBrakujaceBityJako1(string ciag)** -> whenever binary value doesn't consist of 8 digits the missing ones are added as "1" for example: 1001 -> 10011111


**indeksWCiag(char literaTekstu, string slownik)** -> checks what index in dictionary has the letter in the text given in the file, it takes the letter from text and dictionary


**sortowanieSlownika(char[] slownik)** -> bubble sorts the letters in dictionary, it takes dictionary


**stworzSlownik(string tekst, Dictionary<char, int> slownikZLiczbaPowtorzen)** -> creates extended version of dictionary that also counts how many times each letter occurs in the text given, it is only for the console output, it takes text and extended dictionary



**kolorujTekst(ConsoleColor kolor, string? tekstPrzed, string tekst)** -> it is helping function for coloring text output for the console, it takes color of the text, the text that will be displayed before the colored text (this can be null if there is no text before) and the text that is supposed to be colored


**zamienLiteryNaBityPotemNaChar(int r, int n, string tekst, string slownik)** -> it changes the letters into binary numbers and then those numbers into chars, it actually compresses the letters, it takes number of the extra "1" from dopiszBrakujaceBityJako1(), the number of digits per character, the text and the dictionary


**utworzPlikJesliNieIstnieje_OtworzJesliIstniejeIWykonajDzialania_ZwrocZawartoscPliku(string tekst, string plik)** -> it creats a file if it doesn't exist, open the file if it exists and returns the content of the file, it takes the text to write to the file and the file name


**metodaHuffmana(string tekst, string plik)** -> main method that consist of every other method and gets the compression done, it also displays all the information into the console
