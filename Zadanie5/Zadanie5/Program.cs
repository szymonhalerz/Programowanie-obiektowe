//5.Napisz program umożliwiający wprowadzanie n liczb oraz sortujący te liczby metodą
//bąbelkową lub wstawiania. Wyniki wyświetlaj na konsoli.

using System;

namespace Zadanie5
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] tablica = WczytajLiczby();

            Console.WriteLine("\nTablica przed posortowaniem:");
            WypiszTablice(tablica);

            SortujBabelkowo(tablica);

            Console.WriteLine("\nTablica po posortowaniu (rosnąco):");
            WypiszTablice(tablica);

            Console.ReadKey();
        }

        static double[] WczytajLiczby()
        {
            Console.Write("Podaj ile liczb chcesz wprowadzić (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            double[] liczby = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Podaj liczbę {i + 1}: ");
                liczby[i] = Convert.ToDouble(Console.ReadLine());
            }

            return liczby;
        }

        static void SortujBabelkowo(double[] tab)
        {
            int n = tab.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        double temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }
                }
            }
        }

        static void WypiszTablice(double[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");
            }
            Console.WriteLine();
        }
    }
}