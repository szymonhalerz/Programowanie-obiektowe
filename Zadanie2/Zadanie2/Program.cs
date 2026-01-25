using System;

namespace Zadanie2
{
    internal class Zadanie2
    {
        //Napisz program umożliwiający wprowadzanie 10-ciu liczb.Dla wprowadzonych liczb wykonaj
        //odpowiednie algorytmy:
        //oblicz sumę elementów tablicy,
        //oblicz iloczyn elementów tablicy,
        //wyznacz wartość średnią,
        //wyznacz wartość minimalną,
        //wyznacz wartość maksymalną.
        //Wyniki działania algorytmów wyświetlaj na konsoli.

        public static void Main(string[] args)
        {
            double[] tablica = new double[10];

            Console.WriteLine("Podaj 10 liczb: ");
            for (int i = 0; i < 10; i++)
            {
                tablica[i] = Convert.ToDouble(Console.ReadLine());
            }

            double suma = ObliczSume(tablica);
            Console.WriteLine($"Suma: {suma}");

            double iloczyn = ObliczIloczyn(tablica);
            Console.WriteLine($"Iloczyn: {iloczyn}");

            double srednia = ObliczSrednia(tablica, suma);
            Console.WriteLine($"Średnia: {srednia}");

            double minimalna = PokazMin(tablica);
            Console.WriteLine($"Min: {minimalna}");

            double maksymalna = PokazMax(tablica);
            Console.WriteLine($"Max: {maksymalna}");
        }

        static double ObliczSume(double[] tablica)
        {
            double suma = 0;
            for (int i = 0; i < 10; i++)
            {
                suma = suma + tablica[i];
            }
            return suma;
        }

        static double ObliczIloczyn(double[] tablica)
        {
            double iloczyn = 1;
            for (int i = 0; i < 10; i++)
            {
                iloczyn = iloczyn * tablica[i];
            }
            return iloczyn;
        }

        static double ObliczSrednia(double[] tablica, double suma)
        {
            double srednia = 1;
            srednia = suma / tablica.Length;
            
            return srednia;
        }

        static double PokazMin(double[] tablica)
        {
            double min = tablica[0];

            for (int i = 0; i < 10; i++)
            {
                min = Math.Min(min, tablica[i]);
            }
            return min;
        }

        static double PokazMax(double[] tablica)
        {
            double max = tablica[0];

            for (int i = 0; i < 10; i++)
            {
                max = Math.Max(max, tablica[i]);
            }
            return max;
        }
    }
}




