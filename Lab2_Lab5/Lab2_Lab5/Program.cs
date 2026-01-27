//Zadanie 5.
//Stwórz klasę Sumator z:
//• publicznym polem Liczby będącym tablicą liczb
//• metodą Suma zwracającą sumę liczb z pola Liczby
//• metodę SumaPodziel2 zwracającą sumę liczb z tablicy, które są podzielne przez 2
//Zmień widoczność pola Liczby na private oraz dodaj konstruktor.
//Dodaj metodę: int IleElementów() zwracającej liczbę elementów na w tablicy
//Dodaj metodę wypisującą wszystkie elementy tablicy
//Dodaj metodę przyjmującą dwa parametry: lowIndex oraz highIndex, która wypisze elementy o
//indeksach >= lowIndex oraz <= highIndex. Metoda powinna zadziałać poprawnie, gdy lowIndex lub
//highIndex wykraczają poza zakres tablicy (pominąć te elementy).

using System;

namespace Lab2_Zad5
{
    class Sumator
    {
        private int[] Liczby;

        public Sumator(int[] tablica)
        {
            this.Liczby = tablica;
        }


        public int Suma()
        {
            int suma = 0;

            for (int i = 0; i < Liczby.Length; i++)
            {
                suma += Liczby[i];
            }
            return suma;
        }

        public int SumaPodziel2()
        {
            int suma = 0;
            for (int i = 0; i < Liczby.Length; i++)
            {
                if (Liczby[i] % 2 == 0)
                {
                    suma += Liczby[i];
                }
            }
            return suma;
        }

        public void Wypisywanie()
        {
            for (int i = 0; i < Liczby.Length; i++)
            {
                Console.WriteLine($"{i+1} element z tablicy to: {Liczby[i]}.");
            }
        }

        public int ileElementow()
        {
            return Liczby.Length;
        }

        public void WypiszZakres(int lowIndex, int highIndex)
        {
            for (int i = lowIndex; i <= highIndex; i++)
            {
                if (i >= 0 && i < Liczby.Length)
                {
                    Console.WriteLine($"Liczba z tablicy spełniająca warunki to: {Liczby[i]}.");
                }
            }
        }




        class Program
        {

            static void Main(string[] args)
            {
                int[] tablica = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
                Sumator obiekt1 = new Sumator(tablica);

                Console.WriteLine($"Suma liczb to: {obiekt1.Suma()}\n");
                Console.WriteLine($"Suma liczb tablicy, która jest podzielna przez 2 to: {obiekt1.SumaPodziel2()}\n");
                obiekt1.Wypisywanie();
                Console.WriteLine($"Liczba elemntów w tablicy to: {obiekt1.ileElementow()}\n");
                obiekt1.WypiszZakres(-5,6);
            }
        }
    }
}

