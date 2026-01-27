//Zadanie 4.
//Stwórz klasę Licz z:
//• publicznym polem value przechowującym wartość liczbową.
//• metodą Dodaj przyjmującą jeden parametr i dodającą przekazaną wartość do wartości
//trzymanej w polu value.
//• analogiczną operację odejmij
//W Main utwórz kilka obiektów klasy Licz i wykonaj różne operacje.
//Do klasy Licz dodaj konstruktor z jednym parametrem - który inicjuje pole wartość na liczbę przekazaną
//w parametrze.
//Zmień widoczność pola na private i dodaj funkcję wypisującą stan obiektu (pole value)

using System;

namespace Lab2_Zad4
{
    static class Program
    {
        public class Licz
        {
            private double value;

            public void Dodaj(double parametr)
            {
                this.value += parametr;
            }

            public void Odejmij(double parametr)
            {
                this.value -= parametr;
            }

            public Licz(double x)
            {
                this.value = x;
            }

            public void WypiszStan() 
            {
                Console.WriteLine($"Aktualna wartość: {this.value}.");
            }
        }
        static void Main(string[] args)
        {
            Licz obiekt1 = new Licz(3);
            obiekt1.Dodaj(2);
            obiekt1.Odejmij(1);
            obiekt1.WypiszStan();
        }
    }
}