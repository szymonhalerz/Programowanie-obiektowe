//Zadanie 1.
//Napisz klasę Osoba, która będzie przechowywać informacje o imieniu, nazwisku oraz wieku osoby.
//• Zaimplementuj konstruktor, który będzie przyjmował wszystkie trzy wartości.
//• Użyj właściwości Imie, Nazwisko, Wiek, z walidacją:
//o Imię i Nazwisko muszą mieć co najmniej 2 znaki.
//o Wiek musi być liczbą dodatnią.
//• Zaimplementuj metodę WyswietlInformacje(), która wyświetli informacje o osobie.

using System;

namespace Lab2_Zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Osoba("Szymon", "Halerz", 22).WyswietlInformacje();
        }

        public class Osoba
        {
            private string imie;
            private string nazwisko;
            private int wiek;

            public string Imie
            {
                get
                {
                    return imie;
                }
                set
                {
                    if (value.Length >= 2)
                    {
                        imie = value;
                    }
                    else
                    {
                        Console.WriteLine("Imie musi miec conajmniej 2 znaki.");
                    }
                }
            }

            public string Nazwisko
            {
                get
                {
                    return nazwisko;
                }
                set
                {
                    if (value.Length >= 2)
                    {
                        nazwisko = value;
                    }
                    else
                    {
                        Console.WriteLine("Nazwisko musi miec conajmniej 2 znaki.");
                    }
                }
            }


            public int Wiek
            {
                get
                {
                    return wiek;
                }
                set
                {
                    if (value >= 1)
                    {
                        wiek = value;
                    }
                    else
                    {
                        Console.WriteLine("Wiek nie może być ujemny!");
                    }
                }
            }
            public Osoba(string imie, string nazwisko, int wiek)
            {
                this.Imie = imie;
                this.Nazwisko = nazwisko;
                this.Wiek = wiek;
            }

            public void WyswietlInformacje()
            {
                Console.WriteLine($"Imie: {Imie}, Nazwisko: {Nazwisko}, Wiek: {Wiek}.");
            }
        }
    }
}